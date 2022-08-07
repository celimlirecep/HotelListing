using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelListing.API.Migrations
{
    public partial class SeedDatabaseCountryandHotels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Countries",
                columns: new[] { "Id", "Name", "ShortName" },
                values: new object[,]
                {
                    { 1, "Türkiye", "Tr" },
                    { 2, "İngiltere", "En" },
                    { 3, "Fransa", "Fr" },
                    { 4, "Bahama", "Bs" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "Id", "Adress", "CountryId", "Name", "Rating" },
                values: new object[,]
                {
                    { 1, "İstanbul", 1, "Türkiye Hotel", 4.7000000000000002 },
                    { 2, "İstanbul", 2, "İngiltere Hotel", 4.7000000000000002 },
                    { 3, "İstanbul", 3, "Fıransa Hotel", 4.2000000000000002 },
                    { 4, "İstanbul", 4, "Bahama Hotel", 3.7000000000000002 },
                    { 5, "İstanbul", 1, "Türkiye Hotel", 5.0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Countries",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
