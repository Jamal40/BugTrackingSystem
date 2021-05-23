using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class AddingNotificationsToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BugTrackerUserID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Notification_BugTrackerUsers_BugTrackerUserID",
                        column: x => x.BugTrackerUserID,
                        principalTable: "BugTrackerUsers",
                        principalColumn: "BugTrackerUserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_BugTrackerUserID",
                table: "Notification",
                column: "BugTrackerUserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notification");
        }
    }
}
