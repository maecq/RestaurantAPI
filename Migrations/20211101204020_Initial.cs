using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestaurantAPI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MenuItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemsReserveds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemID = table.Column<int>(type: "int", nullable: false),
                    ReservationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemsReserveds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItemsReserveds_MenuItems_MenuItemID",
                        column: x => x.MenuItemID,
                        principalTable: "MenuItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemsReserveds_Reservations_ReservationID",
                        column: x => x.ReservationID,
                        principalTable: "Reservations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Name", "Price" },
                values: new object[] { 1001, "Spaghetti", 19.25 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "Id", "Date", "Name" },
                values: new object[] { 2001, new DateTime(2021, 11, 1, 15, 40, 20, 263, DateTimeKind.Local).AddTicks(480), "Ryan's" });

            migrationBuilder.InsertData(
                table: "MenuItemsReserveds",
                columns: new[] { "Id", "MenuItemID", "ReservationID" },
                values: new object[] { 3001, 1001, 2001 });

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemsReserveds_MenuItemID",
                table: "MenuItemsReserveds",
                column: "MenuItemID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemsReserveds_ReservationID",
                table: "MenuItemsReserveds",
                column: "ReservationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuItemsReserveds");

            migrationBuilder.DropTable(
                name: "MenuItems");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
