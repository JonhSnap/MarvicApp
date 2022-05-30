using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Issue_Request.Dtos.ViewModels;
using MarvicSolution.Services.System.Users.Requests;
using MarvicSolution.Services.System.Users.View_Model;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MarvicSolution.Services.System.Users.Services
{
    public interface IUser_Service
    {
        string GetJwt(Login_Request rq, App_User user);
        bool Register(Register_Request rq);
        Task<Guid> Create(Create_User_Request rq);
        Guid Update(Update_User_Request rq);
        Guid RecoveryPassword(RecoveryPassword_Request rq);
        Guid UpdatePassword(RecoveryPassword_Request rq);
        Guid Delete(Guid Id);
        App_User GetUserbyId(Guid Id);
        User_ViewModel GetUserbyIdVM(Guid Id, RequestVM rqVM);
        App_User GetUserbyUserName(string userName);
        User_ViewModel GetUserbyUserNameVM(string userName, RequestVM rqVM);
        void UploadAvatar(IFormFile file);
        bool DeleteUserAvatar(string fileName);
    }
}
