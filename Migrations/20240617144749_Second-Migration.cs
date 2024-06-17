using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rodriguez_Camani_Feresin_Backend.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Users");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Reviwes",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Reviwes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Reviwes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Reviwes_UserId",
                table: "Reviwes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reviwes_Users_UserId",
                table: "Reviwes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reviwes_Users_UserId",
                table: "Reviwes");

            migrationBuilder.DropIndex(
                name: "IX_Reviwes_UserId",
                table: "Reviwes");

            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Reviwes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Reviwes");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Reviwes");

            migrationBuilder.AddColumn<int>(
                name: "Gender",
                table: "Users",
                type: "int",
                nullable: true);
        }
    }
}
