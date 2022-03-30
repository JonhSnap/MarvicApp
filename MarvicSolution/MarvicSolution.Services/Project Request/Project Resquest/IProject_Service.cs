using MarvicSolution.Services.Project_Request.Dtos;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Project_Request.Project_Resquest
{
    public interface IProject_Service
    {
        Task<int> Create(Project_CreateRequest request);
        Task<int>  Update(Project_UpdateRequest request);
        Task<Guid> Delete(Guid Id);

        Task<List<Project_ViewModel>> GetAlls();
        Task<Project_PageResult<Project_ViewModel>> GetAllPaging(Get_Project_PagingRequest request);
    }
}
