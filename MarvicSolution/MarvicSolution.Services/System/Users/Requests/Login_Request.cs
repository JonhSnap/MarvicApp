using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.System.Users.Requests
{
    public class Login_Request
    {
        public string UserName { get; set; } // sửa lại unique
        public string Password { get; set; }
        public bool RememberMe { get; set; }

    }
}
