﻿// <auto-generated />
using System;
using MarvicSolution.DATA.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MarvicSolution.DATA.Migrations
{
    [DbContext(typeof(MarvicDbContext))]
    [Migration("20220412153005_add-memeber")]
    partial class addmemeber
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.12")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MarvicSolution.DATA.Entities.App_User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Department")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<string>("JobTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("App_User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"),
                            Department = "Khoang 1 HN",
                            FullName = "Nguyen Duy Khanh",
                            IsDeleted = 0,
                            JobTitle = "Project Manager",
                            Organization = "Company TechNo1",
                            Password = "$2a$11$D57iJclK1BhZgg9B0P4I2.9sq0MoQIRImA8YeDVvbxeKPNG/KuTMK",
                            PhoneNumber = "0989878767",
                            UserName = "KhanhND"
                        },
                        new
                        {
                            Id = new Guid("346f2520-6295-4734-8868-6ca75258e7c1"),
                            Department = "Khoang 2 HCM",
                            Email = "nhantt@gmail.com",
                            FullName = "Tran Thien Nhan",
                            IsDeleted = 0,
                            JobTitle = "Member Job Title",
                            Organization = "Company PizzaHub",
                            Password = "$2a$11$MjbSthPb/xXnLsaNnJDVE.GGHoWL9aPMqLzCXTmoVs1HoHBqLsuWq",
                            PhoneNumber = "0336355563",
                            UserName = "NhanTT"
                        },
                        new
                        {
                            Id = new Guid("7a370bac-b796-454d-84cf-18c603102ca2"),
                            Department = "Khoang 10 DN",
                            Email = "nhant1@gmail.com",
                            FullName = "Tran Thanh Nhan",
                            IsDeleted = 0,
                            JobTitle = "Director",
                            Organization = "Company Marketing Hanzu",
                            Password = "$2a$11$IM2wFUFnOP.TYaxfqYjEluUatAmE95HIFZcElLoLGRmdUYkBFujCm",
                            PhoneNumber = "0345677456",
                            UserName = "NhanTTT1"
                        });
                });

            modelBuilder.Entity("MarvicSolution.DATA.Entities.Issue", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Attachment_Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateStarted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("Id_Assignee")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Creator")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Id_IssueType")
                        .HasColumnType("int");

                    b.Property<Guid>("Id_Label")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Linked_Issue")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Parent_Issue")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Project")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Reporter")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Restrict")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Sprint")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Stage")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Updator")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<int>("IsFlagged")
                        .HasColumnType("int");

                    b.Property<int>("IsWatched")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<int>("Story_Point_Estimate")
                        .HasColumnType("int");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Issue");

                    b.HasData(
                        new
                        {
                            Id = new Guid("bb2b349b-1075-45ca-96de-9f709a678eb0"),
                            Attachment_Path = "",
                            DateCreated = new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateEnd = new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateStarted = new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Des epic Project A",
                            Id_Assignee = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Creator = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_IssueType = 1,
                            Id_Label = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Linked_Issue = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Parent_Issue = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Project = new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"),
                            Id_Reporter = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Restrict = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Stage = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Updator = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = 0,
                            IsFlagged = 0,
                            IsWatched = 0,
                            Priority = 5,
                            Story_Point_Estimate = 8,
                            Summary = "The epic of Project A",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("7c2cc804-4aae-4af2-9191-4268fc02edc0"),
                            Attachment_Path = "",
                            DateCreated = new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateEnd = new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateStarted = new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Des Story of Project A",
                            Id_Assignee = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Creator = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_IssueType = 2,
                            Id_Label = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Linked_Issue = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Parent_Issue = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Project = new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"),
                            Id_Reporter = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Restrict = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Stage = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Updator = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = 0,
                            IsFlagged = 0,
                            IsWatched = 0,
                            Priority = 3,
                            Story_Point_Estimate = 9,
                            Summary = "The Story of Project A",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("edff3f58-7640-4f5a-ada0-dc017f602501"),
                            Attachment_Path = "",
                            DateCreated = new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateEnd = new DateTime(2022, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateStarted = new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Des Task1 of Project A",
                            Id_Assignee = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Creator = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_IssueType = 3,
                            Id_Label = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Linked_Issue = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Parent_Issue = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Project = new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"),
                            Id_Reporter = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Restrict = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Stage = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Updator = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = 0,
                            IsFlagged = 0,
                            IsWatched = 0,
                            Priority = 3,
                            Story_Point_Estimate = 5,
                            Summary = "The Task1 of Project A",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("24c577bb-002d-4a31-a855-ca22f0c7ca69"),
                            Attachment_Path = "",
                            DateCreated = new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateEnd = new DateTime(2022, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateStarted = new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Des Task2 of Project A",
                            Id_Assignee = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Creator = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_IssueType = 3,
                            Id_Label = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Linked_Issue = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Parent_Issue = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Project = new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"),
                            Id_Reporter = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Restrict = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Stage = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Updator = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = 0,
                            IsFlagged = 0,
                            IsWatched = 0,
                            Priority = 4,
                            Story_Point_Estimate = 2,
                            Summary = "The Task2 of Project A",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("bbbe8f8e-a735-4a4c-bded-e4ce2405e8e1"),
                            Attachment_Path = "",
                            DateCreated = new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateEnd = new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateStarted = new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Des epic of Project B",
                            Id_Assignee = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Creator = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_IssueType = 1,
                            Id_Label = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Linked_Issue = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Parent_Issue = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Project = new Guid("89fad9a0-690d-46e8-a2fe-c6cc50350eaf"),
                            Id_Reporter = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Restrict = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Stage = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Updator = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = 0,
                            IsFlagged = 0,
                            IsWatched = 0,
                            Priority = 2,
                            Story_Point_Estimate = 6,
                            Summary = "The epic of Project B",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("bffc9087-de0d-4bf8-97a1-f97a26d6fda4"),
                            Attachment_Path = "",
                            DateCreated = new DateTime(2022, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateEnd = new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateStarted = new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Des Story of Project B",
                            Id_Assignee = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Creator = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_IssueType = 2,
                            Id_Label = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Linked_Issue = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Parent_Issue = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Project = new Guid("89fad9a0-690d-46e8-a2fe-c6cc50350eaf"),
                            Id_Reporter = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Restrict = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Sprint = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Stage = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Updator = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = 0,
                            IsFlagged = 0,
                            IsWatched = 0,
                            Priority = 5,
                            Story_Point_Estimate = 1,
                            Summary = "The Story of Project B",
                            UpdateDate = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MarvicSolution.DATA.Entities.Member", b =>
                {
                    b.Property<Guid>("Id_Project")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_User")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.HasKey("Id_Project", "Id_User");

                    b.ToTable("Member");

                    b.HasData(
                        new
                        {
                            Id_Project = new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"),
                            Id_User = new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"),
                            IsDeleted = 0
                        },
                        new
                        {
                            Id_Project = new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"),
                            Id_User = new Guid("346f2520-6295-4734-8868-6ca75258e7c1"),
                            IsDeleted = 0
                        },
                        new
                        {
                            Id_Project = new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"),
                            Id_User = new Guid("7a370bac-b796-454d-84cf-18c603102ca2"),
                            IsDeleted = 0
                        },
                        new
                        {
                            Id_Project = new Guid("89fad9a0-690d-46e8-a2fe-c6cc50350eaf"),
                            Id_User = new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"),
                            IsDeleted = 0
                        },
                        new
                        {
                            Id_Project = new Guid("a5329d06-9d32-4a54-b816-906dfbbd288c"),
                            Id_User = new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"),
                            IsDeleted = 0
                        });
                });

            modelBuilder.Entity("MarvicSolution.DATA.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Access")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateStarted")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("Id_Creator")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Lead")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("Id_Updator")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Project");

                    b.HasData(
                        new
                        {
                            Id = new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"),
                            Access = 1,
                            DateCreated = new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateEnd = new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateStarted = new DateTime(2021, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id_Creator = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Lead = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Updator = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = 0,
                            Key = "PA",
                            Name = "Project A",
                            UpdateDate = new DateTime(2021, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("89fad9a0-690d-46e8-a2fe-c6cc50350eaf"),
                            Access = 3,
                            DateCreated = new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateEnd = new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateStarted = new DateTime(2021, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id_Creator = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Lead = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Updator = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = 0,
                            Key = "PB",
                            Name = "Project B",
                            UpdateDate = new DateTime(2021, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = new Guid("a5329d06-9d32-4a54-b816-906dfbbd288c"),
                            Access = 2,
                            DateCreated = new DateTime(2021, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateEnd = new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateStarted = new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Id_Creator = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Lead = new Guid("00000000-0000-0000-0000-000000000000"),
                            Id_Updator = new Guid("00000000-0000-0000-0000-000000000000"),
                            IsDeleted = 0,
                            Key = "PC",
                            Name = "Project C",
                            UpdateDate = new DateTime(2021, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("MarvicSolution.DATA.Entities.ProjectType", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Creator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IsDeleted")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Updator")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProjectType");

                    b.HasData(
                        new
                        {
                            Id = new Guid("77b88991-f823-4301-b452-1b14ca44d5cb"),
                            Creator = "User A",
                            IsDeleted = 0,
                            Name = "Marketing",
                            UpdateDate = new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Updator = "User A_Update"
                        },
                        new
                        {
                            Id = new Guid("21c68955-ea3e-4b41-8ec5-ef816c912f1a"),
                            Creator = "User B",
                            IsDeleted = 0,
                            Name = "Development Program",
                            UpdateDate = new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Updator = "User B_Update"
                        },
                        new
                        {
                            Id = new Guid("cc6c38be-7461-4f0c-b3dd-722477375d61"),
                            Creator = "User C",
                            IsDeleted = 0,
                            Name = "Accounting",
                            UpdateDate = new DateTime(2015, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Updator = "User C_Update"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
