using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ward.Persistent.Migrations
{
    public partial class update_cloumnType_Ads : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "IsActive",
                table: "Ads",
                type: "tinyint",
                nullable: false,
                defaultValue: (sbyte)0,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "IsActive",
                table: "Ads",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint",
                oldDefaultValue: (sbyte)0);
        }
    }
}
