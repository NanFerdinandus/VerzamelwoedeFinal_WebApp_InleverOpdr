using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApp_TestApp_W3_InlvrOpdr.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedPostzegel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Waarde",
                table: "Postzegels",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Waarde",
                table: "Postzegels");
        }
    }
}
