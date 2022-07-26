using MarvicSolution.DATA.Entities;
using MarvicSolution.DATA.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace MarvicSolution.DATA.Configurations
{
    class App_User_Configurations : IEntityTypeConfiguration<App_User>
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
            builder.HasIndex(o => o.UserName).IsUnique();
            builder.HasIndex(o => o.Password).IsUnique();
            builder.Property(prop => prop.Email).IsRequired();
            builder.Property(prop => prop.PhoneNumber).IsRequired();

            // Data Seeding
            builder.HasData(
                new App_User
                {
                    Id = new Guid("E341A8F6-DC1B-4829-94FB-316B6BAC99B6"),
                    FullName = "Nguyen Duy Khanh",
                    UserName = "KhanhND",
                    Avatar = "",
                    Password = "$2a$11$D57iJclK1BhZgg9B" +
                    "0P4I2.9sq0MoQIRImA8YeDVvbxeKPNG/KuTMK", //pass: KhanhND123@ | Email = "khanhnd@gmail.com",
                    Email = "khanhnd@gmail.com",
                    JobTitle = "Project Manager",
                    Department = "Khoang 1 HN",
                    Organization = "Company TechNo1",
                    PhoneNumber = "0989878767",
                    IsDeleted = EnumStatus.False,
                    Scores = 3,
                    IsFirstLogin = EnumStatus.True
                },
                new App_User
                {
                    Id = new Guid("346F2520-6295-4734-8868-6CA75258E7C1"),
                    FullName = "Tran Thien Nhan",
                    UserName = "NhanTT",
                    Avatar = "",
                    Password = "$2a$11$MjbSthPb/xXnLsaNnJDV" +
                    "E.GGHoWL9aPMqLzCXTmoVs1HoHBqLsuWq", // pass NhanTT123@
                    Email = "nhantt@gmail.com",
                    JobTitle = "Member Job Title",
                    Department = "Khoang 2 HCM",
                    Organization = "Company PizzaHub",
                    PhoneNumber = "0336355563",
                    IsDeleted = EnumStatus.False,
                    Scores = 3,
                    IsFirstLogin = EnumStatus.True
                },
                new App_User
                {
                    Id = new Guid("7A370BAC-B796-454D-84CF-18C603102CA2"),
                    FullName = "Tran Thanh Nhan",
                    UserName = "NhanTTT1",
                    Avatar = "",
                    Password = "$2a$11$IM2wFUFnOP.TYaxfqY" +
                    "jEluUatAmE95HIFZcElLoLGRmdUYkBFujCm", // pass NhanTTT1Cute@ | Update HelloFromTheOtherSide
                    Email = "nhant1@gmail.com",
                    JobTitle = "Director",
                    Department = "Khoang 10 DN",
                    Organization = "Company Marketing Hanzu",
                    PhoneNumber = "0345677456",
                    IsDeleted = EnumStatus.False,
                    Scores = 3,
                    IsFirstLogin = EnumStatus.True
                }
                // New 5 user
                //=======================================
                ,
                new App_User
                {
                    Id = new Guid("EC32BFFD-121F-405F-B7C5-5E2AB4BA7E27"),
                    FullName = "Phan Thanh Khiet",
                    UserName = "KhietPT",
                    Avatar = "442b6b8c-db31-4bc3-88ac-901d95d33e90_uwp2338826.jpeg",
                    Password = @"$2a$12$d5mRmftqnckozmamy17PDefhN9OxdlssO2zN4UvDBbDlNF08wk176", // pass KhietPT@123
                    Email = "thanhkhiet1999brvt@gmail.com",
                    JobTitle = "Product Onwer",
                    Department = "Toa G Block A",
                    Organization = "Company International Z",
                    PhoneNumber = "0213515845",
                    IsDeleted = EnumStatus.False,
                    Scores = 85,
                    IsFirstLogin = EnumStatus.True
                },
                new App_User
                {
                    Id = new Guid("3413ED48-771A-4533-91B0-8C19CD863E2F"),
                    FullName = "Vo Duy Thang",
                    UserName = "ThangVD",
                    Avatar = "48ec4f70-ab49-41c8-b9ce-199054cb6baf_wp4461255-apple-ipad-pro-wallpapers.jpg",
                    Password = @"$2a$12$bTnbEkHdZ9./UutRXu2c2eiF5GwtTDYkOsjIfLB8lKTAJbXDRSk2.", // pass ThangVD@123
                    Email = "19130203@st.hcmuaf.edu.vn",
                    JobTitle = "Product Onwer",
                    Department = "Toa G Block B",
                    Organization = "Company International B",
                    PhoneNumber = "0321235648",
                    IsDeleted = EnumStatus.False,
                    Scores = 39,
                    IsFirstLogin = EnumStatus.True
                },
                new App_User
                {
                    Id = new Guid("71FBD467-6496-412C-B6FA-B461CAB6DD05"),
                    FullName = "Le Quoc Thinh",
                    UserName = "ThinhLQ",
                    Avatar = "",
                    Password = @"$2a$12$aTvfHwnaGNGRMdS3xAvse.VcC/KdRVFxwVtJlkfJDJFL0fYFTUH7i", // pass ThinhLQ@123
                    Email = "19130215@st.hcmuaf.edu.vn",
                    JobTitle = "Product Onwer",
                    Department = "Toa G Block C",
                    Organization = "Company International C",
                    PhoneNumber = "5687956148",
                    IsDeleted = EnumStatus.False,
                    Scores = 46,
                    IsFirstLogin = EnumStatus.True
                },
                new App_User
                {
                    Id = new Guid("D6C6033A-89E4-4217-B33B-95EE39EC4C5C"),
                    FullName = "Nguyen Thanh Nhan",
                    UserName = "NhanNT",
                    Avatar = "a0b9365b-462f-4670-b530-11c9860e6eae_scott-goodwill-y8Ngwq34_Ak-unsplash.jpg",
                    Password = @"$2a$12$PxNXwTisjUP2sugrcRFc/.pZcTpnsQzfBABlBYjnE428tyUj874BC", // pass NhanNT@123
                    Email = "NhanNT@gmail.com",
                    JobTitle = "Product Onwer",
                    Department = "Toa G Block D",
                    Organization = "Company International D",
                    PhoneNumber = "1266587859",
                    IsDeleted = EnumStatus.False,
                    Scores = 17,
                    IsFirstLogin = EnumStatus.True
                },
                new App_User
                {
                    Id = new Guid("A21973B7-EB51-4141-A7F8-BE3E9071BF9A"),
                    FullName = "Nguyen Van Tung",
                    UserName = "TungNV",
                    Avatar = "baa8835e-063e-4ab0-a920-6ee307579fbe_uwp2338823.png",                    
                    Password = @"$2a$12$0RoG8q7DjIv8yV3HKrzNqOh52lgNIRGiARNXghEM84GhFtP.P/.52", // pass TungNV@123
                    Email = "19130260@st.hcmuaf.edu.vn",
                    JobTitle = "Product Onwer",
                    Department = "Toa G Block E",
                    Organization = "Company International E",
                    PhoneNumber = "0326598452",
                    IsDeleted = EnumStatus.False,
                    Scores = 85,
                    IsFirstLogin = EnumStatus.True
                }

                );
        }
    }
}
