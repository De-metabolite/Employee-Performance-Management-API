using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_Performance_Management_API.Migrations
{
    /// <inheritdoc />
    public partial class HiredDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "HiredDate",
                table: "Employees",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HiredDate",
                table: "Employees");
        }
    }
}
