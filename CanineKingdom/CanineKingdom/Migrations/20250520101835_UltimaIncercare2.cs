using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CanineKingdom.Migrations
{
    /// <inheritdoc />
    public partial class UltimaIncercare2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentReactions_AspNetUsers_UserAccountNumber",
                table: "CommentReactions");

            migrationBuilder.DropIndex(
                name: "IX_CommentReactions_UserAccountNumber",
                table: "CommentReactions");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CommentReactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CommentReactions_UserId",
                table: "CommentReactions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReactions_AspNetUsers_UserId",
                table: "CommentReactions",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentReactions_AspNetUsers_UserId",
                table: "CommentReactions");

            migrationBuilder.DropIndex(
                name: "IX_CommentReactions_UserId",
                table: "CommentReactions");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CommentReactions");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReactions_UserAccountNumber",
                table: "CommentReactions",
                column: "UserAccountNumber");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReactions_AspNetUsers_UserAccountNumber",
                table: "CommentReactions",
                column: "UserAccountNumber",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
