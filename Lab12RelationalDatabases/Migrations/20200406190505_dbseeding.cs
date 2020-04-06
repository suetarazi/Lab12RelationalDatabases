using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab12RelationalDatabases.Migrations
{
    public partial class dbseeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Amenities",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 1, "Coffee Maker" },
                    { 2, "Minifridge" },
                    { 3, "Minibar" },
                    { 4, "Balcony" },
                    { 5, "Waterfront View" }
                });

            migrationBuilder.InsertData(
                table: "Hotels",
                columns: new[] { "ID", "City", "Name", "Phone", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Seattle", "Seattle Async", "206-555-4509", "Washington", "443 3rd Ave" },
                    { 2, "Maui", "Maui Async", "808-555-4510", "Hawaii", "445 Ka'anapali Blvd" },
                    { 3, "Dubuque", "Dubuque Async", "563-555-4511", "Iowa", "447 7th Ave" },
                    { 4, "Steamboat Springs", "Steamboat Springs Async", "970-555-4513", "Colorado", "449 9th Ave" },
                    { 5, "Santa Monica", "Santa Monica Async", "310-555-4509", "California", "451 Santa Monica Blvd" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "ID", "Layout", "Name" },
                values: new object[,]
                {
                    { 1, 0, "Studio" },
                    { 2, 1, "One Bedroom" },
                    { 3, 2, "Two Bedroom" },
                    { 4, 3, "Studio (ADA Compliant)" },
                    { 5, 4, "One Bedroom (ADA Compliant)" },
                    { 6, 5, "Two Bedroom (ADA Compliant)" }
                });

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelID", "RoomID", "PetFriendly", "Rate", "RoomNumber" },
                values: new object[] { 3, 1, false, 180m, 404 });

            migrationBuilder.InsertData(
                table: "HotelRooms",
                columns: new[] { "HotelID", "RoomID", "PetFriendly", "Rate", "RoomNumber" },
                values: new object[] { 1, 2, true, 200m, 503 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Amenities",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelID", "RoomID" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "HotelRooms",
                keyColumns: new[] { "HotelID", "RoomID" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Hotels",
                keyColumn: "ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
