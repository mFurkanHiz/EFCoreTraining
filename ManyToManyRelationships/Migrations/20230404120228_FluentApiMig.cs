using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ManyToManyRelationships.Migrations
{
    /// <inheritdoc />
    public partial class FluentApiMig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YazarKitap_Authors_AId",
                table: "YazarKitap");

            migrationBuilder.DropForeignKey(
                name: "FK_YazarKitap_Books_BId",
                table: "YazarKitap");

            migrationBuilder.RenameColumn(
                name: "BId",
                table: "YazarKitap",
                newName: "BookId");

            migrationBuilder.RenameColumn(
                name: "AId",
                table: "YazarKitap",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_YazarKitap_BId",
                table: "YazarKitap",
                newName: "IX_YazarKitap_BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_YazarKitap_Authors_AuthorId",
                table: "YazarKitap",
                column: "AuthorId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_YazarKitap_Books_BookId",
                table: "YazarKitap",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_YazarKitap_Authors_AuthorId",
                table: "YazarKitap");

            migrationBuilder.DropForeignKey(
                name: "FK_YazarKitap_Books_BookId",
                table: "YazarKitap");

            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "YazarKitap",
                newName: "BId");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "YazarKitap",
                newName: "AId");

            migrationBuilder.RenameIndex(
                name: "IX_YazarKitap_BookId",
                table: "YazarKitap",
                newName: "IX_YazarKitap_BId");

            migrationBuilder.AddForeignKey(
                name: "FK_YazarKitap_Authors_AId",
                table: "YazarKitap",
                column: "AId",
                principalTable: "Authors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_YazarKitap_Books_BId",
                table: "YazarKitap",
                column: "BId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
