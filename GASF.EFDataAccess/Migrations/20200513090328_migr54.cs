using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GASF.EFDataAccess.Migrations
{
    public partial class migr54 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolFees_Students_StudentId",
                table: "SchoolFees");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "SchoolFees",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolFees_Students_StudentId",
                table: "SchoolFees",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SchoolFees_Students_StudentId",
                table: "SchoolFees");

            migrationBuilder.AlterColumn<Guid>(
                name: "StudentId",
                table: "SchoolFees",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolFees_Students_StudentId",
                table: "SchoolFees",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
