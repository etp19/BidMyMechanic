using Microsoft.EntityFrameworkCore.Migrations;

namespace BidMyMechanic.Entities.Migrations
{
    public partial class addVehicleCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Engine",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "Year",
                table: "Vehicles",
                newName: "year");

            migrationBuilder.RenameColumn(
                name: "Model",
                table: "Vehicles",
                newName: "model");

            migrationBuilder.RenameColumn(
                name: "Make",
                table: "Vehicles",
                newName: "make");

            migrationBuilder.RenameColumn(
                name: "Drive",
                table: "Vehicles",
                newName: "drive");

            migrationBuilder.AlterColumn<string>(
                name: "year",
                table: "Vehicles",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "UCity",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UHighway",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "VClass",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "barrels08",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "city08",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "city08U",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "co2TailpipeGpm",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "comb08",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "cylinders",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "displ",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "engId",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "eng_dscr",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "feScore",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fuelCost08",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fuelCostA08",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fuelType",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "fuelType1",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "highway08",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "trans_dscr",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "trany",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "youSaveSpend",
                table: "Vehicles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UCity",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "UHighway",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VClass",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "barrels08",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "city08",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "city08U",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "co2TailpipeGpm",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "comb08",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "cylinders",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "displ",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "engId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "eng_dscr",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "feScore",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "fuelCost08",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "fuelCostA08",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "fuelType",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "fuelType1",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "highway08",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "trans_dscr",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "trany",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "youSaveSpend",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "year",
                table: "Vehicles",
                newName: "Year");

            migrationBuilder.RenameColumn(
                name: "model",
                table: "Vehicles",
                newName: "Model");

            migrationBuilder.RenameColumn(
                name: "make",
                table: "Vehicles",
                newName: "Make");

            migrationBuilder.RenameColumn(
                name: "drive",
                table: "Vehicles",
                newName: "Drive");

            migrationBuilder.AlterColumn<int>(
                name: "Year",
                table: "Vehicles",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Engine",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
