using System;

namespace MarvicSolution.Services.System.Users.View_Model
{
    public class User_ViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public string Avatar_Path { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Organization { get; set; }
        public string PhoneNumber { get; set; }
        public int Scores { get; set; }

        public User_ViewModel()
        {
            Id = Guid.Empty;
            FullName = string.Empty;
            UserName = string.Empty;
            Avatar = string.Empty;
            Avatar_Path = string.Empty;
            Email = string.Empty;
            JobTitle = string.Empty;
            Department = string.Empty;
            Organization = string.Empty;
            PhoneNumber = string.Empty;
            Scores = 0;
        }

    }
}
