using Microsoft.EntityFrameworkCore.Migrations;

namespace GASF.EFDataAccess.Migrations
{
    public partial class ExamMigrationEditFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Exams_Id",
                table: "Courses");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Courses_Id",
                table: "Exams",
                column: "Id",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Courses_Id",
                table: "Exams");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Exams_Id",
                table: "Courses",
                column: "Id",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
