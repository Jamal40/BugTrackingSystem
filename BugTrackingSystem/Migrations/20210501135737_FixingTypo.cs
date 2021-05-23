using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class FixingTypo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugTrackerUsers_Projects_ManagedPrjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropIndex(
                name: "IX_BugTrackerUsers_ManagedPrjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropColumn(
                name: "ManagedPrjectID",
                table: "BugTrackerUsers");

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerUsers_ManagedProjectID",
                table: "BugTrackerUsers",
                column: "ManagedProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_BugTrackerUsers_Projects_ManagedProjectID",
                table: "BugTrackerUsers",
                column: "ManagedProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugTrackerUsers_Projects_ManagedProjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropIndex(
                name: "IX_BugTrackerUsers_ManagedProjectID",
                table: "BugTrackerUsers");

            migrationBuilder.AddColumn<int>(
                name: "ManagedPrjectID",
                table: "BugTrackerUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerUsers_ManagedPrjectID",
                table: "BugTrackerUsers",
                column: "ManagedPrjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_BugTrackerUsers_Projects_ManagedPrjectID",
                table: "BugTrackerUsers",
                column: "ManagedPrjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
