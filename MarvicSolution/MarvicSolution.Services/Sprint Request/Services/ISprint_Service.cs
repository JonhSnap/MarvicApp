using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Sprint_Request.Requests;
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
        Guid AddIssuesToSprint(AddIssue_Request rq);
        bool RemoveIssuesFromSprint(RemoveIssue_Request rq);
        Task<bool> CompleteSprint(Complete_Sprint_Request complete_Sprint_Request);
    }
}
