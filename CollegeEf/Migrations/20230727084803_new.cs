using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeEf.Migrations
{
    public partial class @new : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Course",
                table: "Students");

            migrationBuilder.AddColumn<int>(
                name: "StudentsId",
                table: "Courses",
                type: "int",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Students_StudentsId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_StudentsId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "StudentsId",
                table: "Courses");

            migrationBuilder.AddColumn<string>(
                name: "Course",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
