using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tmuzik.Infrastructure.Data.Migrations
{
    public partial class Add_Albumtag_Property_Audio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AlbumId",
                schema: "TMuzik",
                table: "Audio",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AlbumTag",
                schema: "TMuzik",
                table: "Audio",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Audio_AlbumId",
                schema: "TMuzik",
                table: "Audio",
                column: "AlbumId");

            migrationBuilder.AddForeignKey(
                name: "FK_Audio_Album_AlbumId",
                schema: "TMuzik",
                table: "Audio",
                column: "AlbumId",
                principalSchema: "TMuzik",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audio_Album_AlbumId",
                schema: "TMuzik",
                table: "Audio");

            migrationBuilder.DropIndex(
                name: "IX_Audio_AlbumId",
                schema: "TMuzik",
                table: "Audio");

            migrationBuilder.DropColumn(
                name: "AlbumId",
                schema: "TMuzik",
                table: "Audio");

            migrationBuilder.DropColumn(
                name: "AlbumTag",
                schema: "TMuzik",
                table: "Audio");
        }
    }
}
