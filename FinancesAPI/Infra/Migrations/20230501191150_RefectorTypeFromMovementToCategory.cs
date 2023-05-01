using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancesAPI.Migrations
{
    /// <inheritdoc />
    public partial class RefectorTypeFromMovementToCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Movement");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Movement",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 1, 19, 11, 50, 318, DateTimeKind.Utc).AddTicks(5385),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 5, 1, 17, 43, 0, 623, DateTimeKind.Utc).AddTicks(2518));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Category",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Category");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Movement",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 1, 17, 43, 0, 623, DateTimeKind.Utc).AddTicks(2518),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 5, 1, 19, 11, 50, 318, DateTimeKind.Utc).AddTicks(5385));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Movement",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
