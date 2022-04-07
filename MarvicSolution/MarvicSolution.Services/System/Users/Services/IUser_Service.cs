using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.System.Users.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.System.Users.Services
{
    public interface IUser_Service
    {
        string Authenticate(Login_Request rq);
        Task<bool> Register(Register_Request rq);
        //App_User GetUserbyUserName(Login_Request rq);
        App_User GetUserbyUserName(string userName);
        Task<App_User> GetUserbyId(Guid rq);
        Task<Guid> Create(Create_User_Request rq);
        Guid Update(Update_User_Request rq);
        Guid RecoveryPassword(RecoveryPassword_Request rq);
        Guid UpdatePassword(RecoveryPassword_Request rq);
        Guid Delete(Guid Id);
    }
}
