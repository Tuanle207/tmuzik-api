using Microsoft.EntityFrameworkCore.Migrations;
using Tmuzik.Core.Entities;

namespace Tmuzik.Infrastructure.Data.Migrations
{
    public partial class Update_Audio_Genre_Property : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Genre",
                schema: "TMuzik",
                table: "Audio",
                type: "text",
                nullable: true,
                oldClrType: typeof(AudioGenre),
                oldType: "jsonb",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<AudioGenre>(
                name: "Genre",
                schema: "TMuzik",
                table: "Audio",
                type: "jsonb",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
