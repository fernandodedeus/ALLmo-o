using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ALLmoco.Migrations
{
    /// <inheritdoc />
    public partial class adddidnoteat : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "DidNotEat",
                table: "MealChecks",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DidNotEat",
                table: "MealChecks");
        }
    }
}
