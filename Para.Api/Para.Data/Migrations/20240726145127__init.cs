using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Para.Data.Migrations
{
    /// <inheritdoc />
    public partial class _init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "CustomerPhone",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateUser",
                schema: "dbo",
                table: "CustomerPhone",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                schema: "dbo",
                table: "CustomerAddress",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateUser",
                schema: "dbo",
                table: "CustomerAddress",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UpdateDate",
                schema: "dbo",
                table: "CustomerPhone");

            migrationBuilder.DropColumn(
                name: "UpdateUser",
                schema: "dbo",
                table: "CustomerPhone");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                schema: "dbo",
                table: "CustomerAddress");

            migrationBuilder.DropColumn(
                name: "UpdateUser",
                schema: "dbo",
                table: "CustomerAddress");
        }
    }
}
