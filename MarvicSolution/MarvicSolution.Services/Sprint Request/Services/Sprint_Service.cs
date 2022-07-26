using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Notifications_Request.Services;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos.ViewModels;
using MarvicSolution.Services.Sprint_Request.Requests;
using MarvicSolution.Services.Sprint_Request.ViewModels;
using MarvicSolution.Services.System.Users.Services;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Sprint_Request.Services
{
    public class Sprint_Service : ISprint_Service
    {
        private readonly MarvicDbContext _context;
        private readonly ILogger<Sprint_Service> _logger;
        private readonly INotifications_Service _notifService;
        private readonly IUser_Service _userService;

        public Sprint_Service(MarvicDbContext context, ILogger<Sprint_Service> logger, INotifications_Service notifService, IUser_Service userService)
        {
            _context = context;
            _logger = logger;
            _notifService = notifService;
            _userService = userService;
        }

        public Guid AddIssuesToSprint(AddIssue_Request rq)
        {
            try
            {
                var issue = _context.Issues.SingleOrDefault(i => i.Id.Equals(rq.IdIssue));
                if (issue == null)
                    throw new MarvicException($"Cannot find issue = {rq.IdIssue}");
                issue.Id_Sprint = rq.IdSprint;
                _context.SaveChanges();

                return rq.IdSprint;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Sprints.Method: AddIssuesToSprint. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<bool> AddSprint(Sprint currentSprint, Guid idUserLogin)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Sprints.Add(currentSprint);
                    await _context.SaveChangesAsync();
                    // sent notif 
                    _notifService.PSS_SendNotif(currentSprint.Id_Project, currentSprint.Id_Creator, $"{_userService.GetUserbyId(currentSprint.Id_Creator).UserName} has been created Sprint {currentSprint.SprintName} in Project {GetProjectById(currentSprint.Id_Project, idUserLogin).Name}");
                    await tran.CommitAsync();

                    return true;
                }
                catch (Exception e)
                {
                    await tran.RollbackAsync();
                    _logger.LogInformation($"Controller: Sprints.Method: AddSprint. Marvic Error: {e}");
                    throw new MarvicException($"Error: {e}");
                }
            }
        }

        public async Task<bool> CompleteSprint(Sprint currentSprint, Complete_Sprint_Request model, Guid idUserLogin)
        {
            using var transaction = _context.Database.BeginTransaction();
            try
            {
                //get id stage done in project have a complete_Sprint_Request.OldSprintId
                var stageDoneId = await _context.Stages
                                        .Where(stg => stg.Id_Project == model.CurrentProjectId &&
                                                        stg.isDone == EnumStatus.True &&
                                                        stg.isDeleted == EnumStatus.False)
                                        .Select(stage => stage.Id).FirstOrDefaultAsync();

                //get list issue undone
                var listIssueUnDone = await _context.Issues
                                            .Where(a => a.Id_Sprint == model.CurrentSprintId &&
                                                        a.IsDeleted == EnumStatus.False &&
                                                        a.Id_Stage != stageDoneId).ToListAsync();
                //get list issue has done
                var listIssueHasDone = await _context.Issues
                                            .Where(a => a.Id_Sprint == model.CurrentSprintId &&
                                                        a.IsDeleted == EnumStatus.False &&
                                                        a.Id_Stage == stageDoneId).ToListAsync();
                foreach (var item in listIssueUnDone)
                {
                    item.Id_Sprint = model.NewSprintId;
                }
                //change issue to new currentSprint
                _context.Issues.UpdateRange(listIssueUnDone);

                //Calculate issue Scores for assignee and reporter
                CalculateScores(listIssueHasDone);

                // update current sprint
                currentSprint.Update_Date = DateTime.Now;
                currentSprint.Is_Archieved = EnumStatus.True;
                currentSprint.End_Date = DateTime.Now;
                _context.Sprints.Update(currentSprint);

                await _context.SaveChangesAsync();
                // sent notif 
                _notifService.PSS_SendNotif(currentSprint.Id_Project, idUserLogin, $"{_userService.GetUserbyId(idUserLogin).UserName} has been complete Sprint {currentSprint.SprintName} in Project {GetProjectById(currentSprint.Id_Project, idUserLogin).Name}");
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Sprints.Method: CompleteSprint. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<bool> Delete(Delete_ViewModel rq, Guid idUserLogin)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    var currentSprint = _context.Sprints.Find(rq.idSprintDelete);
                    // kiểm tra currentSprint này có tồn tại issue bên trong ko
                    var issuesInSprint = _context.Issues.Where(i => i.Id_Sprint.Equals(rq.idSprintDelete)
                                                                    && i.IsDeleted.Equals(EnumStatus.False))
                                                        .Select(i => i).ToList();
                    // có thì chuyển qua chỗ mới xong moi xoa
                    if (issuesInSprint.Any())
                    {
                        foreach (var i_issue in issuesInSprint)
                            i_issue.Id_Sprint = rq.idSprintNew;
                        _context.Issues.UpdateRange(issuesInSprint);
                    }
                    // ko thì xóa luôn                
                    _context.Sprints.Remove(currentSprint);

                    var result = await _context.SaveChangesAsync() > 0;
                    // sent notif 
                    _notifService.PSS_SendNotif(currentSprint.Id_Project, idUserLogin, $"{_userService.GetUserbyId(idUserLogin).UserName} has been deleted Sprint {currentSprint.SprintName} in Project {GetProjectById(currentSprint.Id_Project, idUserLogin).Name}");
                    await tran.CommitAsync();
                    return result;
                }
                catch (Exception e)
                {
                    _logger.LogInformation($"Controller: Sprints.Method: Delete. Marvic Error: {e}");
                    throw new MarvicException($"Error: {e}");
                }
            }

        }

        public async Task<Sprint> GetSprintById(Guid id)
        {
            try
            {
                var currentSprint = await _context.Sprints.FirstOrDefaultAsync(sprt => sprt.Id == id && sprt.Is_Archieved == EnumStatus.False);
                return currentSprint;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Sprints.Method: GetSprintById. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<IList<SprintVM>> GetSprintsById_Project(Guid id_Project)
        {
            try
            {
                var sprints = await _context.Sprints
                    .Where(spr => spr.Id_Project == id_Project && spr.Is_Archieved == EnumStatus.False)
                    .Select(spr => new SprintVM(spr.Id, spr.Id_Project, spr.SprintName, spr.Id_Creator, spr.Update_Date,
                    spr.Create_Date, spr.Start_Date, spr.End_Date, spr.Is_Archieved, spr.Is_Started))
                    .ToListAsync();
                return sprints;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Sprints.Method: GetSprintsById_Project. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }

        public bool RemoveIssuesFromSprint(RemoveIssue_Request rq)
        {
            try
            {
                foreach (var i_id in rq.ListIdIssue)
                {
                    var issue = _context.Issues.SingleOrDefault(i => i.Id.Equals(i_id));
                    if (issue == null)
                        throw new MarvicException($"Cannot find issue = {i_id}");
                    issue.Id_Sprint = Guid.Empty;
                    _context.SaveChanges();
                }
                return true;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Sprints.Method: AddIssuesToSprint. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<bool> UpdateSprint(Sprint currentSprint, Guid idUserLogin)
        {
            using (IDbContextTransaction tran = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Sprints.Update(currentSprint);
                    await _context.SaveChangesAsync();
                    // sent notif 
                    if (currentSprint.Is_Started.Equals(EnumStatus.False))
                    {
                        _notifService.PSS_SendNotif(currentSprint.Id_Project, idUserLogin,
                        $"{_userService.GetUserbyId(idUserLogin).UserName} has been updated Sprint {currentSprint.SprintName} in Project {GetProjectById(currentSprint.Id_Project, idUserLogin).Name}");
                    }
                    else
                    {
                        _notifService.PSS_SendNotif(currentSprint.Id_Project, idUserLogin,
                        $"{_userService.GetUserbyId(idUserLogin).UserName} has been started Sprint {currentSprint.SprintName} in Project {GetProjectById(currentSprint.Id_Project, idUserLogin).Name}");
                    }
                    await tran.CommitAsync();

                    return true;
                }
                catch (Exception e)
                {
                    _logger.LogInformation($"Controller: Sprints.Method: UpdateSprint. Marvic Error: {e}");
                    throw new MarvicException($"Error: {e}");
                    await tran.RollbackAsync();
                }
            }
        }
        private Project_ViewModel GetProjectById(Guid idProject, Guid idUserLogin)
        {
            // This function is only used for Notif for now
            try
            {
                var proj = (from p in _context.Projects
                            join mem in _context.Members on p.Id equals mem.Id_Project
                            where p.Id.Equals(idProject)
                                    && mem.Id_User.Equals(idUserLogin)
                                    && (mem.Role.Equals(EnumRole.ProductOwner) || mem.Role.Equals(EnumRole.ProjectManager))
                            select new Project_ViewModel()
                            {
                                Id = p.Id,
                                Name = p.Name,
                                Key = p.Key,
                                Access = p.Access,
                                Lead = _userService.GetUserbyId(mem.Id_User).UserName,
                                Id_Creator = p.Id_Creator,
                                DateCreated = p.DateCreated,
                                DateStarted = p.DateStarted,
                                DateEnd = p.DateEnd,
                                Id_Updator = p.Id_Updator,
                                UpdateDate = p.UpdateDate,
                                IsStared = p.IsStared
                            }).FirstOrDefault();

                if (proj == null)
                    throw new MarvicException($"Cannot find the project with id: {idProject}");

                return proj;
            }
            catch (Exception e)
            {

                _logger.LogInformation($"Controller: Project. Method: GetProjectById. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }

        private void CalculateScores(List<Issue> listIssue)
        {
            foreach (var i_issue in listIssue)
            {
                var assignee = _context.App_Users.SingleOrDefault(u => u.Id.Equals(i_issue.Id_Assignee));
                var reporter = _context.App_Users.SingleOrDefault(u => u.Id.Equals(i_issue.Id_Reporter));
                assignee.Scores += (int)i_issue.Story_Point_Estimate;
                reporter.Scores += (int)i_issue.Story_Point_Estimate;
                _context.SaveChanges();
            }
        }
    }
}
