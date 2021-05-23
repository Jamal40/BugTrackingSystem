using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class FixingSomethinginthenotificationmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_BugTrackerUsers_BugTrackerUserID",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_BugTrackerUserID",
                table: "Notifications");

            migrationBuilder.DropColumn(
                name: "BugTrackerUserID",
                table: "Notifications");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserID",
                table: "Notifications",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_BugTrackerUsers_UserID",
                table: "Notifications",
                column: "UserID",
                principalTable: "BugTrackerUsers",
                principalColumn: "BugTrackerUserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notifications_BugTrackerUsers_UserID",
                table: "Notifications");

            migrationBuilder.DropIndex(
                name: "IX_Notifications_UserID",
                table: "Notifications");

            migrationBuilder.AlterColumn<string>(
                name: "UserID",
                table: "Notifications",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BugTrackerUserID",
                table: "Notifications",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_BugTrackerUserID",
                table: "Notifications",
                column: "BugTrackerUserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Notifications_BugTrackerUsers_BugTrackerUserID",
                table: "Notifications",
                column: "BugTrackerUserID",
                principalTable: "BugTrackerUsers",
                principalColumn: "BugTrackerUserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
