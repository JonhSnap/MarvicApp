using MarvicSolution.DATA.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Entities
{
    public class App_User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        [JsonIgnore] // Prevent to send password to browser by json
        public string Password { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Organization { get; set; }
        public string PhoneNumber { get; set; }
        public EnumStatus IsDeleted { get; set; } = EnumStatus.False;

        public App_User()
        {
            Id = new Guid();
            FullName = string.Empty;
            UserName = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            JobTitle = string.Empty;
            Department = string.Empty;
            Organization = string.Empty;
            PhoneNumber = string.Empty;
            IsDeleted = EnumStatus.False;
            Avatar = string.Empty;
        }
    }
}
