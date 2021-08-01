using Microsoft.EntityFrameworkCore.Migrations;

namespace Tmuzik.Data.Migrations
{
    public partial class Add_Salt_In_Users_Table : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Salt",
                schema: "Identity",
                table: "User",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Salt",
                schema: "Identity",
                table: "User");
        }
    }
}
