using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_Performance_Management_API.Migrations
{
    /// <inheritdoc />
    public partial class Latestmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceReviews_Employees_PerformanceReviewId",
                table: "PerformanceReviews");

            migrationBuilder.DropIndex(
                name: "IX_PerformanceReviews_PerformanceReviewId",
                table: "PerformanceReviews");

            migrationBuilder.DropColumn(
                name: "PerformanceReviewId",
                table: "PerformanceReviews");

            migrationBuilder.DropColumn(
                name: "PerformanceReviewId",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PerformanceReviewId",
                table: "PerformanceReviews",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PerformanceReviewId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PerformanceReviews_PerformanceReviewId",
                table: "PerformanceReviews",
                column: "PerformanceReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformanceReviews_Employees_PerformanceReviewId",
                table: "PerformanceReviews",
                column: "PerformanceReviewId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
