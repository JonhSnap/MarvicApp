using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Label_Request.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Label_Request.Services
{
    public interface ILabel_Service
    {
        Task<bool> AddLabel(Label label);
        Task<bool> UpdateLabel(Label label);
        Task<Label> GetLabelById(Guid id);
        Task<IList<LabelVM>> GetLabelByProjectId(Guid id_Project);
    }
}
