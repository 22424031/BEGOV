using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ward.Persistent.Migrations
{
    public partial class addfeedbackreportwarm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Feedback",
                table: "ReportWarm",
                type: "varchar(300)",
                maxLength: 300,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ReportWarm",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Feedback",
                table: "ReportWarm");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ReportWarm");
        }
    }
}
