using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class AddingNotificationsToDatabase_Fixing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_BugTrackerUsers_BugTrackerUserID",
                table: "Notification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notification",
                table: "Notification");

            migrationBuilder.RenameTable(
                name: "Notification",
                newName: "Notifications");

            migrationBuilder.RenameIndex(
                name: "IX_Notification_BugTrackerUserID",
                table: "Notifications",
                newName: "IX_Notifications_BugTrackerUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_BugTrackerUsers_BugTrackerUserID",
                table: "Notifications",
                column: "BugTrackerUserID",
                principalTable: "BugTrackerUsers",
                principalColumn: "BugTrackerUserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_BugTrackerUsers_BugTrackerUserID",
                table: "Notifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Notifications",
                table: "Notifications");

            migrationBuilder.RenameTable(
                name: "Notifications",
                newName: "Notification");

            migrationBuilder.RenameIndex(
                name: "IX_Notifications_BugTrackerUserID",
                table: "Notification",
                newName: "IX_Notification_BugTrackerUserID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notification",
                table: "Notification",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_BugTrackerUsers_BugTrackerUserID",
                table: "Notification",
                column: "BugTrackerUserID",
                principalTable: "BugTrackerUsers",
                principalColumn: "BugTrackerUserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
