using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API1STPRO.Migrations
{
    /// <inheritdoc />
    public partial class AddStudentDeptFk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CourseId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    CourseTeacher = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.StudentId);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeptLocation = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeptCourses = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DeptStudents = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments_1", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudenrtName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DeptName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    BloodGroup = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    CGPA = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    DepartmentDeptId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Studensts", x => x.StudentId);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DepartmentDeptId",
                        column: x => x.DepartmentDeptId,
                        principalTable: "Departments",
                        principalColumn: "DeptId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DepartmentDeptId",
                table: "Students",
                column: "DepartmentDeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
