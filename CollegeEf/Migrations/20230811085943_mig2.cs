using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CollegeEf.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StaffCount",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CourseId",
                table: "Departments",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Courses_CourseId",
                table: "Departments",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Courses_CourseId",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CourseId",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "StaffCount",
                table: "Departments");
        }
    }
}
