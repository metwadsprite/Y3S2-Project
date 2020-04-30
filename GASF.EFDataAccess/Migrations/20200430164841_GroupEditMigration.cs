using Microsoft.EntityFrameworkCore.Migrations;

namespace GASF.EFDataAccess.Migrations
{
    public partial class GroupEditMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Specialisation",
                table: "Groups",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialisation",
                table: "Groups");
        }
    }
}
