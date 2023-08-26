using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FinancesAPI.Migrations
{
    /// <inheritdoc />
    public partial class StatusGroup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Movements",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 23, 0, 0, 20, 129, DateTimeKind.Utc).AddTicks(6722),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 8, 22, 17, 57, 40, 746, DateTimeKind.Utc).AddTicks(5017));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Groups",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Groups");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Movements",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 22, 17, 57, 40, 746, DateTimeKind.Utc).AddTicks(5017),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 8, 23, 0, 0, 20, 129, DateTimeKind.Utc).AddTicks(6722));
        }
    }
}
