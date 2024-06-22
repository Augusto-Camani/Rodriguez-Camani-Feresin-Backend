using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rodriguez_Camani_Feresin_Backend.Migrations
{
    /// <inheritdoc />
    public partial class OnDeleteCascadeSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarberAvailabilities_BarberShecules_BarberScheduleId",
                table: "BarberAvailabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberShecules_Users_BarberId",
                table: "BarberShecules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarberShecules",
                table: "BarberShecules");

            migrationBuilder.RenameTable(
                name: "BarberShecules",
                newName: "BarberShcedules");

            migrationBuilder.RenameIndex(
                name: "IX_BarberShecules_BarberId",
                table: "BarberShcedules",
                newName: "IX_BarberShcedules_BarberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarberShcedules",
                table: "BarberShcedules",
                column: "BarberScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_BarberAvailabilities_BarberShcedules_BarberScheduleId",
                table: "BarberAvailabilities",
                column: "BarberScheduleId",
                principalTable: "BarberShcedules",
                principalColumn: "BarberScheduleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberShcedules_Users_BarberId",
                table: "BarberShcedules",
                column: "BarberId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BarberAvailabilities_BarberShcedules_BarberScheduleId",
                table: "BarberAvailabilities");

            migrationBuilder.DropForeignKey(
                name: "FK_BarberShcedules_Users_BarberId",
                table: "BarberShcedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BarberShcedules",
                table: "BarberShcedules");

            migrationBuilder.RenameTable(
                name: "BarberShcedules",
                newName: "BarberShecules");

            migrationBuilder.RenameIndex(
                name: "IX_BarberShcedules_BarberId",
                table: "BarberShecules",
                newName: "IX_BarberShecules_BarberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BarberShecules",
                table: "BarberShecules",
                column: "BarberScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_BarberAvailabilities_BarberShecules_BarberScheduleId",
                table: "BarberAvailabilities",
                column: "BarberScheduleId",
                principalTable: "BarberShecules",
                principalColumn: "BarberScheduleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BarberShecules_Users_BarberId",
                table: "BarberShecules",
                column: "BarberId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
