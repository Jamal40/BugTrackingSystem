using Microsoft.EntityFrameworkCore.Migrations;

namespace BugTrackingSystem.Migrations
{
    public partial class MakingAcceptableNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Accepted",
                table: "Tickets",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Accepted",
                table: "Tickets",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }
    }
}
