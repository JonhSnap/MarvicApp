using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Stage_Request.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Stage_Request.Services
{
    public interface IStage_Service
    {
        Task<bool> AddStage(Stage stage);
        Task<bool> UpdateStage(Stage stage);
        Task<Stage> GetStageById(Guid id);
        Task<IList<StageVM>> GetStageByProjectId(Guid id_Project);
    }
}
