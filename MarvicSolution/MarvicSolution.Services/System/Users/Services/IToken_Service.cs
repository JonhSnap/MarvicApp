using MarvicSolution.Services.System.Users.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.System.Users.Services
{
    public interface IToken_Service
    {
        string BuildToken(string key, string issuer, UserLogin_VM user);
        bool IsValidateToken(string key, string issuer, string token);
    }
}
