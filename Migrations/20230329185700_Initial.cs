using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtisoraServer.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    imageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mentorshipId = table.Column<int>(type: "int", nullable: false),
                    menteeId = table.Column<int>(type: "int", nullable: false),
                    imageURL = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.imageId);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "Mentees",
                columns: table => new
                {
                    menteeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentees", x => x.menteeId);
                });

            migrationBuilder.CreateTable(
                name: "Mentors",
                columns: table => new
                {
                    mentorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentors", x => x.mentorId);
                });

            migrationBuilder.CreateTable(
                name: "Mentorships",
                columns: table => new
                {
                    mentorshipId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    menteeId = table.Column<int>(type: "int", nullable: false),
                    mentorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mentorships", x => x.mentorshipId);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    messageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mentorshipId = table.Column<int>(type: "int", nullable: false),
                    textContent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.messageId);
                });

            migrationBuilder.CreateTable(
                name: "Showcases",
                columns: table => new
                {
                    showcaseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    mentorId = table.Column<int>(type: "int", nullable: false),
                    image1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image1Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image2Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    image3Caption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    selfDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Showcases", x => x.showcaseId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Mentees");

            migrationBuilder.DropTable(
                name: "Mentors");

            migrationBuilder.DropTable(
                name: "Mentorships");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Showcases");
        }
    }
}
