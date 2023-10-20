using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_TestApp_W3_InlvrOpdr.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedAppDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forum",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naam = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beschrijving = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forum", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bericht",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuteurId = table.Column<int>(type: "int", nullable: true),
                    Inhoud = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datum = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ForumId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bericht", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bericht_Forum_ForumId",
                        column: x => x.ForumId,
                        principalTable: "Forum",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bericht_Gebruikers_AuteurId",
                        column: x => x.AuteurId,
                        principalTable: "Gebruikers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bericht_AuteurId",
                table: "Bericht",
                column: "AuteurId");

            migrationBuilder.CreateIndex(
                name: "IX_Bericht_ForumId",
                table: "Bericht",
                column: "ForumId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bericht");

            migrationBuilder.DropTable(
                name: "Forum");
        }
    }
}
