using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ALLmoco.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MealChecks",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MealChecks_UserId",
                table: "MealChecks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MealChecks_Users_UserId",
                table: "MealChecks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealChecks_Users_UserId",
                table: "MealChecks");

            migrationBuilder.DropIndex(
                name: "IX_MealChecks_UserId",
                table: "MealChecks");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MealChecks");
        }
    }
}
