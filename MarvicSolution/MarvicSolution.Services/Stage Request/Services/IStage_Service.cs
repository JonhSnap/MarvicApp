using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Stage_Request.Requests;
using MarvicSolution.Services.Stage_Request.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Stage_Request.Services
{
    public interface IStage_Service
    {
        Task<bool> AddStage(Stage stage);
        Task<bool> DragAndDrop(int currentPos, int newPos, Guid id_Project);
        Task<bool> UpdateStage(Stage stage);
        Task<bool> DeleteStage(Stage stage, Remove_Stage_Request modelRequest);
        Task<Stage> GetStageById(Guid id);
        Task<IList<StageVM>> GetStageByProjectId(Guid id_Project);
        Task<bool> CheckExistName(string stageName, Guid id = new Guid(), string action ="create" );
    }
}
