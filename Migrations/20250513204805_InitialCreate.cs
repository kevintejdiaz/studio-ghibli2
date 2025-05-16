using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace projectoFinalV2.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Films",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    title = table.Column<string>(type: "TEXT", nullable: false),
                    original_title = table.Column<string>(type: "TEXT", nullable: false),
                    original_title_romanised = table.Column<string>(type: "TEXT", nullable: false),
                    image = table.Column<string>(type: "TEXT", nullable: false),
                    movie_banner = table.Column<string>(type: "TEXT", nullable: false),
                    description = table.Column<string>(type: "TEXT", nullable: false),
                    director = table.Column<string>(type: "TEXT", nullable: false),
                    producer = table.Column<string>(type: "TEXT", nullable: false),
                    release_date = table.Column<string>(type: "TEXT", nullable: false),
                    running_time = table.Column<string>(type: "TEXT", nullable: false),
                    rt_score = table.Column<string>(type: "TEXT", nullable: false),
                    people = table.Column<string>(type: "TEXT", nullable: false),
                    species = table.Column<string>(type: "TEXT", nullable: false),
                    locations = table.Column<string>(type: "TEXT", nullable: false),
                    vehicles = table.Column<string>(type: "TEXT", nullable: false),
                    url = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Films", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    id = table.Column<string>(type: "TEXT", nullable: false),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    gender = table.Column<string>(type: "TEXT", nullable: false),
                    age = table.Column<string>(type: "TEXT", nullable: false),
                    eye_color = table.Column<string>(type: "TEXT", nullable: false),
                    hair_color = table.Column<string>(type: "TEXT", nullable: false),
                    films = table.Column<string>(type: "TEXT", nullable: false),
                    species = table.Column<string>(type: "TEXT", nullable: false),
                    url = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Films");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
