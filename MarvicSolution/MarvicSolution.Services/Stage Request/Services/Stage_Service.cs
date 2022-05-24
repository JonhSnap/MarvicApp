using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Stage_Request.Requests;
using MarvicSolution.Services.Stage_Request.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Stage_Request.Services
{
    public class Stage_Service : IStage_Service
    {
        private readonly MarvicDbContext _context;
        public Stage_Service(MarvicDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddStage(Stage stage)
        {
            try
            {
                _context.Stages.Add(stage);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //log here...
                return false;
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
                return await _context.Stages.AnyAsync(stage => stage.Stage_Name == stageName);
            }
            catch (Exception ex)
            {
                //log here...
                return false;
            }
        }

        public async Task<bool> DeleteStage(Stage stage, Remove_Stage_Request modelRequest)
        {
            using var transaction = _context.Database.BeginTransaction();
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
                //remvoe stage
                _context.Update(stage);
                //asign list issue in current stage into new stage
                var listIssueInCurrentStage = await _context.Issues
                    .Where(isu => isu.Id_Stage == stage.Id && isu.IsDeleted == EnumStatus.False)
                    .ToListAsync();
                if (listIssueInCurrentStage.Count != 0)
                {
                    foreach (var id_issue in listIssueInCurrentStage)
                    {
                        id_issue.Id_Stage = modelRequest.Dorward_Id_Stage;
                    }
                    _context.Issues.UpdateRange(listIssueInCurrentStage);

                }
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                //log here...
                return false;
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
                return await UpdateListOrder(skip, take, curentPos, newPos, id_Project, range > 0);
            }
            catch (Exception ex)
            {
                //log here...
                return false;
            }
        }

        private async Task<bool> Swap(int curentPos, int newPos, Guid id_Project)
        {
            var currentStage = await _context.Stages.FirstOrDefaultAsync(stage => stage.Id_Project == id_Project && stage.Order == curentPos);
            currentStage.Order = newPos;
            var newStage = await _context.Stages.FirstOrDefaultAsync(stage => stage.Id_Project == id_Project && stage.Order == newPos);
            newStage.Order = curentPos;
            _context.Stages.UpdateRange(new[] { currentStage, newStage });
            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<bool> UpdateListOrder(int skip, int take, int curentPos, int newPos, Guid id_Project, bool inCrease = true)
        {
            var stages = await _context.Stages
                .Where(stage => stage.Id_Project == id_Project)
                .OrderBy(s => s.Order)
                .Skip(skip)
                .Take(take)
                .ToListAsync();
            if (stages != null && inCrease)
            {
                for (int i = 0; i < stages.Count; i++)
                {
                    stages[i].Order++;
                }
            }
            else
            {
                for (int i = 0; i < stages.Count; i++)
                {
                    stages[i].Order--;
                }
            }
            var currentStage = await _context.Stages.FirstOrDefaultAsync(stage => stage.Order == curentPos);
            currentStage.Order = newPos;
            stages.Insert(newPos, currentStage);
            _context.Stages.UpdateRange(stages);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Stage> GetStageById(Guid id)
        {
            try
            {
                var stage = await _context.Stages
                    .FirstOrDefaultAsync(stage => stage.Id == id && stage.isDeleted == EnumStatus.False);
                return stage;
            }
            catch (Exception ex)
            {
                //log here...
                return null;
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
            catch (Exception ex)
            {
                //log here...
                return null;
            }
        }

        public async Task<bool> UpdateStage(Stage stage)
        {
            try
            {
                _context.Stages.Update(stage);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //log here...
                return false;
            }
        }
    }
}
