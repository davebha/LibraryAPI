using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.DataAccess.Migrations
{
    public partial class AuthorUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsAlive",
                table: "Authors",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAlive",
                table: "Authors");
        }
    }
}
