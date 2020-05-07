using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GASF.EFDataAccess.Migrations
{
    public partial class CourseExamMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Exams_ExamId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ExamId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ExamId",
                table: "Courses");

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

            migrationBuilder.AddColumn<Guid>(
                name: "ExamId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ExamId",
                table: "Courses",
                column: "ExamId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Exams_ExamId",
                table: "Courses",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
