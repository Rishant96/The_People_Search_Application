using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleSearchApp.Migrations
{
    public partial class IntialWithData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    DOB = table.Column<DateTime>(type: "Date", nullable: false),
                    PathToAvatar = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    PersonAddressId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_PersonAddress_PersonAddressId",
                        column: x => x.PersonAddressId,
                        principalTable: "PersonAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonInterest",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonId = table.Column<int>(nullable: false),
                    Interest = table.Column<string>(type: "nvarchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonInterest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonInterest_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "PersonAddress",
                columns: new[] { "Id", "City", "Country", "Line1", "Line2", "State", "ZipCode" },
                values: new object[] { 1, "Charlotte", "United States", "1539, Bonnie Rd", null, "North Carolina", "28213" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "DOB", "FirstName", "LastName", "MiddleName", "PathToAvatar", "PersonAddressId" },
                values: new object[] { 1, new DateTime(1982, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Johnson", null, null, 1 });

            migrationBuilder.InsertData(
                table: "PersonInterest",
                columns: new[] { "Id", "Interest", "PersonId" },
                values: new object[] { 1, "Reading Novels", 1 });

            migrationBuilder.InsertData(
                table: "PersonInterest",
                columns: new[] { "Id", "Interest", "PersonId" },
                values: new object[] { 2, "Swimming", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_People_PersonAddressId",
                table: "People",
                column: "PersonAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_PersonInterest_PersonId",
                table: "PersonInterest",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonInterest");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "PersonAddress");
        }
    }
}
