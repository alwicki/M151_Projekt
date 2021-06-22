using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Data.Migrations
{
    public partial class reports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PenaltyPoints",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TargetTopic = table.Column<string>(type: "text", nullable: true),
                    TargetId = table.Column<int>(type: "integer", nullable: false),
                    ReportingUserUserId = table.Column<int>(type: "integer", nullable: true),
                    ReportedUserUserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_Users_ReportedUserUserId",
                        column: x => x.ReportedUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reports_Users_ReportingUserUserId",
                        column: x => x.ReportingUserUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportedUserUserId",
                table: "Reports",
                column: "ReportedUserUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ReportingUserUserId",
                table: "Reports",
                column: "ReportingUserUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropColumn(
                name: "PenaltyPoints",
                table: "Users");
        }
    }
}
