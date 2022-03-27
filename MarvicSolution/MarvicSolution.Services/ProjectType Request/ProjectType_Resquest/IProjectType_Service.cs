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
        // INPUT
        Task<Guid> Create(ProjectType_CreateRequest request);
        Task<Guid> Update(ProjectType_UpdateRequest request);
        Task<Guid> Delete(Guid Id);

        // OUTPUT
        Task<List<ProjectType_ViewModel>> GetAlls();
        Task<ProjectType_PageResult<ProjectType_ViewModel>> GetAllPaging(Get_ProjectType_PagingRequest request);
    }
}
