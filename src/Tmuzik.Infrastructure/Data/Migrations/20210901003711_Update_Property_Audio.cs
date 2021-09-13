using Microsoft.EntityFrameworkCore.Migrations;

namespace Tmuzik.Infrastructure.Data.Migrations
{
    public partial class Update_Property_Audio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Artists",
                schema: "TMuzik",
                table: "Audio",
                newName: "ArtistTag");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ArtistTag",
                schema: "TMuzik",
                table: "Audio",
                newName: "Artists");
        }
    }
}
