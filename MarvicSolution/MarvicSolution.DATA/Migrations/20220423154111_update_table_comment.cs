using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvicSolution.DATA.Migrations
{
    public partial class update_table_comment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_User = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Id_Issue = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Update_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Create_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Is_Delete = table.Column<int>(type: "int", nullable: false),
                    Id_ParentComment = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "Content", "Create_Date", "Id_Issue", "Id_ParentComment", "Id_User", "Is_Delete", "Update_Date" },
                values: new object[] { new Guid("6bc52009-c246-4d54-a739-5d826ea3a7cc"), "NhanTTT1 comment", new DateTime(2022, 4, 23, 22, 41, 10, 419, DateTimeKind.Local).AddTicks(2090), new Guid("7c2cc804-4aae-4af2-9191-4268fc02edc0"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("7a370bac-b796-454d-84cf-18c603102ca2"), 0, new DateTime(2022, 4, 23, 22, 41, 10, 419, DateTimeKind.Local).AddTicks(6890) });

            migrationBuilder.InsertData(
                table: "Comment",
                columns: new[] { "Id", "Content", "Create_Date", "Id_Issue", "Id_ParentComment", "Id_User", "Is_Delete", "Update_Date" },
                values: new object[] { new Guid("d6581c11-c147-420e-9d2b-c47564fc013a"), "KhanhND comment", new DateTime(2022, 4, 23, 23, 41, 10, 419, DateTimeKind.Local).AddTicks(7768), new Guid("7c2cc804-4aae-4af2-9191-4268fc02edc0"), new Guid("00000000-0000-0000-0000-000000000000"), new Guid("e341a8f6-dc1b-4829-94fb-316b6bac99b6"), 0, new DateTime(2022, 4, 23, 23, 41, 10, 419, DateTimeKind.Local).AddTicks(7875) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");
        }
    }
}
