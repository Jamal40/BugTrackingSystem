using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class IntialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManagerID = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ProjectID);
                });

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    TicketID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Accepted = table.Column<bool>(type: "bit", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.TicketID);
                    table.ForeignKey(
                        name: "FK_Tickets_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BugTrackerUsers",
                columns: table => new
                {
                    BugTrackerUserID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ProjectID = table.Column<int>(type: "int", nullable: true),
                    TicketID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BugTrackerUsers", x => x.BugTrackerUserID);
                    table.ForeignKey(
                        name: "FK_BugTrackerUsers_Project_ProjectID",
                        column: x => x.ProjectID,
                        principalTable: "Project",
                        principalColumn: "ProjectID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BugTrackerUsers_Tickets_TicketID",
                        column: x => x.TicketID,
                        principalTable: "Tickets",
                        principalColumn: "TicketID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerUsers_ProjectID",
                table: "BugTrackerUsers",
                column: "ProjectID");

            migrationBuilder.CreateIndex(
                name: "IX_BugTrackerUsers_TicketID",
                table: "BugTrackerUsers",
                column: "TicketID");

            migrationBuilder.CreateIndex(
                name: "IX_Project_ManagerID",
                table: "Project",
                column: "ManagerID");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_ProjectID",
                table: "Tickets",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_BugTrackerUsers_ManagerID",
                table: "Project",
                column: "ManagerID",
                principalTable: "BugTrackerUsers",
                principalColumn: "BugTrackerUserID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BugTrackerUsers_Project_ProjectID",
                table: "BugTrackerUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Project_ProjectID",
                table: "Tickets");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "BugTrackerUsers");

            migrationBuilder.DropTable(
                name: "Tickets");
        }
    }
}
