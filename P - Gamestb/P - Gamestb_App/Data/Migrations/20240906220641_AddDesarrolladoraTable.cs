﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace P___Gamestb_App.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddDesarrolladoraTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desarrolladora",
                columns: table => new
                {
                    DesarrolladoraID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desarrolladora", x => x.DesarrolladoraID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Desarrolladora");
        }
    }
}
