using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ward.Persistent.Migrations
{
    public partial class add_column_baseentity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "last_update",
                table: "Ads",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Ads",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                table: "Ads",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedDate",
                table: "Ads",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Ads",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Ads",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Ads",
                type: "datetime(6)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "DeletedDate",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Ads");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Ads");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Ads",
                newName: "last_update");
        }
    }
}
