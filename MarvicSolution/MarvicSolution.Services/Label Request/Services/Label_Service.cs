using MarvicSolution.DATA.EF;
using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Label_Request.ViewModels;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Label_Request.Services
{
    public class Label_Service : ILabel_Service
    {
        private readonly MarvicDbContext _context;
        private readonly ILogger<Label_Service> _logger;

        public Label_Service(MarvicDbContext context, ILogger<Label_Service> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<bool> AddLabel(Label label)
        {
            try
            {
                _context.Labels.Add(label);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Label. Method: AddLabel. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<Label> GetLabelById(Guid id)
        {
            try
            {
                var label = await _context.Labels
                    .FirstOrDefaultAsync(lb => lb.Id == id && lb.isDeleted == EnumStatus.False);
                return label;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Label. Method: GetLabelById. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }

        public async Task<IList<LabelVM>> GetLabelByProjectId(Guid id_Project)
        {
            try
            {
                var labels = await _context.Labels
                    .Where(lb => lb.Id_Project == id_Project && lb.isDeleted == EnumStatus.False)
                    .Select(label => new LabelVM(label.Id, label.Id_Project, label.Name, label.Id_Creator, label.DateCreated, label.UpdateDate, label.Id_Updator))
                    .ToListAsync();
                return labels;
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Label. Method: GetLabelByProjectId. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
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
            catch (Exception e)
            {
                _logger.LogInformation($"Controller: Label. Method: UpdateLabel. Marvic Error: {e}");
                throw new MarvicException($"Error: {e}");
            }
        }
    }
}
