using MarvicSolution.DATA.Enums;
using System;

namespace MarvicSolution.Services.Project_Request.Project_Resquest.Dtos.ViewModels
{
    public class Member_ViewModel
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string Organization { get; set; }
        public string PhoneNumber { get; set; }
        public string Avatar { get; set; }
        public string Avatar_Path { get; set; }
        public int Scores { get; set; }
        public EnumStatus IsActive { get; set; }

        public Member_ViewModel()
        {
            Id = Guid.Empty;
            FullName = string.Empty;
            UserName = string.Empty;
            Email = string.Empty;
            JobTitle = string.Empty;
            Department = string.Empty;
            Organization = string.Empty;
            PhoneNumber = string.Empty;
            Avatar = string.Empty;
            Avatar_Path = string.Empty;
            Scores = 0;
            IsActive = EnumStatus.False;
        }

        public Member_ViewModel(Guid id, string fullName, string userName, string email, string jobTitle, string department, string organization, string phoneNumber, string avatar, string avatar_Path, int scores, EnumStatus isActive)
        {
            Id = id;
            FullName = fullName;
            UserName = userName;
            Email = email;
            JobTitle = jobTitle;
            Department = department;
            Organization = organization;
            PhoneNumber = phoneNumber;
            Avatar = avatar;
            Avatar_Path = avatar_Path;
            Scores = scores;
            IsActive = isActive;
        }
    }
}
