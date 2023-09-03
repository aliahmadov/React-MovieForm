using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieForm.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosterUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TrailerUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionYear = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
