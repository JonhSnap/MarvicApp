using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Notifications_Request.Services;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos.ViewModels;
using MarvicSolution.Services.Stage_Request.Requests;
using MarvicSolution.Services.Stage_Request.ViewModels;
using MarvicSolution.Services.System.Users.Services;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Stage_Request.Services
{
    public class Stage_Service : IStage_Service
    {
        private readonly MarvicDbContext _context;
        private readonly ILogger<Stage_Service> _logger;
        private readonly INotifications_Service _notifService;
        private readonly IUser_Service _userService;
        public Stage_Service(MarvicDbContext context, ILogger<Stage_Service> logger, INotifications_Service notifService, IUser_Service userService)
        {
            _context = context;
            _logger = logger;
            _notifService = notifService;
            _userService = userService;
        }
        public async Task<bool> AddStage(Stage stage)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    stage.Stage_Name = stage.Stage_Name.ToUpper();
                    _context.Stages.Add(stage);
                    await _context.SaveChangesAsync();
                    // sent notif 
                    _notifService.PSS_SendNotif(stage.Id_Project, stage.Id_Creator, $"{_userService.GetUserbyId(stage.Id_Creator).UserName} has been created Stage {stage.Stage_Name} in Project {GetProjectById(stage.Id_Project).Name}");
                    await tran.CommitAsync();
                    return true;
                }
                catch (Exception e)
                {
                    await tran.RollbackAsync();
                    _logger.LogInformation($"Controller: Stages. Method: AddStage. Marvic Error: {e}");
                    throw new MarvicException($"Error: {e}");
                }
            }
        }
        public async Task<bool> CheckExistName(string stageName, Guid id = default, string action = "create")
        {
            try
            {
                if (action == "edit")
                {
                    return await _context.Stages.AnyAsync(stage => stage.Id != id && stage.Stage_Name == stageName);
                }
                return await _context.Stages.AnyAsync(stage => stage.Stage_Name == stageName && stage.isDeleted == EnumStatus.False);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Stages. Method: CheckExistName. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public async Task<bool> DeleteStage(Stage stage, Remove_Stage_Request modelRequest, Guid idUserLogin)
        {
            try
            {
                var newStage = await GetStageById(modelRequest.Dorward_Id_Stage);
                //change new stage
                if (stage.isDone == EnumStatus.True)
                {
                    newStage.isDone = stage.isDone;
                    stage.isDone = EnumStatus.False;
                }
                if (stage.isDefault == EnumStatus.True)
                {
                    newStage.isDefault = stage.isDefault;
                    stage.isDefault = EnumStatus.False;
                }
                _context.Update(newStage);
                // update order for stages after
                UpdateStageOrderBehind(stage, stage.Id_Project);
                //remove stage
                stage.Order = -99;
                _context.Update(stage);
                //asign list issue in current stage into new stage
                var listIssueInCurrentStage = await _context.Issues
                                                    .Where(isu => isu.Id_Stage == stage.Id && isu.IsDeleted == EnumStatus.False).ToListAsync();
                if (listIssueInCurrentStage.Count != 0)
                {
                    foreach (var id_issue in listIssueInCurrentStage)
                    {
                        id_issue.Id_Stage = modelRequest.Dorward_Id_Stage;
                    }
                    _context.Issues.UpdateRange(listIssueInCurrentStage);
                }
                // sent notif 
                _notifService.PSS_SendNotif(stage.Id_Project, stage.Id_Updator, $"{_userService.GetUserbyId(idUserLogin).UserName} has been deleted Stage {stage.Stage_Name} in Project {GetProjectById(stage.Id_Project).Name}");
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Stages. Method: DeleteStage. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        private void UpdateStageOrderBehind(Stage currStage, Guid idProject)
        {
            try
            {
                var stages = _context.Stages
                   .Where(stage => stage.Id_Project == idProject && stage.isDeleted == EnumStatus.False)
                   .OrderBy(stage => stage.Order).Select(s => s).ToList();
                var stageBehind = stages.Where(s => s.Order > currStage.Order).Select(s => s).ToList();
                foreach (var i_stage in stageBehind)
                    i_stage.Order--;

                _context.UpdateRange(stageBehind);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Stages. Method: DeleteStage. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public async Task<bool> DragAndDrop(int curentPos, int newPos, Guid id_Project)
        {
            try
            {
                int skip = 0;
                var range = curentPos - newPos;
                int take = Math.Abs(range);
                switch (range)
                {
                    case 1 or -1:
                        return await Swap(curentPos, newPos, id_Project);
                    case < 0:
                        skip = curentPos + 1;
                        break;
                    default:
                        skip = newPos;
                        break;
                }
                var result = await UpdateListOrder(skip, take, curentPos, newPos, id_Project, range > 0);
                return result;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Stages. Method: DragAndDrop. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        private async Task<bool> Swap(int curentPos, int newPos, Guid id_Project)
        {
            try
            {
                var currentStage = await _context.Stages.FirstOrDefaultAsync(stage => stage.Id_Project == id_Project && stage.Order == curentPos);
                currentStage.Order = newPos;
                var newStage = await _context.Stages.FirstOrDefaultAsync(stage => stage.Id_Project == id_Project && stage.Order == newPos);
                newStage.Order = curentPos;
                _context.Stages.UpdateRange(new[] { currentStage, newStage });
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Stages. Method: Swap. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        private async Task<bool> UpdateListOrder(int skip, int take, int curentPos, int newPos, Guid id_Project, bool inCrease = true)
        {
            try
            {
                // take stages after current stage
                var stages = await _context.Stages
                    .Where(stage => stage.Id_Project == id_Project && stage.isDeleted.Equals(EnumStatus.False))
                    .OrderBy(s => s.Order)
                    .Skip(skip)
                    .Take(take)
                    .ToListAsync();
                //2 case:
                if (stages != null && inCrease)
                    //make change from right to left
                    for (int i = 0; i < stages.Count; i++)
                        stages[i].Order++;
                else
                    //make change from left to right
                    for (int i = 0; i < stages.Count; i++)
                        stages[i].Order--;

                // execute order update for current state
                var currentStage = await _context.Stages.FirstOrDefaultAsync(stage => stage.Order == curentPos);
                currentStage.Order = newPos;
                //add current state vô states ở trên
                // add current stage to list stage
                stages.Add(currentStage);
                //update db
                _context.Stages.UpdateRange(stages);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Stages. Method: UpdateListOrder. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public async Task<Stage> GetStageById(Guid id)
        {
            try
            {
                var stage = await _context.Stages
                    .FirstOrDefaultAsync(stage => stage.Id == id && stage.isDeleted == EnumStatus.False);
                return stage;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Stages. Method: GetStageById. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public async Task<IList<StageVM>> GetStageByProjectId(Guid id_Project)
        {
            try
            {
                var stages = await _context.Stages
                    .Where(stage => stage.Id_Project == id_Project && stage.isDeleted == EnumStatus.False)
                    .OrderBy(stage => stage.Order)
                    .Select(tg => new StageVM(tg.Id, tg.Id_Project, tg.Stage_Name, tg.Id_Creator,
                    tg.DateCreated, tg.UpdateDate, tg.Id_Updator, tg.Order, tg.isDone, tg.isDefault))
                    .ToListAsync();
                return stages;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Stages. Method: GetStageByProjectId. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
        public async Task<bool> UpdateStage(Stage stage)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Stages.Update(stage);
                    await _context.SaveChangesAsync();
                    // sent notif 
                    _notifService.PSS_SendNotif(stage.Id_Project, stage.Id_Updator, $"{_userService.GetUserbyId(stage.Id_Updator).UserName} has been updated Stage {stage.Stage_Name} in Project {GetProjectById(stage.Id_Project).Name}");
                    await tran.CommitAsync();
                    return true;
                }
                catch (Exception e)
                {
                    await tran.RollbackAsync();
                    _logger.LogInformation($"Controller: Stages. Method: UpdateStage. Marvic Error: {e}");
                    throw new MarvicException($"Error: {e}");
                }
            }
        }
        private Project_ViewModel GetProjectById(Guid Id)
        {
            try
            {
                var proj = (from p in _context.Projects
                            join u in _context.App_Users on p.Id_Lead equals u.Id
                            where p.Id.Equals(Id)
                            select new Project_ViewModel()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Key = p.Key,
                                Access = p.Access,
                                Lead = u.UserName,
                                Id_Creator = p.Id_Creator,
                                DateCreated = p.DateCreated,
                                DateStarted = p.DateStarted,
                                DateEnd = p.DateEnd,
                                Id_Updator = p.Id_Updator,
                                UpdateDate = p.UpdateDate,
                                IsStared = p.IsStared
                            }).FirstOrDefault();

                if (proj == null)
                    throw new MarvicException($"Cannot find the project with id: {Id}");

                return proj;
            }
            catch (Exception e)
            {

                _logger.LogInformation($"Controller: Project. Method: GetProjectById. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }

    }
}
