using MailKit.Net.Smtp;
using MailKit.Security;
using MarvicSolution.DATA.Entities;
using MarvicSolution.Services.Project_Request.Project_Resquest.Dtos.ViewModels;
using MarvicSolution.Services.SendMail_Request.Dtos.Requests;
using MarvicSolution.Services.SendMail_Request.Dtos.Settings;
using MarvicSolution.Utilities.Exceptions;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.SendMail_Request.Dtos.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings _mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }
        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();
            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach (var file in mailRequest.Attachments)
                {
                    if (file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public async Task SendWelcomeEmailAsync(WelcomeRequest request)
        {
            string resource = Resources.Resources.WelcomeTemplate;
            string MailText = resource.Replace("[username]", request.UserName).Replace("[email]", request.ToEmail);
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
            email.To.Add(MailboxAddress.Parse(request.ToEmail));
            email.Subject = $"Welcome {request.UserName}";
            var builder = new BodyBuilder();
            builder.HtmlBody = MailText;
            email.Body = builder.ToMessageBody();
            using var smtp = new SmtpClient();
            smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
            smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
            await smtp.SendAsync(email);
            smtp.Disconnect(true);
        }

        public void SendEmail(Project project, List<ProjectMailRequest> rq)
        {
            try
            {
                var key = project.Key;
                var email = new MimeMessage();
                foreach (var i_rq in rq)
                {
                    email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                    email.To.Add(MailboxAddress.Parse(i_rq.ToEmail));
                    email.Subject = "New Project has created";
                    var builder = new BodyBuilder();
                    builder.HtmlBody = $"Welcome to {project.Name} Project. You are an member of it. Link: <a href=\"http://localhost:3000/projects/board/{key} \">Click here</a>";
                    email.Body = builder.ToMessageBody();
                }
                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }
        public List<ProjectMailRequest> ConvertTo_PMRequest(List<App_User> users)
        {
            List<ProjectMailRequest> listRq = new List<ProjectMailRequest>();
            foreach (var i_user in users)
            {
                ProjectMailRequest rq = new ProjectMailRequest(i_user);
                listRq.Add(rq);
            }
            return listRq;
        }

        public void SendEmail(Project project, List<ProjectMailRequest> rq, string body)
        {
            try
            {
                var key = project.Key;
                var email = new MimeMessage();
                foreach (var i_rq in rq)
                {
                    email.Sender = MailboxAddress.Parse(_mailSettings.Mail);
                    email.To.Add(MailboxAddress.Parse(i_rq.ToEmail));
                    email.Subject = "New Project has created";
                    var builder = new BodyBuilder();
                    builder.HtmlBody = body;
                    email.Body = builder.ToMessageBody();
                }
                using var smtp = new SmtpClient();
                smtp.Connect(_mailSettings.Host, _mailSettings.Port, SecureSocketOptions.StartTls);
                smtp.Authenticate(_mailSettings.Mail, _mailSettings.Password);
                smtp.Send(email);
                smtp.Disconnect(true);
            }
            catch (Exception e)
            {
                throw new MarvicException($"Error: {e}");
            }
        }
    }
}
