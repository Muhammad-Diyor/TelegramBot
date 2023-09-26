using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstBot.Migrations
{
    /// <inheritdoc />
    public partial class Modifieduserentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "JoinedAt",
                table: "Users",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JoinedAt",
                table: "Users");
        }
    }
}
