using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookShopApp.WebApi.Migrations
{
    /// <inheritdoc />
    public partial class ChangePublisherDateBeginToYearBegin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DateBegin",
                table: "Publishers");

            migrationBuilder.AddColumn<int>(
                name: "YearBegin",
                table: "Publishers",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "YearBegin",
                table: "Publishers");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateBegin",
                table: "Publishers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
