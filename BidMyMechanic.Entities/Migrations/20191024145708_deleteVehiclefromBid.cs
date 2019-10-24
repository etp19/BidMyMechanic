using Microsoft.EntityFrameworkCore.Migrations;

namespace BidMyMechanic.Entities.Migrations
{
    public partial class deleteVehiclefromBid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Vehicles_VehicleId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_VehicleId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "Bids");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "Bids",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bids_VehicleId",
                table: "Bids",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Vehicles_VehicleId",
                table: "Bids",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
