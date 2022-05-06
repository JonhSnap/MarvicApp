using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Sprint_Request.ViewModels;

namespace MarvicSolution.Services.Sprint_Request.Services
{
    public interface ISprint_Service
    {
        Task<bool> AddSprint(Sprint sprint);
        Task<bool> UpdateSprint(Sprint sprint);
        Task<bool> DeleteSprint(Sprint sprint);
        Task<IList<SprintVM>> GetSprintsById_Project(Guid id_Project);
        Task<Sprint> GetSprintById(Guid id);
    }
}
