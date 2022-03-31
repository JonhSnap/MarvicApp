using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.System.Users.Requests
{
    public class Register_Request
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        //public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Organization { get; set; }
    }
}
