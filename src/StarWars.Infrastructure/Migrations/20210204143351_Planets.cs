using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWars.Infrastructure.Migrations
{
    public partial class Planets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Planet",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "PlanetID",
                table: "Characters",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Planet",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planet", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlanetID",
                table: "Characters",
                column: "PlanetID");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Planet_PlanetID",
                table: "Characters",
                column: "PlanetID",
                principalTable: "Planet",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Planet_PlanetID",
                table: "Characters");

            migrationBuilder.DropTable(
                name: "Planet");

            migrationBuilder.DropIndex(
                name: "IX_Characters_PlanetID",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "PlanetID",
                table: "Characters");

            migrationBuilder.AddColumn<string>(
                name: "Planet",
                table: "Characters",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
