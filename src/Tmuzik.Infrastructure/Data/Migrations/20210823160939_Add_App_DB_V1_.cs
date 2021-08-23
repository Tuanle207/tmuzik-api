using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Migrations
{
    public partial class Add_App_DB_V1_ : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArtist",
                schema: "TMuzik",
                table: "UserProfile",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPremium",
                schema: "TMuzik",
                table: "UserProfile",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                schema: "Identity",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Artist",
                schema: "TMuzik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Avatar = table.Column<string>(type: "text", nullable: true),
                    Cover = table.Column<string>(type: "text", nullable: true),
                    FacebookUrl = table.Column<string>(type: "text", nullable: true),
                    InstagramUrl = table.Column<string>(type: "text", nullable: true),
                    TwitterUrl = table.Column<string>(type: "text", nullable: true),
                    YoutubeUrl = table.Column<string>(type: "text", nullable: true),
                    Photo = table.Column<ArtistPhotos>(type: "jsonb", nullable: true),
                    Verified = table.Column<bool>(type: "boolean", nullable: false),
                    Plays = table.Column<int>(type: "integer", nullable: false),
                    Follows = table.Column<int>(type: "integer", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artist_UserProfile_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "TMuzik",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Playlist",
                schema: "TMuzik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Cover = table.Column<string>(type: "text", nullable: true),
                    Privacy = table.Column<string>(type: "text", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Playlist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Playlist_UserProfile_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "TMuzik",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                schema: "TMuzik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Cover = table.Column<string>(type: "text", nullable: true),
                    Privacy = table.Column<string>(type: "text", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    ArtistId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Album", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Album_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalSchema: "TMuzik",
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Album_UserProfile_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "TMuzik",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArtistSnapshot",
                schema: "TMuzik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ArtistId = table.Column<Guid>(type: "uuid", nullable: false),
                    Plays = table.Column<int>(type: "integer", nullable: false),
                    Loves = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistSnapshot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArtistSnapshot_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalSchema: "TMuzik",
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Audio",
                schema: "TMuzik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Length = table.Column<int>(type: "integer", nullable: false),
                    Genre = table.Column<AudioGenre>(type: "jsonb", nullable: true),
                    Plays = table.Column<int>(type: "integer", nullable: false),
                    Loves = table.Column<int>(type: "integer", nullable: false),
                    Privacy = table.Column<string>(type: "text", nullable: true),
                    FromArtist = table.Column<bool>(type: "boolean", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    Artists = table.Column<string>(type: "text", nullable: true),
                    ArtistId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Audio_Artist_ArtistId",
                        column: x => x.ArtistId,
                        principalSchema: "TMuzik",
                        principalTable: "Artist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Audio_UserProfile_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "TMuzik",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouritePlaylist",
                schema: "TMuzik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlaylistId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouritePlaylist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouritePlaylist_Playlist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalSchema: "TMuzik",
                        principalTable: "Playlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouritePlaylist_UserProfile_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "TMuzik",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SharedPlaylist",
                schema: "TMuzik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    GrantedId = table.Column<Guid>(type: "uuid", nullable: false),
                    PlaylistId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedPlaylist", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharedPlaylist_Playlist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalSchema: "TMuzik",
                        principalTable: "Playlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharedPlaylist_UserProfile_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "TMuzik",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharedPlaylist_UserProfile_GrantedId",
                        column: x => x.GrantedId,
                        principalSchema: "TMuzik",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumSnapshot",
                schema: "TMuzik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AlbumId = table.Column<Guid>(type: "uuid", nullable: false),
                    Plays = table.Column<int>(type: "integer", nullable: false),
                    Loves = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumSnapshot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumSnapshot_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalSchema: "TMuzik",
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteAlbum",
                schema: "TMuzik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AlbumId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteAlbum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteAlbum_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalSchema: "TMuzik",
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteAlbum_UserProfile_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "TMuzik",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SharedAlbum",
                schema: "TMuzik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    GrantedId = table.Column<Guid>(type: "uuid", nullable: false),
                    AlbumId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedAlbum", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharedAlbum_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalSchema: "TMuzik",
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharedAlbum_UserProfile_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "TMuzik",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharedAlbum_UserProfile_GrantedId",
                        column: x => x.GrantedId,
                        principalSchema: "TMuzik",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlbumItem",
                schema: "TMuzik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AlbumId = table.Column<Guid>(type: "uuid", nullable: false),
                    AudioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlbumItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlbumItem_Album_AlbumId",
                        column: x => x.AlbumId,
                        principalSchema: "TMuzik",
                        principalTable: "Album",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlbumItem_Audio_AudioId",
                        column: x => x.AudioId,
                        principalSchema: "TMuzik",
                        principalTable: "Audio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AudioSnapshot",
                schema: "TMuzik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AudioId = table.Column<Guid>(type: "uuid", nullable: false),
                    Plays = table.Column<int>(type: "integer", nullable: false),
                    Loves = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioSnapshot", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AudioSnapshot_Audio_AudioId",
                        column: x => x.AudioId,
                        principalSchema: "TMuzik",
                        principalTable: "Audio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FavouriteAudio",
                schema: "TMuzik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    AudioId = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteAudio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteAudio_Audio_AudioId",
                        column: x => x.AudioId,
                        principalSchema: "TMuzik",
                        principalTable: "Audio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FavouriteAudio_UserProfile_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "TMuzik",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PlaylistItem",
                schema: "TMuzik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PlaylistId = table.Column<Guid>(type: "uuid", nullable: false),
                    AudioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlaylistItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PlaylistItem_Audio_AudioId",
                        column: x => x.AudioId,
                        principalSchema: "TMuzik",
                        principalTable: "Audio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PlaylistItem_Playlist_PlaylistId",
                        column: x => x.PlaylistId,
                        principalSchema: "TMuzik",
                        principalTable: "Playlist",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SharedAudio",
                schema: "TMuzik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    GrantedId = table.Column<Guid>(type: "uuid", nullable: false),
                    AudioId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedAudio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharedAudio_Audio_AudioId",
                        column: x => x.AudioId,
                        principalSchema: "TMuzik",
                        principalTable: "Audio",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharedAudio_UserProfile_CreatorId",
                        column: x => x.CreatorId,
                        principalSchema: "TMuzik",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharedAudio_UserProfile_GrantedId",
                        column: x => x.GrantedId,
                        principalSchema: "TMuzik",
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_ArtistId",
                schema: "TMuzik",
                table: "Album",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Album_CreatorId",
                schema: "TMuzik",
                table: "Album",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumItem_AlbumId",
                schema: "TMuzik",
                table: "AlbumItem",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumItem_AudioId",
                schema: "TMuzik",
                table: "AlbumItem",
                column: "AudioId");

            migrationBuilder.CreateIndex(
                name: "IX_AlbumSnapshot_AlbumId",
                schema: "TMuzik",
                table: "AlbumSnapshot",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_Artist_CreatorId",
                schema: "TMuzik",
                table: "Artist",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_ArtistSnapshot_ArtistId",
                schema: "TMuzik",
                table: "ArtistSnapshot",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Audio_ArtistId",
                schema: "TMuzik",
                table: "Audio",
                column: "ArtistId");

            migrationBuilder.CreateIndex(
                name: "IX_Audio_CreatorId",
                schema: "TMuzik",
                table: "Audio",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_AudioSnapshot_AudioId",
                schema: "TMuzik",
                table: "AudioSnapshot",
                column: "AudioId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteAlbum_AlbumId",
                schema: "TMuzik",
                table: "FavouriteAlbum",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteAlbum_CreatorId",
                schema: "TMuzik",
                table: "FavouriteAlbum",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteAudio_AudioId",
                schema: "TMuzik",
                table: "FavouriteAudio",
                column: "AudioId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteAudio_CreatorId",
                schema: "TMuzik",
                table: "FavouriteAudio",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouritePlaylist_CreatorId",
                schema: "TMuzik",
                table: "FavouritePlaylist",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouritePlaylist_PlaylistId",
                schema: "TMuzik",
                table: "FavouritePlaylist",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_Playlist_CreatorId",
                schema: "TMuzik",
                table: "Playlist",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistItem_AudioId",
                schema: "TMuzik",
                table: "PlaylistItem",
                column: "AudioId");

            migrationBuilder.CreateIndex(
                name: "IX_PlaylistItem_PlaylistId",
                schema: "TMuzik",
                table: "PlaylistItem",
                column: "PlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedAlbum_AlbumId",
                schema: "TMuzik",
                table: "SharedAlbum",
                column: "AlbumId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedAlbum_CreatorId",
                schema: "TMuzik",
                table: "SharedAlbum",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedAlbum_GrantedId",
                schema: "TMuzik",
                table: "SharedAlbum",
                column: "GrantedId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedAudio_AudioId",
                schema: "TMuzik",
                table: "SharedAudio",
                column: "AudioId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedAudio_CreatorId",
                schema: "TMuzik",
                table: "SharedAudio",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedAudio_GrantedId",
                schema: "TMuzik",
                table: "SharedAudio",
                column: "GrantedId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedPlaylist_CreatorId",
                schema: "TMuzik",
                table: "SharedPlaylist",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedPlaylist_GrantedId",
                schema: "TMuzik",
                table: "SharedPlaylist",
                column: "GrantedId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedPlaylist_PlaylistId",
                schema: "TMuzik",
                table: "SharedPlaylist",
                column: "PlaylistId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlbumItem",
                schema: "TMuzik");

            migrationBuilder.DropTable(
                name: "AlbumSnapshot",
                schema: "TMuzik");

            migrationBuilder.DropTable(
                name: "ArtistSnapshot",
                schema: "TMuzik");

            migrationBuilder.DropTable(
                name: "AudioSnapshot",
                schema: "TMuzik");

            migrationBuilder.DropTable(
                name: "FavouriteAlbum",
                schema: "TMuzik");

            migrationBuilder.DropTable(
                name: "FavouriteAudio",
                schema: "TMuzik");

            migrationBuilder.DropTable(
                name: "FavouritePlaylist",
                schema: "TMuzik");

            migrationBuilder.DropTable(
                name: "PlaylistItem",
                schema: "TMuzik");

            migrationBuilder.DropTable(
                name: "SharedAlbum",
                schema: "TMuzik");

            migrationBuilder.DropTable(
                name: "SharedAudio",
                schema: "TMuzik");

            migrationBuilder.DropTable(
                name: "SharedPlaylist",
                schema: "TMuzik");

            migrationBuilder.DropTable(
                name: "Album",
                schema: "TMuzik");

            migrationBuilder.DropTable(
                name: "Audio",
                schema: "TMuzik");

            migrationBuilder.DropTable(
                name: "Playlist",
                schema: "TMuzik");

            migrationBuilder.DropTable(
                name: "Artist",
                schema: "TMuzik");

            migrationBuilder.DropColumn(
                name: "IsArtist",
                schema: "TMuzik",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "IsPremium",
                schema: "TMuzik",
                table: "UserProfile");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                schema: "Identity",
                table: "User",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");
        }
    }
}
