using MarvicSolution.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels.WorkedOn
{
    public class User_ViewModel
    {
        // sau nay them avatar thi can attachment_path va fileName
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Organization { get; set; }
        public string PhoneNumber { get; set; }

        public User_ViewModel()
        {
            Id = Guid.Empty;
            FullName = string.Empty;
            UserName = string.Empty;
            Email = string.Empty;
            JobTitle = string.Empty;
            Department = string.Empty;
            Organization = string.Empty;
            PhoneNumber = string.Empty;
        }
    }
}
