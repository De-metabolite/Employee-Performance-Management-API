using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_Performance_Management_API.Migrations
{
    /// <inheritdoc />
    public partial class AnotherProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Goals",
                table: "PerformanceReviews",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReviewerId",
                table: "PerformanceReviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "PerformanceReviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "ReviewerId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceReviews_ReviewerId",
                table: "PerformanceReviews",
                column: "ReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformanceReviews_Employees_ReviewerId",
                table: "PerformanceReviews",
                column: "ReviewerId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceReviews_Employees_ReviewerId",
                table: "PerformanceReviews");

            migrationBuilder.DropIndex(
                name: "IX_PerformanceReviews_ReviewerId",
                table: "PerformanceReviews");

            migrationBuilder.DropColumn(
                name: "Goals",
                table: "PerformanceReviews");

            migrationBuilder.DropColumn(
                name: "ReviewerId",
                table: "PerformanceReviews");

            migrationBuilder.DropColumn(
                name: "status",
                table: "PerformanceReviews");

            migrationBuilder.DropColumn(
                name: "ReviewerId",
                table: "Employees");
        }
    }
}
