using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Tmuzik.Infrastructure.Data.Migrations
{
    public partial class Add_Follow_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ArtistFollow",
                schema: "TMuzik",
                columns: table => new
                {
                    ArtistId = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistFollow", x => new { x.ArtistId, x.FollowerId });
                    table.ForeignKey(
                        name: "FK_ArtistFollow_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalSchema: "TMuzik",
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistFollow_UserProfile_FollowerId",
                        column: x => x.FollowerId,
                        principalSchema: "TMuzik",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserFollow",
                schema: "TMuzik",
                columns: table => new
                {
                    FolloweeId = table.Column<Guid>(type: "uuid", nullable: false),
                    FollowerId = table.Column<Guid>(type: "uuid", nullable: false),
                    Id = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFollow", x => new { x.FolloweeId, x.FollowerId });
                    table.ForeignKey(
                        name: "FK_UserFollow_UserProfile_FolloweeId",
                        column: x => x.FolloweeId,
                        principalSchema: "TMuzik",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFollow_UserProfile_FollowerId",
                        column: x => x.FollowerId,
                        principalSchema: "TMuzik",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistFollow_FollowerId",
                schema: "TMuzik",
                table: "ArtistFollow",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserFollow_FollowerId",
                schema: "TMuzik",
                table: "UserFollow",
                column: "FollowerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Audio_Album_ArtistId",
                schema: "TMuzik",
                table: "Audio",
                column: "ArtistId",
                principalSchema: "TMuzik",
                principalTable: "Album",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Audio_Album_ArtistId",
                schema: "TMuzik",
                table: "Audio");

            migrationBuilder.DropTable(
                name: "ArtistFollow",
                schema: "TMuzik");

            migrationBuilder.DropTable(
                name: "UserFollow",
                schema: "TMuzik");

            migrationBuilder.AddColumn<Guid>(
                name: "AlbumId",
                schema: "TMuzik",
                table: "Audio",
                type: "uuid",
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
    }
}
