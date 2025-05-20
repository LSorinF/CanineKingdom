using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CanineKingdom.Migrations
{
    /// <inheritdoc />
    public partial class UltimaIncercare : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommentReactions_ArticleComments_ArticleCommentId",
                table: "CommentReactions");

            migrationBuilder.DropTable(
                name: "ArticleComments");

            migrationBuilder.DropIndex(
                name: "IX_CommentReactions_ArticleCommentId",
                table: "CommentReactions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArticleComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleComments_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleComments_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentReactions_ArticleCommentId",
                table: "CommentReactions",
                column: "ArticleCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComments_ArticleId",
                table: "ArticleComments",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleComments_AuthorId",
                table: "ArticleComments",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_CommentReactions_ArticleComments_ArticleCommentId",
                table: "CommentReactions",
                column: "ArticleCommentId",
                principalTable: "ArticleComments",
                principalColumn: "Id");
        }
    }
}
