using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvicSolution.DATA.Migrations
{
    public partial class addmemeber : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    Id_Project = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsDeleted = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => new { x.Id_Project, x.Id_User });
                });

            migrationBuilder.UpdateData(
                table: "App_User",
                keyColumn: "Id",
                keyValue: new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"),
                column: "Email",
                value: null);

            migrationBuilder.InsertData(
                table: "Member",
                columns: new[] { "Id_Project", "Id_User", "IsDeleted" },
                values: new object[,]
                {
                    { new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"), new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"), 0 },
                    { new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"), new Guid("346f2520-6295-4734-8868-6ca75258e7c1"), 0 },
                    { new Guid("a42b223b-faec-48e3-8e28-51fe1b22fa7c"), new Guid("7a370bac-b796-454d-84cf-18c603102ca2"), 0 },
                    { new Guid("89fad9a0-690d-46e8-a2fe-c6cc50350eaf"), new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"), 0 },
                    { new Guid("a5329d06-9d32-4a54-b816-906dfbbd288c"), new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"), 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Member");

            migrationBuilder.UpdateData(
                table: "App_User",
                keyColumn: "Id",
                keyValue: new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"),
                column: "Email",
                value: "khanhnd@gmail.com");
        }
    }
}
