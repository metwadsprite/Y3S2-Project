using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GASF.EFDataAccess.Migrations
{
    public partial class UpdatedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "TeacherCertificates",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "StudentCertificates",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "Secretaries",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "TeacherCertificates");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "StudentCertificates");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Secretaries");
        }
    }
}
