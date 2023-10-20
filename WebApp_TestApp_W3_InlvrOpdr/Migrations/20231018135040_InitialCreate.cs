using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_TestApp_W3_InlvrOpdr.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Gebruikersnaam = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wachtwoord = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Favorieten",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GebruikerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favorieten", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Favorieten_Gebruikers_GebruikerId",
                        column: x => x.GebruikerId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Postzegels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LandVanHerkomst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Conditie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Uitgiftejaar = table.Column<int>(type: "int", nullable: false),
                    IsFavoriet = table.Column<bool>(type: "bit", nullable: false),
                    EigenaarId = table.Column<int>(type: "int", nullable: false),
                    FavorietId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Postzegels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Postzegels_Favorieten_FavorietId",
                        column: x => x.FavorietId,
                        principalTable: "Favorieten",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Postzegels_Gebruikers_EigenaarId",
                        column: x => x.EigenaarId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Categorieën",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategorieNaam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostzegelId = table.Column<int>(type: "int", nullable: true),
                    EigenaarId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorieën", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Categorieën_Gebruikers_EigenaarId",
                        column: x => x.EigenaarId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Categorieën_Postzegels_PostzegelId",
                        column: x => x.PostzegelId,
                        principalTable: "Postzegels",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categorieën_EigenaarId",
                table: "Categorieën",
                column: "EigenaarId");

            migrationBuilder.CreateIndex(
                name: "IX_Categorieën_PostzegelId",
                table: "Categorieën",
                column: "PostzegelId");

            migrationBuilder.CreateIndex(
                name: "IX_Favorieten_GebruikerId",
                table: "Favorieten",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_Postzegels_EigenaarId",
                table: "Postzegels",
                column: "EigenaarId");

            migrationBuilder.CreateIndex(
                name: "IX_Postzegels_FavorietId",
                table: "Postzegels",
                column: "FavorietId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorieën");

            migrationBuilder.DropTable(
                name: "Postzegels");

            migrationBuilder.DropTable(
                name: "Favorieten");

            migrationBuilder.DropTable(
                name: "Gebruikers");
        }
    }
}
