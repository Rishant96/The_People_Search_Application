using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PeopleSearchApp.Migrations
{
    public partial class IntialWithData_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PersonAddress",
                columns: new[] { "Id", "City", "Country", "Line1", "Line2", "State", "ZipCode" },
                values: new object[] { 2, "Charlotte", "United States", "1624 C, Arlyn Cir", "Margie Ann Rd", "North Carolina", "28213" });

            migrationBuilder.InsertData(
                table: "PersonAddress",
                columns: new[] { "Id", "City", "Country", "Line1", "Line2", "State", "ZipCode" },
                values: new object[] { 3, "Gurugram", "India", "House No. 259, Sector 9A", null, "Haryana", "122001" });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "DOB", "FirstName", "LastName", "MiddleName", "PathToAvatar", "PersonAddressId" },
                values: new object[] { 2, new DateTime(1991, 9, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ashley", "Thompson", null, null, 2 });

            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "DOB", "FirstName", "LastName", "MiddleName", "PathToAvatar", "PersonAddressId" },
                values: new object[] { 3, new DateTime(1994, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Varun", "Dutt", null, null, 3 });

            migrationBuilder.InsertData(
                table: "PersonInterest",
                columns: new[] { "Id", "Interest", "PersonId" },
                values: new object[,]
                {
                    { 3, "Camping", 2 },
                    { 4, "Listening to Music", 2 },
                    { 5, "Cooking", 2 },
                    { 6, "Playing Video Games", 3 },
                    { 7, "Playing Guitar", 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PersonInterest",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PersonAddress",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PersonAddress",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
