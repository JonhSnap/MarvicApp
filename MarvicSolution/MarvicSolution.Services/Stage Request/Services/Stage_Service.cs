using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
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
                    .Select(tg => new StageVM(tg.Id, tg.Id_Project, tg.Stage_Name, tg.Id_Creator, tg.DateCreated, tg.UpdateDate, tg.Id_Updator, tg.Order))
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
