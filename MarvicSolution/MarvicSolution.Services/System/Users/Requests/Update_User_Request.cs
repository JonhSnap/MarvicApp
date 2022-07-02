using MarvicSolution.DATA.Enums;
using System;

namespace MarvicSolution.Services.System.Users.Requests
{
    public class Update_User_Request
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Organization { get; set; }
        public string PhoneNumber { get; set; }
        public int IsFirstLogin { get; set; }
    }
}
