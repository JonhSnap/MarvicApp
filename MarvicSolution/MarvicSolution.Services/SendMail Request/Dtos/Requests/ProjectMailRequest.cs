using MarvicSolution.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.SendMail_Request.Dtos.Requests
{
    public class ProjectMailRequest
    {
        public string ToEmail { get; set; }
        public string UserName { get; set; }
        public ProjectMailRequest(App_User user)
        {
            this.ToEmail = user.Email;
            this.UserName = user.UserName;
        }
    }
}
