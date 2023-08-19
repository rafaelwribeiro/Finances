using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancesAPI.Migrations
{
    /// <inheritdoc />
    public partial class userautoincrement2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Movement",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 14, 0, 4, 54, 173, DateTimeKind.Utc).AddTicks(495),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 8, 14, 0, 2, 28, 292, DateTimeKind.Utc).AddTicks(9610));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Movement",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 14, 0, 2, 28, 292, DateTimeKind.Utc).AddTicks(9610),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 8, 14, 0, 4, 54, 173, DateTimeKind.Utc).AddTicks(495));
        }
    }
}
