using Microsoft.EntityFrameworkCore.Migrations;

namespace Tmuzik.Infrastructure.Data.Migrations
{
    public partial class Update_Audio_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cover",
                schema: "TMuzik",
                table: "Audio",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "File",
                schema: "TMuzik",
                table: "Audio",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cover",
                schema: "TMuzik",
                table: "Audio");

            migrationBuilder.DropColumn(
                name: "File",
                schema: "TMuzik",
                table: "Audio");
        }
    }
}
