using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class AddingUserPojectRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugTrackerUsers_Projects_ProjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropIndex(
                name: "IX_BugTrackerUsers_ProjectID",
                table: "BugTrackerUsers");

            migrationBuilder.AddColumn<int>(
                name: "ManagedPrjectID",
                table: "BugTrackerUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ManagedProjectID",
                table: "BugTrackerUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PrjectID",
                table: "BugTrackerUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerUsers_ManagedPrjectID",
                table: "BugTrackerUsers",
                column: "ManagedPrjectID");

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerUsers_PrjectID",
                table: "BugTrackerUsers",
                column: "PrjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_BugTrackerUsers_Projects_ManagedPrjectID",
                table: "BugTrackerUsers",
                column: "ManagedPrjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BugTrackerUsers_Projects_PrjectID",
                table: "BugTrackerUsers",
                column: "PrjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugTrackerUsers_Projects_ManagedPrjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BugTrackerUsers_Projects_PrjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropIndex(
                name: "IX_BugTrackerUsers_ManagedPrjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropIndex(
                name: "IX_BugTrackerUsers_PrjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropColumn(
                name: "ManagedPrjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropColumn(
                name: "ManagedProjectID",
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
    }
}
