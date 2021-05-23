using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class AddingSubmitterIDToTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SubmitterID",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_SubmitterID",
                table: "Tickets",
                column: "SubmitterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_BugTrackerUsers_SubmitterID",
                table: "Tickets",
                column: "SubmitterID",
                principalTable: "BugTrackerUsers",
                principalColumn: "BugTrackerUserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_BugTrackerUsers_SubmitterID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_SubmitterID",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "SubmitterID",
                table: "Tickets");
        }
    }
}
