using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvicSolution.DATA.Migrations
{
    public partial class addprojectTypeAndprojectdataseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectTypes",
                table: "ProjectTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.RenameTable(
                name: "ProjectTypes",
                newName: "ProjectType");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectType",
                table: "ProjectType",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "Id");

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
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectType",
                table: "ProjectType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("89fad9a0-690d-46e8-a2fe-c6cc50350eaf"));

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"));

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("a5329d06-9d32-4a54-b816-906dfbbd288c"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("21c68955-ea3e-4b41-8ec5-ef816c912f1a"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("77b88991-f823-4301-b452-1b14ca44d5cb"));

            migrationBuilder.DeleteData(
                table: "ProjectType",
                keyColumn: "Id",
                keyValue: new Guid("cc6c38be-7461-4f0c-b3dd-722477375d61"));

            migrationBuilder.RenameTable(
                name: "ProjectType",
                newName: "ProjectTypes");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectTypes",
                table: "ProjectTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");
        }
    }
}
