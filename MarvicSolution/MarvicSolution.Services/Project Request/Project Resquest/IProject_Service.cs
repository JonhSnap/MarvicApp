using MarvicSolution.DATA.Entities;
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
        Task<Guid> Create(Project_CreateRequest request);
        Task<Guid>  Update(Project_UpdateRequest request);
        Task<Guid> Delete(Guid Id);

        Task<List<Project_ViewModel>> GetAlls();
        List<Project_ViewModel> GetProjectByIdUser(Guid IdUser);
        Project_ViewModel GetProjectById(Guid Id);
        Task<List<Project_ViewModel>> Groupby_ProjectType_Tscript(Guid projType_Id);
        Task<Project_PageResult<Project_ViewModel>> GetAllPaging(Get_Project_PagingRequest request);
    }
}
