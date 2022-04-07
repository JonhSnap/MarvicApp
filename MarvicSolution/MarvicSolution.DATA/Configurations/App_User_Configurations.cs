using FluentValidation;
using MarvicSolution.DATA.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarvicSolution.DATA.Configurations
{
    class App_User_Configurations : AbstractValidator<App_User>, IEntityTypeConfiguration<App_User>
    {
        /// <summary>
        /// Cac config cho Table - Fluent Api 
        /// Link: https://www.learnentityframeworkcore.com/configuration/fluent-api
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<App_User> builder)
        {
            builder.ToTable("App_User");
            builder.HasKey(o => new { o.Id });

            // Create Rules
            RuleFor(u => u.Email).NotEmpty().WithMessage("Email address is required")
                     .EmailAddress().WithMessage("A valid email is required");

            // Data Seeding
            builder.HasData(
                new App_User
                {
                    Id = new Guid("E341A8F6-DC1B-4829-94FB-316B6BAC99B6"),
                    FullName = "Nguyen Duy Khanh",
                    UserName = "KhanhND",
                    Password = "$2a$11$D57iJclK1BhZgg9B0P4I2.9sq0MoQIRImA8YeDVvbxeKPNG/KuTMK", //pass: KhanhND123@                    
                    Email = "khanhnd@gmail.com",
                    JobTitle = "Project Manager",
                    Department = "Khoang 1 HN",
                    Organization = "Company TechNo1",
                    PhoneNumber = "0989878767",
                    IsDeleted = Enums.EnumStatus.False
                },
                new App_User
                {
                    Id = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"),
                    FullName = "Tran Thien Nhan",
                    UserName = "NhanTT",
                    Password = "$2a$11$MjbSthPb/xXnLsaNnJDVE.GGHoWL9aPMqLzCXTmoVs1HoHBqLsuWq", // pass NhanTT123@
                    Email = "nhantt@gmail.com",
                    JobTitle = "Member Job Title",
                    Department = "Khoang 2 HCM",
                    Organization = "Company PizzaHub",
                    PhoneNumber = "0336355563",
                    IsDeleted = Enums.EnumStatus.False
                },
                new App_User
                {
                    Id = new Guid("7A370BAC-B796-454D-84CF-18C603102CA2"),
                    FullName = "Tran Thanh Nhan",
                    UserName = "NhanTTT1",
                    Password = "$2a$11$IM2wFUFnOP.TYaxfqYjEluUatAmE95HIFZcElLoLGRmdUYkBFujCm", // pass NhanTTT1Cute@ | Update HelloFromTheOtherSide
                    Email = "nhant1@gmail.com",
                    JobTitle = "Director",
                    Department = "Khoang 10 DN",
                    Organization = "Company Marketing Hanzu",
                    PhoneNumber = "0345677456",
                    IsDeleted = Enums.EnumStatus.False
                }
                );
        }
    }
}
