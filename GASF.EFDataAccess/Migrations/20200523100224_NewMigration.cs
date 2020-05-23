using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GASF.EFDataAccess.Migrations
{
    public partial class NewMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SecretaryId",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SecretaryId",
                table: "SchoolFees",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Students_SecretaryId",
                table: "Students",
                column: "SecretaryId");

            migrationBuilder.CreateIndex(
                name: "IX_SchoolFees_SecretaryId",
                table: "SchoolFees",
                column: "SecretaryId");

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolFees_Secretaries_SecretaryId",
                table: "SchoolFees",
                column: "SecretaryId",
                principalTable: "Secretaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Secretaries_SecretaryId",
                table: "Students",
                column: "SecretaryId",
                principalTable: "Secretaries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolFees_Secretaries_SecretaryId",
                table: "SchoolFees");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Secretaries_SecretaryId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_SecretaryId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_SchoolFees_SecretaryId",
                table: "SchoolFees");

            migrationBuilder.DropColumn(
                name: "SecretaryId",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "SecretaryId",
                table: "SchoolFees");
        }
    }
}
