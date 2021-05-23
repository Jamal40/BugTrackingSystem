using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class FixingTypoAgain : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugTrackerUsers_Projects_PrjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropIndex(
                name: "IX_BugTrackerUsers_PrjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropColumn(
                name: "PrjectID",
                table: "BugTrackerUsers");

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerUsers_ProjectID",
                table: "BugTrackerUsers",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_BugTrackerUsers_Projects_ProjectID",
                table: "BugTrackerUsers",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugTrackerUsers_Projects_ProjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropIndex(
                name: "IX_BugTrackerUsers_ProjectID",
                table: "BugTrackerUsers");

            migrationBuilder.AddColumn<int>(
                name: "PrjectID",
                table: "BugTrackerUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerUsers_PrjectID",
                table: "BugTrackerUsers",
                column: "PrjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_BugTrackerUsers_Projects_PrjectID",
                table: "BugTrackerUsers",
                column: "PrjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
