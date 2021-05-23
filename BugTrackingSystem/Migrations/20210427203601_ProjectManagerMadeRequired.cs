using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class ProjectManagerMadeRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_BugTrackerUsers_ManagerID",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerID",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_BugTrackerUsers_ManagerID",
                table: "Projects",
                column: "ManagerID",
                principalTable: "BugTrackerUsers",
                principalColumn: "BugTrackerUserID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_BugTrackerUsers_ManagerID",
                table: "Projects");

            migrationBuilder.AlterColumn<string>(
                name: "ManagerID",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_BugTrackerUsers_ManagerID",
                table: "Projects",
                column: "ManagerID",
                principalTable: "BugTrackerUsers",
                principalColumn: "BugTrackerUserID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
