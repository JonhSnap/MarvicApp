using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvicSolution.DATA.Migrations
{
    public partial class updateDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("6bc52009-c246-4d54-a739-5d826ea3a7cc"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("d6581c11-c147-420e-9d2b-c47564fc013a"));

            migrationBuilder.CreateTable(
                name: "Sprint",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Project = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SprintName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Creator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Update_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Start_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Is_Delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sprint", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "Content", "Create_Date", "Id_Issue", "Id_ParentComment", "Id_User", "Is_Delete", "Update_Date" },
                values: new object[] { new Guid("ab5af8f5-ce63-45ef-bd57-ec74c71069ae"), "NhanTTT1 comment", new DateTime(2022, 4, 30, 21, 37, 38, 104, DateTimeKind.Local).AddTicks(8794), new Guid("7c2cc804-4aae-4af2-9191-4268fc02edc0"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("7a370bac-b796-454d-84cf-18c603102ca2"), 0, new DateTime(2022, 4, 30, 21, 37, 38, 105, DateTimeKind.Local).AddTicks(5658) });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "Content", "Create_Date", "Id_Issue", "Id_ParentComment", "Id_User", "Is_Delete", "Update_Date" },
                values: new object[] { new Guid("e4203184-f6c1-4a40-9d1a-167f9bed6390"), "KhanhND comment", new DateTime(2022, 4, 30, 22, 37, 38, 105, DateTimeKind.Local).AddTicks(6709), new Guid("7c2cc804-4aae-4af2-9191-4268fc02edc0"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"), 0, new DateTime(2022, 4, 30, 22, 37, 38, 106, DateTimeKind.Local).AddTicks(612) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sprint");

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("ab5af8f5-ce63-45ef-bd57-ec74c71069ae"));

            migrationBuilder.DeleteData(
                table: "Comment",
                keyColumn: "Id",
                keyValue: new Guid("e4203184-f6c1-4a40-9d1a-167f9bed6390"));

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "Content", "Create_Date", "Id_Issue", "Id_ParentComment", "Id_User", "Is_Delete", "Update_Date" },
                values: new object[] { new Guid("6bc52009-c246-4d54-a739-5d826ea3a7cc"), "NhanTTT1 comment", new DateTime(2022, 4, 23, 22, 41, 10, 419, DateTimeKind.Local).AddTicks(2090), new Guid("7c2cc804-4aae-4af2-9191-4268fc02edc0"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("7a370bac-b796-454d-84cf-18c603102ca2"), 0, new DateTime(2022, 4, 23, 22, 41, 10, 419, DateTimeKind.Local).AddTicks(6890) });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "Content", "Create_Date", "Id_Issue", "Id_ParentComment", "Id_User", "Is_Delete", "Update_Date" },
                values: new object[] { new Guid("d6581c11-c147-420e-9d2b-c47564fc013a"), "KhanhND comment", new DateTime(2022, 4, 23, 23, 41, 10, 419, DateTimeKind.Local).AddTicks(7768), new Guid("7c2cc804-4aae-4af2-9191-4268fc02edc0"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"), 0, new DateTime(2022, 4, 23, 23, 41, 10, 419, DateTimeKind.Local).AddTicks(7875) });
        }
    }
}
