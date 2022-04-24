using MarvicSolution.DATA.Entities;
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
        Task<Guid> Update(Project_UpdateRequest request);
        Task<Guid> Delete(Guid Id);

        Task<List<Project_ViewModel>> GetAlls();
        List<Project_ViewModel> GetProjectByIdUser(Guid IdUser);
        Project_ViewModel GetProjectById(Guid Id);
        Task<List<Project_ViewModel>> Groupby_ProjectType_Tscript(Guid projType_Id);

        Guid GetIdUserByUserName(string userName);
        Guid AddMembers(Guid IdProject, List<string> userNames);
        List<Guid> Get_IdMembers_By_IdProject(Guid IdProject);
        List<Member_ViewModel> Get_AllMembers_By_IdProject(Guid IdProject);
        List<Guid> Get_All_IdMembers();
        List<string> Get_UserNames_By_Ids(List<Guid> ListIdMember);
        List<string> Get_List_UserName_Can_Added_By_IdProject(Guid IdProject);
        Guid Remove_Member_From_Project(Guid IdProject, Guid IdUser);

    }
}
