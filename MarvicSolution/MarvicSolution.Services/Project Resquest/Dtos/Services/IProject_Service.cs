using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos.ViewModels;
using MarvicSolution.Services.Project_Resquest.Dtos.Requests;
using MarvicSolution.Services.Project_Resquest.Dtos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Project_Request.Project_Resquest
{
    public interface IProject_Service
    {
        Task<Guid> Create(Guid idUser, Project_CreateRequest request);
        Task<Guid> Update(Guid idUser, Project_UpdateRequest request);
        Task<Guid> Delete(Guid Id, Guid idUserLogin);

        Guid GetIdUserByUserName(string userName);
        List<Guid> Get_All_IdMembers();
        List<Guid> Get_IdMembers_By_IdProject(Guid IdProject);
        List<string> Get_UserNames_By_Ids(List<Guid> ListIdMember);
        List<string> Get_List_UserName_Can_Added_By_IdProject(Guid IdProject);
        List<App_User> GetAllMembersByIdProject(Guid idProject);
        Project_ViewModel GetProjectById(Guid Id);
        List<Member_ViewModel> Get_AllMembers_By_IdProject(Guid IdProject, RequestVM rqVM);
        List<Project_ViewModel> GetProjectByIdUser(Guid IdUser);
        Task<List<Project_ViewModel>> GetAlls();
        Guid AddMembers(Guid IdProject, List<string> userNames, Guid idUserLogin, int role);
        Guid Remove_Member_From_Project(Guid IdProject, Guid IdUser, Guid IdUserLogin);
        List<Project> GetStarredProject(Guid idUserLogin);
        EnumStatus ChangeStatusMember(ChangeStatusMember_Request rq);
        Task<bool> UpdateStarredProject(UpdateStarredProject_Request rq);
        SetUserRoleByIdProject_ViewModel SetUserRoleByIdProject(SetUserRoleByIdProject_Request rq);
    }
}
