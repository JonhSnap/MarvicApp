using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvicSolution.DATA.Migrations
{
    public partial class dbv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Question = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsAnswer = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Issue",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Project = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_IssueType = table.Column<int>(type: "int", nullable: false),
                    Id_Stage = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id_Sprint = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id_Label = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Assignee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Story_Point_Estimate = table.Column<int>(type: "int", nullable: true),
                    Id_Reporter = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Attachment_Path = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Linked_Issue = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Id_Parent_Issue = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: true),
                    Id_Restrict = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsFlagged = table.Column<int>(type: "int", nullable: true),
                    IsWatched = table.Column<int>(type: "int", nullable: true),
                    Id_Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Id_Updator = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Issue", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id_Project = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => new { x.Id_Project, x.Id_User });
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Access = table.Column<int>(type: "int", nullable: false),
                    Id_Lead = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Creator = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Id_Updator = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsStared = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Updator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Question",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Id_Test = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Scores = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Question", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Test",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Test", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Answer",
                columns: new[] { "Id", "Id_Question", "IsAnswer", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("69a58c4b-c2e1-455d-9559-4169162c1bbf"), new Guid("da1969f2-3008-49d3-8281-030b4c343c5d"), 0, 1, "Ans A1-1" },
                    { new Guid("08139b92-015c-47e1-8f8a-50134c2e7a89"), new Guid("b776ef62-50a5-4998-aa13-a6d3f4ca35e4"), 1, 0, "Ans B2-1" },
                    { new Guid("c666592a-6d7d-4a54-9ccf-e0d866167f39"), new Guid("b776ef62-50a5-4998-aa13-a6d3f4ca35e4"), 0, 0, "Ans B2-2" },
                    { new Guid("315b2b1e-f044-418c-841d-027f89432209"), new Guid("b776ef62-50a5-4998-aa13-a6d3f4ca35e4"), 0, 0, "Ans B2-3" },
                    { new Guid("6409db52-2b3c-45fb-ac46-91d050d57eb0"), new Guid("b776ef62-50a5-4998-aa13-a6d3f4ca35e4"), 0, 0, "Ans B2-4" },
                    { new Guid("8f737006-062b-4b5a-ba2a-35eecf3a5f95"), new Guid("7cf4e8f0-9dd9-438d-8581-57d33ad90b78"), 1, 0, "Ans B3-1" },
                    { new Guid("ad954fc8-9344-40e9-8d1f-3b08490f7a7f"), new Guid("7cf4e8f0-9dd9-438d-8581-57d33ad90b78"), 0, 0, "Ans B3-2" },
                    { new Guid("4987be92-0627-4ac3-87d3-3771dc83bcf5"), new Guid("7cf4e8f0-9dd9-438d-8581-57d33ad90b78"), 0, 0, "Ans B3-3" },
                    { new Guid("fe4b0fb6-cc5c-4f1b-b617-977d76497b40"), new Guid("7cf4e8f0-9dd9-438d-8581-57d33ad90b78"), 0, 0, "Ans B3-4" },
                    { new Guid("2a9bc99a-f323-4002-b6af-7de602692ec4"), new Guid("5d6e0ec4-cbd9-43d9-8330-4b76405808ae"), 1, 0, "Ans B4-1" },
                    { new Guid("91bbfe96-d736-4b9d-b592-009dd0a28801"), new Guid("5d6e0ec4-cbd9-43d9-8330-4b76405808ae"), 0, 0, "Ans B4-2" },
                    { new Guid("804e778f-eeeb-4375-8486-e9991e0dd8b3"), new Guid("5d6e0ec4-cbd9-43d9-8330-4b76405808ae"), 0, 0, "Ans B4-3" },
                    { new Guid("9e213971-75f6-48cd-b948-a3390c767eb7"), new Guid("5d6e0ec4-cbd9-43d9-8330-4b76405808ae"), 0, 0, "Ans B4-4" },
                    { new Guid("1bf39dbf-863e-42d9-94ae-3ba9745b5c84"), new Guid("f0869ff6-3127-4714-a75d-720d198c59e5"), 0, 0, "Ans B4-4" },
                    { new Guid("3eabb060-8923-468b-b530-d5b68e544b58"), new Guid("f0869ff6-3127-4714-a75d-720d198c59e5"), 0, 0, "Ans B4-4" },
                    { new Guid("9c4201ba-e32d-4e33-9514-12023d843c48"), new Guid("f0869ff6-3127-4714-a75d-720d198c59e5"), 0, 0, "Ans B4-4" },
                    { new Guid("5ce3de4e-e51a-40de-983f-a15207da423e"), new Guid("1d641d48-f550-481b-adff-440ed5aa6f65"), 0, 0, "Ans B1-4" },
                    { new Guid("77f88ec5-4f24-45cf-9655-3c7931e33507"), new Guid("1d641d48-f550-481b-adff-440ed5aa6f65"), 0, 0, "Ans B1-3" },
                    { new Guid("9a2a82a3-b504-487e-a302-b293ac9921fc"), new Guid("f0869ff6-3127-4714-a75d-720d198c59e5"), 0, 0, "Ans B4-4" },
                    { new Guid("1ff50d10-dd8e-4da1-bb11-1fcbbc1e3c10"), new Guid("1d641d48-f550-481b-adff-440ed5aa6f65"), 1, 0, "Ans B1-1" },
                    { new Guid("bc8eacec-efa8-4288-b97d-d2d61be430fe"), new Guid("1d641d48-f550-481b-adff-440ed5aa6f65"), 0, 0, "Ans B1-2" },
                    { new Guid("4a69753c-f865-404f-abd8-43c350222189"), new Guid("da1969f2-3008-49d3-8281-030b4c343c5d"), 0, 0, "Ans A1-2" },
                    { new Guid("4e257ba8-35d3-45f0-baac-f2b0b98fbedd"), new Guid("da1969f2-3008-49d3-8281-030b4c343c5d"), 0, 0, "Ans A1-3" },
                    { new Guid("146980c0-f9a3-4457-8b03-e8511fdfdbc1"), new Guid("da1969f2-3008-49d3-8281-030b4c343c5d"), 0, 0, "Ans A1-4" },
                    { new Guid("4c9b7cda-859b-4c26-b2df-2002073bbd84"), new Guid("5570f4ee-0f7d-4a48-be63-bc011555ddd2"), 1, 0, "Ans A2-1" },
                    { new Guid("944115d0-9566-4e58-b711-23f8869df029"), new Guid("5570f4ee-0f7d-4a48-be63-bc011555ddd2"), 0, 0, "Ans A2-2" },
                    { new Guid("1616a299-6b7b-4573-abfa-2c3d40641ab1"), new Guid("5570f4ee-0f7d-4a48-be63-bc011555ddd2"), 0, 0, "Ans A2-4" },
                    { new Guid("2adad43f-5cc2-48d9-97af-51ad79e41160"), new Guid("5570f4ee-0f7d-4a48-be63-bc011555ddd2"), 0, 0, "Ans A2-3" },
                    { new Guid("7afccd26-5f50-4810-aad8-ae0f53b93b0b"), new Guid("a8b3af9f-bae9-4b1a-89d0-808f7b8b4e56"), 0, 0, "Ans A3-2" },
                    { new Guid("2b8f753c-fda8-43fa-b5e8-883852367e56"), new Guid("a8b3af9f-bae9-4b1a-89d0-808f7b8b4e56"), 0, 0, "Ans A3-3" },
                    { new Guid("535050be-932a-4b9b-a9d7-dbb2eb2ccb25"), new Guid("a8b3af9f-bae9-4b1a-89d0-808f7b8b4e56"), 0, 0, "Ans A3-4" },
                    { new Guid("53c26c0e-944c-4b4d-98a6-48bfabfb484b"), new Guid("d60e8b27-d139-40d4-9cc8-3e8d09752a6a"), 1, 0, "Ans A4-1" },
                    { new Guid("c4709e72-98c1-4a46-89e1-971de4143d25"), new Guid("d60e8b27-d139-40d4-9cc8-3e8d09752a6a"), 0, 0, "Ans A4-2" },
                    { new Guid("74fe3ebc-3381-4e9f-a2f4-a6c20114d3d5"), new Guid("d60e8b27-d139-40d4-9cc8-3e8d09752a6a"), 0, 0, "Ans A4-3" },
                    { new Guid("64d5ad49-dd7d-467f-8a8c-932d00df8bab"), new Guid("d60e8b27-d139-40d4-9cc8-3e8d09752a6a"), 0, 0, "Ans A4-4" },
                    { new Guid("a906e299-85d6-4fa9-9138-95083438f304"), new Guid("a8b3af9f-bae9-4b1a-89d0-808f7b8b4e56"), 1, 0, "Ans A3-1" }
                });

            migrationBuilder.InsertData(
                table: "App_User",
                columns: new[] { "Id", "Department", "Email", "FullName", "IsDeleted", "JobTitle", "Organization", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"), "Khoang 1 HN", null, "Nguyen Duy Khanh", 0, "Project Manager", "Company TechNo1", "$2a$11$D57iJclK1BhZgg9B0P4I2.9sq0MoQIRImA8YeDVvbxeKPNG/KuTMK", "0989878767", "KhanhND" },
                    { new Guid("346f2520-6295-4734-8868-6ca75258e7c1"), "Khoang 2 HCM", "nhantt@gmail.com", "Tran Thien Nhan", 0, "Member Job Title", "Company PizzaHub", "$2a$11$MjbSthPb/xXnLsaNnJDVE.GGHoWL9aPMqLzCXTmoVs1HoHBqLsuWq", "0336355563", "NhanTT" },
                    { new Guid("7a370bac-b796-454d-84cf-18c603102ca2"), "Khoang 10 DN", "nhant1@gmail.com", "Tran Thanh Nhan", 0, "Director", "Company Marketing Hanzu", "$2a$11$IM2wFUFnOP.TYaxfqYjEluUatAmE95HIFZcElLoLGRmdUYkBFujCm", "0345677456", "NhanTTT1" }
                });

            migrationBuilder.InsertData(
                table: "Issue",
                columns: new[] { "Id", "Attachment_Path", "DateCreated", "DateEnd", "DateStarted", "Description", "Id_Assignee", "Id_Creator", "Id_IssueType", "Id_Label", "Id_Linked_Issue", "Id_Parent_Issue", "Id_Project", "Id_Reporter", "Id_Restrict", "Id_Sprint", "Id_Stage", "Id_Updator", "IsDeleted", "IsFlagged", "IsWatched", "Priority", "Story_Point_Estimate", "Summary", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("bbbe8f8e-a735-4a4c-bded-e4ce2405e8e1"), "", new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Des epic of Project B", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 1, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("89fad9a0-690d-46e8-a2fe-c6cc50350eaf"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 0, 2, 6, "The epic of Project B", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("24c577bb-002d-4a31-a855-ca22f0c7ca69"), "", new DateTime(2022, 1, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Des Task2 of Project A", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 3, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 0, 4, 2, "The Task2 of Project A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bffc9087-de0d-4bf8-97a1-f97a26d6fda4"), "", new DateTime(2022, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 10, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Des Story of Project B", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 2, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("89fad9a0-690d-46e8-a2fe-c6cc50350eaf"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 0, 5, 1, "The Story of Project B", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Issue",
                columns: new[] { "Id", "Attachment_Path", "DateCreated", "DateEnd", "DateStarted", "Description", "Id_Assignee", "Id_Creator", "Id_IssueType", "Id_Label", "Id_Linked_Issue", "Id_Parent_Issue", "Id_Project", "Id_Reporter", "Id_Restrict", "Id_Sprint", "Id_Stage", "Id_Updator", "IsDeleted", "IsFlagged", "IsWatched", "Priority", "Story_Point_Estimate", "Summary", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("7c2cc804-4aae-4af2-9191-4268fc02edc0"), "", new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Des Story of Project A", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 2, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 0, 3, 9, "The Story of Project A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("bb2b349b-1075-45ca-96de-9f709a678eb0"), "", new DateTime(2022, 3, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 6, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Des epic Project A", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 1, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 0, 5, 8, "The epic of Project A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("edff3f58-7640-4f5a-ada0-dc017f602501"), "", new DateTime(2022, 2, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Des Task1 of Project A", new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 3, new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, 0, 3, 5, "The Task1 of Project A", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id_Project", "Id_User", "Role" },
                values: new object[,]
                {
                    { new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"), new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"), 3 },
                    { new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"), new Guid("346f2520-6295-4734-8868-6ca75258e7c1"), 1 },
                    { new Guid("89fad9a0-690d-46e8-a2fe-c6cc50350eaf"), new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"), 2 },
                    { new Guid("89fad9a0-690d-46e8-a2fe-c6cc50350eaf"), new Guid("346f2520-6295-4734-8868-6ca75258e7c1"), 1 },
                    { new Guid("a5329d06-9d32-4a54-b816-906dfbbd288c"), new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"), 3 }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Access", "DateCreated", "DateEnd", "DateStarted", "Id_Creator", "Id_Lead", "Id_Updator", "IsDeleted", "IsStared", "Key", "Name", "UpdateDate" },
                values: new object[,]
                {
                    { new Guid("a5329d06-9d32-4a54-b816-906dfbbd288c"), 2, new DateTime(2021, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 1, "PC", "Project C", new DateTime(2021, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"), 1, new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 0, "PA", "Project A", new DateTime(2021, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("89fad9a0-690d-46e8-a2fe-c6cc50350eaf"), 3, new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("00000000-0000-0000-0000-000000000000"), 0, 1, "PB", "Project B", new DateTime(2021, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "ProjectType",
                columns: new[] { "Id", "Creator", "IsDeleted", "Name", "UpdateDate", "Updator" },
                values: new object[,]
                {
                    { new Guid("77b88991-f823-4301-b452-1b14ca44d5cb"), "User A", 0, "Marketing", new DateTime(2022, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "User A_Update" },
                    { new Guid("21c68955-ea3e-4b41-8ec5-ef816c912f1a"), "User B", 0, "Development Program", new DateTime(2021, 10, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "User B_Update" },
                    { new Guid("cc6c38be-7461-4f0c-b3dd-722477375d61"), "User C", 0, "Accounting", new DateTime(2015, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "User C_Update" }
                });

            migrationBuilder.InsertData(
                table: "Question",
                columns: new[] { "Id", "Id_Test", "IsDeleted", "Name", "Scores" },
                values: new object[,]
                {
                    { new Guid("7cf4e8f0-9dd9-438d-8581-57d33ad90b78"), new Guid("24b1c442-53a2-49be-a146-c2147540c645"), 0, "Question B3", 1 },
                    { new Guid("f0869ff6-3127-4714-a75d-720d198c59e5"), new Guid("24b1c442-53a2-49be-a146-c2147540c645"), 0, "Question B5", 1 },
                    { new Guid("5d6e0ec4-cbd9-43d9-8330-4b76405808ae"), new Guid("24b1c442-53a2-49be-a146-c2147540c645"), 0, "Question B4", 1 },
                    { new Guid("b776ef62-50a5-4998-aa13-a6d3f4ca35e4"), new Guid("24b1c442-53a2-49be-a146-c2147540c645"), 0, "Question B2", 2 },
                    { new Guid("da1969f2-3008-49d3-8281-030b4c343c5d"), new Guid("43d27fb9-cdf2-4a42-aeac-30d551ad7334"), 0, "Question A1", 2 },
                    { new Guid("d60e8b27-d139-40d4-9cc8-3e8d09752a6a"), new Guid("43d27fb9-cdf2-4a42-aeac-30d551ad7334"), 0, "Question A4", 1 },
                    { new Guid("a8b3af9f-bae9-4b1a-89d0-808f7b8b4e56"), new Guid("43d27fb9-cdf2-4a42-aeac-30d551ad7334"), 0, "Question A3", 4 },
                    { new Guid("5570f4ee-0f7d-4a48-be63-bc011555ddd2"), new Guid("43d27fb9-cdf2-4a42-aeac-30d551ad7334"), 0, "Question A2", 3 },
                    { new Guid("1d641d48-f550-481b-adff-440ed5aa6f65"), new Guid("24b1c442-53a2-49be-a146-c2147540c645"), 0, "Question B1", 6 }
                });

            migrationBuilder.InsertData(
                table: "Test",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[,]
                {
                    { new Guid("c475d804-0122-4b2b-af41-f6c53d22ba74"), 0, "Test E" },
                    { new Guid("43d27fb9-cdf2-4a42-aeac-30d551ad7334"), 0, "Test A" },
                    { new Guid("24b1c442-53a2-49be-a146-c2147540c645"), 0, "Test B" },
                    { new Guid("d77a4a2d-d886-4658-9438-c800157423e0"), 0, "Test C" },
                    { new Guid("32661992-aaa1-49d6-adba-cb55ebbf0c04"), 0, "Test D" },
                    { new Guid("c7b0d387-afc8-423d-8218-a3fd83cc850e"), 0, "Test F" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Answer");

            migrationBuilder.DropTable(
                name: "App_User");

            migrationBuilder.DropTable(
                name: "Issue");

            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProjectType");

            migrationBuilder.DropTable(
                name: "Question");

            migrationBuilder.DropTable(
                name: "Test");
        }
    }
}
