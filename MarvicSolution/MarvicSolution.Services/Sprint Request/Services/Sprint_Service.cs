using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Sprint_Request.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Sprint_Request.Services
{
    public class Sprint_Service : ISprint_Service
    {
        private readonly MarvicDbContext _context;

        public Sprint_Service(MarvicDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddSprint(Sprint sprint)
        {
            try
            {
                _context.Sprints.Add(sprint);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // log here...
                return false;
                throw;
            }
        }

        public async Task<bool> DeleteSprint(Sprint sprint)
        {
            try
            {
                _context.Sprints.Update(sprint);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                // log here...
                return false;
                throw;
            }
        }

        public async Task<Sprint> GetSprintById(Guid id)
        {
            try
            {
                var sprint = await _context.Sprints.FirstOrDefaultAsync(sprt=> sprt.Id==id && sprt.Is_Delete==EnumStatus.False);
                return sprint;
            }
            catch (Exception ex)
            {
                // log here...
                throw;
            }
        }

        public async Task<IList<SprintVM>> GetSprintsById_Project(Guid id_Project)
        {
            try
            {
                var sprints = await _context.Sprints
                    .Where(spr => spr.Id_Project == id_Project && spr.Is_Delete == EnumStatus.False)
                    .Select(spr => new SprintVM(spr.Id, spr.Id_Project, spr.SprintName, spr.Id_Creator, spr.Update_Date, spr.Create_Date, spr.Start_Date, spr.End_Date))
                    .ToListAsync();
                return sprints;
            }
            catch (Exception ex)
            {
                // log here...
                throw;
            }
        }

        public async Task<bool> UpdateSprint(Sprint sprint)
        {
            try
            {
                _context.Sprints.Update(sprint);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                ///ghi log
                return false;
                throw;
            }
        }

    }
}
