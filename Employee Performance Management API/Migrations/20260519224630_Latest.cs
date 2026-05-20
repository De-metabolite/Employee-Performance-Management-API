using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee_Performance_Management_API.Migrations
{
    /// <inheritdoc />
    public partial class Latest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceReviews_Employees_ReviewerId",
                table: "PerformanceReviews");

            migrationBuilder.RenameColumn(
                name: "ReviewerId",
                table: "PerformanceReviews",
                newName: "PerformanceReviewId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformanceReviews_ReviewerId",
                table: "PerformanceReviews",
                newName: "IX_PerformanceReviews_PerformanceReviewId");

            migrationBuilder.RenameColumn(
                name: "ReviewerId",
                table: "Employees",
                newName: "PerformanceReviewId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformanceReviews_Employees_PerformanceReviewId",
                table: "PerformanceReviews",
                column: "PerformanceReviewId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PerformanceReviews_Employees_PerformanceReviewId",
                table: "PerformanceReviews");

            migrationBuilder.RenameColumn(
                name: "PerformanceReviewId",
                table: "PerformanceReviews",
                newName: "ReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_PerformanceReviews_PerformanceReviewId",
                table: "PerformanceReviews",
                newName: "IX_PerformanceReviews_ReviewerId");

            migrationBuilder.RenameColumn(
                name: "PerformanceReviewId",
                table: "Employees",
                newName: "ReviewerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PerformanceReviews_Employees_ReviewerId",
                table: "PerformanceReviews",
                column: "ReviewerId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
