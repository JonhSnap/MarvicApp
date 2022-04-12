using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarvicSolution.Services.System.Users.ViewModel
{
    public class UserLogin_VM
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        [JsonIgnore] // Prevent to send password to browser by json
        public string Password { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Organization { get; set; }
        public string PhoneNumber { get; set; }
        //public EnumRole Role { get; set; }
        public string Role { get; set; } = "Project Manager";

        public UserLogin_VM(App_User user)
        {
            this.Id = user.Id;
            this.FullName = user.FullName;
            this.UserName = user.UserName;
            this.Password = user.Password;
            this.Email = user.Email;
            this.JobTitle = user.JobTitle;
            this.Department = user.Department;
            this.Organization = user.Organization;
            this.PhoneNumber = user.PhoneNumber;
        }
    }
}
