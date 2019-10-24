using Microsoft.EntityFrameworkCore.Migrations;

namespace BidMyMechanic.Entities.Migrations
{
    public partial class fixBidEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Issues",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "IssueId",
                table: "Bids",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bids_IssueId",
                table: "Bids",
                column: "IssueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bids_Issues_IssueId",
                table: "Bids",
                column: "IssueId",
                principalTable: "Issues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bids_Issues_IssueId",
                table: "Bids");

            migrationBuilder.DropIndex(
                name: "IX_Bids_IssueId",
                table: "Bids");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Issues");

            migrationBuilder.DropColumn(
                name: "IssueId",
                table: "Bids");
        }
    }
}
