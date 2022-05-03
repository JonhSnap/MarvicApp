using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos.ViewModels;
using MarvicSolution.Services.SendMail_Request.Dtos.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.SendMail_Request.Dtos.Services
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
        Task SendWelcomeEmailAsync(WelcomeRequest request);
        void SendEmail(Project project, List<ProjectMailRequest> rq, string body);
        List<ProjectMailRequest> ConvertTo_PMRequest(List<App_User> users);
    }
}
