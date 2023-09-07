using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeEf.Migrations
{
    public partial class mig1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Students_StudentsId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Courses_CourseId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CourseId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StudentsId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Courses");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Students",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Students_CourseId",
                table: "Students",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_Courses_CourseId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_CourseId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Courses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CourseId",
                table: "Departments",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_StudentsId",
                table: "Courses",
                column: "StudentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Students_StudentsId",
                table: "Courses",
                column: "StudentsId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Courses_CourseId",
                table: "Departments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
