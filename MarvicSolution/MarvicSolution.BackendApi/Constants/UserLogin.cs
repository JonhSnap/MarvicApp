using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarvicSolution.BackendApi.Constants
{
    public static class UserLogin
    {
        public static Guid Id;
        public static string Username;

        public static void SetInfo(App_User user)
        {
            Id = user.Id;
            Username = user.UserName;            
        }
    }
}
