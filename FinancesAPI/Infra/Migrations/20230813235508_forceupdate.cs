using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancesAPI.Migrations
{
    /// <inheritdoc />
    public partial class forceupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Movement",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 13, 23, 55, 8, 627, DateTimeKind.Utc).AddTicks(1171),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 5, 1, 19, 11, 50, 318, DateTimeKind.Utc).AddTicks(5385));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Movement",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 5, 1, 19, 11, 50, 318, DateTimeKind.Utc).AddTicks(5385),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 8, 13, 23, 55, 8, 627, DateTimeKind.Utc).AddTicks(1171));
        }
    }
}
