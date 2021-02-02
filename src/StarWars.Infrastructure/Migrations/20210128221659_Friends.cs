using Microsoft.EntityFrameworkCore.Migrations;

namespace StarWars.Infrastructure.Migrations
{
    public partial class Friends : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharacterCharacter",
                columns: table => new
                {
                    FriendOfID = table.Column<int>(type: "int", nullable: false),
                    FriendsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterCharacter", x => new { x.FriendOfID, x.FriendsID });
                    table.ForeignKey(
                        name: "FK_CharacterCharacter_Characters_FriendOfID",
                        column: x => x.FriendOfID,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterCharacter_Characters_FriendsID",
                        column: x => x.FriendsID,
                        principalTable: "Characters",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CharacterCharacter_FriendsID",
                table: "CharacterCharacter",
                column: "FriendsID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CharacterCharacter");
        }
    }
}
