using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CanineKingdom.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ArticleComments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "ArticleComments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
