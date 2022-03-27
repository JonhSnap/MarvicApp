using MarvicSolution.Services.Group_Sample.Dtos;
using MarvicSolution.Services.Group_Sample.Module_Sample.Dtos;
using MarvicSolution.Services.Group_Sample.Module_Sample.Dtos.ViewModels;
using MarvicSolution.Services.ProjectType_Request.Dtos;
using MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest.Dtos;
using MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.ProjectType_Request.ProjectType_Resquest
{
    public interface IProjectType_Service
    {
        Task<int> Create(ProjectType_CreateRequest request);
        Task<int>  Update(ProjectType_UpdateRequest request);
        Task<int> Delete(int Id);

        Task<List<ProjectType_ViewModel>> GetAlls();
        Task<ProjectType_PageResult<ProjectType_ViewModel>> GetAllPaging(Get_ProjectType_PagingRequest request);
    }
}
