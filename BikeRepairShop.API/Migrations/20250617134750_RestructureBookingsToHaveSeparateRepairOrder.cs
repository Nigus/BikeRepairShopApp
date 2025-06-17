using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BikeRepairShop.API.Migrations
{
    /// <inheritdoc />
    public partial class RestructureBookingsToHaveSeparateRepairOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Brands_BikeBrandId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "Bookings");

            migrationBuilder.AlterColumn<int>(
                name: "BikeBrandId",
                table: "Bookings",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "RepairOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    BikeBrandId = table.Column<int>(type: "int", nullable: false),
                    ServiceType = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RepairOrders_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RepairOrders_Brands_BikeBrandId",
                        column: x => x.BikeBrandId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RepairOrders_BikeBrandId",
                table: "RepairOrders",
                column: "BikeBrandId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairOrders_BookingId",
                table: "RepairOrders",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Brands_BikeBrandId",
                table: "Bookings",
                column: "BikeBrandId",
                principalTable: "Brands",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Brands_BikeBrandId",
                table: "Bookings");

            migrationBuilder.DropTable(
                name: "RepairOrders");

            migrationBuilder.AlterColumn<int>(
                name: "BikeBrandId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ServiceType",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Brands_BikeBrandId",
                table: "Bookings",
                column: "BikeBrandId",
                principalTable: "Brands",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
