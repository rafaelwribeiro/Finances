using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancesAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddedMovementType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Movement",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 14, 23, 12, 25, 43, DateTimeKind.Utc).AddTicks(1294),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 1, 14, 21, 50, 27, 129, DateTimeKind.Utc).AddTicks(8464));

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Movement",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Movement");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Movement",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 1, 14, 21, 50, 27, 129, DateTimeKind.Utc).AddTicks(8464),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 1, 14, 23, 12, 25, 43, DateTimeKind.Utc).AddTicks(1294));
        }
    }
}
