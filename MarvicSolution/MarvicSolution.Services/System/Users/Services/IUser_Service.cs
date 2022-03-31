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
        Task<string> Authenticate(Login_Request rq);
        Task<bool> Register(Register_Request rq);
    }
}
