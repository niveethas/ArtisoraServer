using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtisoraServer.Migrations
{
    public partial class MessageImageid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "imageId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageId",
                table: "Messages");
        }
    }
}
