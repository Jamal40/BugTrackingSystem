using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class FixingIssues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugTrackerUsers_Project_ProjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_BugTrackerUsers_Tickets_TicketID",
                table: "BugTrackerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_BugTrackerUsers_ManagerID",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Project_ProjectID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_BugTrackerUsers_TicketID",
                table: "BugTrackerUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Project",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "TicketID",
                table: "BugTrackerUsers");

            migrationBuilder.RenameTable(
                name: "Project",
                newName: "Projects");

            migrationBuilder.RenameIndex(
                name: "IX_Project_ManagerID",
                table: "Projects",
                newName: "IX_Projects_ManagerID");

            migrationBuilder.AddColumn<string>(
                name: "DeveloperID",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_DeveloperID",
                table: "Tickets",
                column: "DeveloperID");

            migrationBuilder.AddForeignKey(
                name: "FK_BugTrackerUsers_Projects_ProjectID",
                table: "BugTrackerUsers",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_BugTrackerUsers_ManagerID",
                table: "Projects",
                column: "ManagerID",
                principalTable: "BugTrackerUsers",
                principalColumn: "BugTrackerUserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_BugTrackerUsers_DeveloperID",
                table: "Tickets",
                column: "DeveloperID",
                principalTable: "BugTrackerUsers",
                principalColumn: "BugTrackerUserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Projects_ProjectID",
                table: "Tickets",
                column: "ProjectID",
                principalTable: "Projects",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugTrackerUsers_Projects_ProjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Projects_BugTrackerUsers_ManagerID",
                table: "Projects");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_BugTrackerUsers_DeveloperID",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Projects_ProjectID",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_DeveloperID",
                table: "Tickets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "DeveloperID",
                table: "Tickets");

            migrationBuilder.RenameTable(
                name: "Projects",
                newName: "Project");

            migrationBuilder.RenameIndex(
                name: "IX_Projects_ManagerID",
                table: "Project",
                newName: "IX_Project_ManagerID");

            migrationBuilder.AddColumn<int>(
                name: "TicketID",
                table: "BugTrackerUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Project",
                table: "Project",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerUsers_TicketID",
                table: "BugTrackerUsers",
                column: "TicketID");

            migrationBuilder.AddForeignKey(
                name: "FK_BugTrackerUsers_Project_ProjectID",
                table: "BugTrackerUsers",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BugTrackerUsers_Tickets_TicketID",
                table: "BugTrackerUsers",
                column: "TicketID",
                principalTable: "Tickets",
                principalColumn: "TicketID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_BugTrackerUsers_ManagerID",
                table: "Project",
                column: "ManagerID",
                principalTable: "BugTrackerUsers",
                principalColumn: "BugTrackerUserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_Project_ProjectID",
                table: "Tickets",
                column: "ProjectID",
                principalTable: "Project",
                principalColumn: "ProjectID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
