using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MarvicSolution.DATA.Migrations
{
    public partial class Initial_v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Course",
                columns: table => new
                {
                    Course_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Credits = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Course", x => x.Course_ID);
                });

            migrationBuilder.CreateTable(
                name: "Enrollment",
                columns: table => new
                {
                    Enrollment_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    Grade = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enrollment", x => x.Enrollment_ID);
                });

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Student_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstMidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EnrollmentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Student_ID);
                });

            migrationBuilder.InsertData(
                table: "Course",
                columns: new[] { "Course_ID", "Credits", "Title" },
                values: new object[,]
                {
                    { 1050, 3, "Chemistry" },
                    { 4022, 3, "Microeconomics" },
                    { 4041, 3, "Macroeconomics" },
                    { 1045, 4, "Calculus" },
                    { 3141, 4, "Trigonometry" },
                    { 2021, 3, "Composition" },
                    { 2042, 4, "Literature" }
                });

            migrationBuilder.InsertData(
                table: "Enrollment",
                columns: new[] { "Enrollment_ID", "CourseID", "Grade", "StudentID" },
                values: new object[,]
                {
                    { 12, 3141, 0, 7 },
                    { 11, 1045, null, 6 },
                    { 10, 4041, 2, 5 },
                    { 9, 4022, 4, 4 },
                    { 8, 1050, null, 4 },
                    { 7, 1050, null, 3 },
                    { 5, 3141, 4, 2 },
                    { 4, 1045, 1, 2 },
                    { 3, 4041, 1, 1 },
                    { 2, 4022, 2, 1 },
                    { 1, 1050, 0, 1 },
                    { 6, 2021, 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Student_ID", "EnrollmentDate", "FirstMidName", "LastName" },
                values: new object[,]
                {
                    { 7, new DateTime(2003, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Laura", "Norman" },
                    { 1, new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Carson", "Alexander" },
                    { 2, new DateTime(2002, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Meredith", "Alonso" },
                    { 3, new DateTime(2003, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arturo", "Anand" },
                    { 4, new DateTime(2002, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Gytis", "Barzdukas" },
                    { 5, new DateTime(2002, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yan", "Li" },
                    { 6, new DateTime(2001, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Peggy", "Justice" },
                    { 8, new DateTime(2005, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nino", "Olivetto" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Course");

            migrationBuilder.DropTable(
                name: "Enrollment");

            migrationBuilder.DropTable(
                name: "Student");
        }
    }
}
