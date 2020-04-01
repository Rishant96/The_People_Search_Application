using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleSearchApp.Migrations
{
    public partial class AddressAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PersonAddressId",
                table: "People",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "PersonAddress",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Line1 = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Line2 = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    ZipCode = table.Column<string>(type: "nvarchar(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonAddress", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonAddressId",
                table: "People",
                column: "PersonAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_People_PersonAddress_PersonAddressId",
                table: "People",
                column: "PersonAddressId",
                principalTable: "PersonAddress",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_People_PersonAddress_PersonAddressId",
                table: "People");

            migrationBuilder.DropTable(
                name: "PersonAddress");

            migrationBuilder.DropIndex(
                name: "IX_People_PersonAddressId",
                table: "People");

            migrationBuilder.DropColumn(
                name: "PersonAddressId",
                table: "People");
        }
    }
}
