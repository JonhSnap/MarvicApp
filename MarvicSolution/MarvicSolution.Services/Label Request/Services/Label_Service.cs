using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Label_Request.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Label_Request.Services
{
    public class Label_Service : ILabel_Service
    {
        private readonly MarvicDbContext _context;

        public Label_Service(MarvicDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddLabel(Label label)
        {
            try
            {
                _context.Labels.Add(label);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                //log here...
                return false;
            }
        }

        public async Task<Label> GetLabelById(Guid id)
        {
            try
            {
                var label = await _context.Labels
                    .FirstOrDefaultAsync(lb=>lb.Id==id && lb.isDeleted==EnumStatus.False);
                return label;
            }
            catch (Exception ex)
            {
                //log here...
                return null;
            }
        }

        public async Task<IList<LabelVM>> GetLabelByProjectId(Guid id_Project)
        {
            try
            {
                var labels = await _context.Labels
                    .Where(lb => lb.Id_Project == id_Project && lb.isDeleted == EnumStatus.False)
                    .Select(label=>new LabelVM(label.Id,label.Id_Project,label.Name,label.Id_Creator,label.DateCreated,label.UpdateDate,label.Id_Updator))
                    .ToListAsync();
                return labels;
            }
            catch (Exception ex)
            {
                //log here...
                return null;
            }
        }

        public async Task<bool> UpdateLabel(Label label)
        {
            try
            {
                _context.Labels.Update(label);
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
