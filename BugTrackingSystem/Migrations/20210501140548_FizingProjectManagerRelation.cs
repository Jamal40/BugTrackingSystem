using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class FizingProjectManagerRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugTrackerUsers_Projects_ManagedProjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ManagerID",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_BugTrackerUsers_ManagedProjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropColumn(
                name: "ManagedProjectID",
                table: "BugTrackerUsers");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ManagerID",
                table: "Projects",
                column: "ManagerID",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Projects_ManagerID",
                table: "Projects");

            migrationBuilder.AddColumn<int>(
                name: "ManagedProjectID",
                table: "BugTrackerUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ManagerID",
                table: "Projects",
                column: "ManagerID");

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
    }
}
