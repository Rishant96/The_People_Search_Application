using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleSearchApp.Migrations
{
    public partial class Favorite_Contacts_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorite",
                table: "People",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorite",
                table: "People");
        }
    }
}
