using Microsoft.EntityFrameworkCore.Migrations;

namespace Lab12RelationalDatabases.Migrations
{
    public partial class tableCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amenities",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amenities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    StreetAddress = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Layout = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "HotelRooms",
                columns: table => new
                {
                    HotelID = table.Column<int>(nullable: false),
                    RoomID = table.Column<int>(nullable: false),
                    RoomNumber = table.Column<int>(nullable: false),
                    PetFriendly = table.Column<bool>(nullable: false),
                    Rate = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HotelRooms", x => new { x.HotelID, x.RoomID });
                    table.ForeignKey(
                        name: "FK_HotelRooms_Hotels_HotelID",
                        column: x => x.HotelID,
                        principalTable: "Hotels",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HotelRooms_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoomAmenities",
                columns: table => new
                {
                    AmenitiesID = table.Column<string>(nullable: false),
                    RoomID = table.Column<int>(nullable: false),
                    AmenitiesID1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomAmenities", x => new { x.AmenitiesID, x.RoomID });
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Amenities_AmenitiesID1",
                        column: x => x.AmenitiesID1,
                        principalTable: "Amenities",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RoomAmenities_Rooms_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Rooms",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_HotelID",
                table: "HotelRooms",
                column: "HotelID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HotelRooms_RoomID",
                table: "HotelRooms",
                column: "RoomID");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_AmenitiesID1",
                table: "RoomAmenities",
                column: "AmenitiesID1");

            migrationBuilder.CreateIndex(
                name: "IX_RoomAmenities_RoomID",
                table: "RoomAmenities",
                column: "RoomID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HotelRooms");

            migrationBuilder.DropTable(
                name: "RoomAmenities");

            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Amenities");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
