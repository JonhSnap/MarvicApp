using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.Services.Issue_Request.Dtos.ViewModels.Board
{
    public class Assignee
    {
        public Guid? Id { get; set; }
        public string? FullName { get; set; }
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? JobTitle { get; set; }
        public string? Department { get; set; }
        public string? Organization { get; set; }
        public string? PhoneNumber { get; set; }
        public BoardViewModel? Item { get; set; }
        public Assignee()
        {

        }
        public Assignee(Guid? id, string? fullName, string? userName, string? email, string? jobTitle, string? department, string? organization, string? phoneNumber, BoardViewModel? item)
        {
            Id = id;
            FullName = fullName;
            UserName = userName;
            Email = email;
            JobTitle = jobTitle;
            Department = department;
            Organization = organization;
            PhoneNumber = phoneNumber;
            Item = item;
        }
    }
}
