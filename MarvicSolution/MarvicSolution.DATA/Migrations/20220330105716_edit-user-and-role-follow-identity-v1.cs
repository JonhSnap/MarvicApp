using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvicSolution.DATA.Migrations
{
    public partial class edituserandrolefollowidentityv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "App_Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    NormalizedName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_RoleClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "App_User",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccountName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_App_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "App_UserClaim",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "App_UserLogin",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderKey = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "App_UserRole",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "App_UserToken",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectType_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Lead_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Creator_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateStarted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Updator_Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
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

            migrationBuilder.InsertData(
                table: "App_Role",
                columns: new[] { "Id", "ConcurrencyStamp", "Creator", "DateCreated", "IsDeleted", "Name", "NormalizedName", "UpdateDate", "Updator" },
                values: new object[,]
                {
                    { new Guid("ea586555-af1d-4536-9e8c-29f00adef527"), "304536bf-d212-4951-a48b-48d32512b1fd", "KhanhND", new DateTime(2022, 3, 30, 17, 57, 16, 381, DateTimeKind.Local).AddTicks(7804), 0, "Project Manager", null, new DateTime(2022, 3, 30, 17, 57, 16, 382, DateTimeKind.Local).AddTicks(3698), "KhanhND" },
                    { new Guid("a31bfd28-35fa-419a-b03f-fe687112dc5c"), "78b0c9dc-1505-42b0-949c-d2b2fda79a6e", "KhanhND", new DateTime(2022, 3, 30, 17, 57, 16, 382, DateTimeKind.Local).AddTicks(4323), 0, "Member", null, new DateTime(2022, 3, 30, 17, 57, 16, 382, DateTimeKind.Local).AddTicks(4328), "KhanhND" },
                    { new Guid("0bd0e4cd-9a05-4588-a75f-1625492156b3"), "4677c147-4162-4b27-9d4b-f83e0edf8e1f", "KhanhND", new DateTime(2022, 3, 30, 17, 57, 16, 382, DateTimeKind.Local).AddTicks(4335), 0, "Viewer", null, new DateTime(2022, 3, 30, 17, 57, 16, 382, DateTimeKind.Local).AddTicks(4336), "KhanhND" }
                });

            migrationBuilder.InsertData(
                table: "App_User",
                columns: new[] { "Id", "AccessFailedCount", "AccountName", "ConcurrencyStamp", "Department", "Email", "EmailConfirmed", "FullName", "IsDeleted", "JobTitle", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "Organization", "Password", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"), 0, "KhanhND", "bbdb8171-44a6-4598-b0be-8d0a61b9289a", "Khoang 1 HN", "khanhnd@gmail.com", false, "Nguyen Duy Khanh", 0, "Project Manager", false, null, null, null, "Company TechNo1", "KhanhND123@", null, "0989878767", false, null, false, null },
                    { new Guid("346f2520-6295-4734-8868-6ca75258e7c1"), 0, "NhanTT", "9f105bd1-90ba-489b-b6dd-3a68a867abb5", "Khoang 2 HCM", "nhantt@gmail.com", false, "Tran Thien Nhan", 0, "Member Job Title", false, null, null, null, "Company PizzaHub", "NhanTT123@", null, "0336355563", false, null, false, null },
                    { new Guid("7a370bac-b796-454d-84cf-18c603102ca2"), 0, "NhanTT1", "fe03aa93-4fc8-42d3-915c-31706db6b30d", "Khoang 10 DN", "nhant1@gmail.com", false, "Tran Thanh Nhan", 0, "Director", false, null, null, null, "Company Marketing Hanzu", "NhanTT1Cute@", null, "0345677456", false, null, false, null }
                });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "Creator_Id", "DateCreated", "DateEnd", "DateStarted", "IsDeleted", "Key", "Lead_Id", "Name", "ProjectType_Id", "UpdateDate", "Updator_Id" },
                values: new object[,]
                {
                    { new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2021, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "PA", new Guid("00000000-0000-0000-0000-000000000000"), "Project A", new Guid("77b88991-f823-4301-b452-1b14ca44d5cb"), new DateTime(2021, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("89fad9a0-690d-46e8-a2fe-c6cc50350eaf"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2021, 3, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "PB", new Guid("00000000-0000-0000-0000-000000000000"), "Project B", new Guid("77b88991-f823-4301-b452-1b14ca44d5cb"), new DateTime(2021, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") },
                    { new Guid("a5329d06-9d32-4a54-b816-906dfbbd288c"), new Guid("00000000-0000-0000-0000-000000000000"), new DateTime(2021, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 6, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, "PC", new Guid("00000000-0000-0000-0000-000000000000"), "Project C", new Guid("21c68955-ea3e-4b41-8ec5-ef816c912f1a"), new DateTime(2021, 4, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("00000000-0000-0000-0000-000000000000") }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "App_Role");

            migrationBuilder.DropTable(
                name: "App_RoleClaim");

            migrationBuilder.DropTable(
                name: "App_User");

            migrationBuilder.DropTable(
                name: "App_UserClaim");

            migrationBuilder.DropTable(
                name: "App_UserLogin");

            migrationBuilder.DropTable(
                name: "App_UserRole");

            migrationBuilder.DropTable(
                name: "App_UserToken");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProjectType");
        }
    }
}
