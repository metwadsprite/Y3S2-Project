using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GASF.EFDataAccess.Migrations
{
    public partial class ExamMigrationReverse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Courses_Id",
                table: "Exams");

            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "Exams",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CourseId",
                table: "Exams",
                column: "CourseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Courses_CourseId",
                table: "Exams",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Courses_CourseId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Exams_CourseId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Exams");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Courses_Id",
                table: "Exams",
                column: "Id",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
