using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Rodriguez_Camani_Feresin_Backend.Migrations
{
    /// <inheritdoc />
    public partial class ContextWithSchedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReviewId",
                table: "Appointments",
                newName: "Status");

            migrationBuilder.RenameColumn(
                name: "ReceiptNumber",
                table: "Appointments",
                newName: "Service");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Appointments",
                newName: "StartTime");

            migrationBuilder.AddColumn<int>(
                name: "BarberAvailabilityId",
                table: "Appointments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BarberShecules",
                columns: table => new
                {
                    BarberScheduleId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BarberId = table.Column<int>(type: "INTEGER", nullable: false),
                    CurrentYear = table.Column<int>(type: "INTEGER", nullable: false),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberShecules", x => x.BarberScheduleId);
                    table.ForeignKey(
                        name: "FK_BarberShecules_Users_BarberId",
                        column: x => x.BarberId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BarberAvailabilities",
                columns: table => new
                {
                    BarberAvailabilityId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BarberScheduleId = table.Column<int>(type: "INTEGER", nullable: false),
                    DayOfTheWeek = table.Column<int>(type: "INTEGER", nullable: false),
                    AvailabilityDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    IsAvailable = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarberAvailabilities", x => x.BarberAvailabilityId);
                    table.ForeignKey(
                        name: "FK_BarberAvailabilities_BarberShecules_BarberScheduleId",
                        column: x => x.BarberScheduleId,
                        principalTable: "BarberShecules",
                        principalColumn: "BarberScheduleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_BarberAvailabilityId",
                table: "Appointments",
                column: "BarberAvailabilityId");

            migrationBuilder.CreateIndex(
                name: "IX_BarberAvailabilities_BarberScheduleId",
                table: "BarberAvailabilities",
                column: "BarberScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_BarberShecules_BarberId",
                table: "BarberShecules",
                column: "BarberId");

            migrationBuilder.AddForeignKey(
                name: "FK_Appointments_BarberAvailabilities_BarberAvailabilityId",
                table: "Appointments",
                column: "BarberAvailabilityId",
                principalTable: "BarberAvailabilities",
                principalColumn: "BarberAvailabilityId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Appointments_BarberAvailabilities_BarberAvailabilityId",
                table: "Appointments");

            migrationBuilder.DropTable(
                name: "BarberAvailabilities");

            migrationBuilder.DropTable(
                name: "BarberShecules");

            migrationBuilder.DropIndex(
                name: "IX_Appointments_BarberAvailabilityId",
                table: "Appointments");

            migrationBuilder.DropColumn(
                name: "BarberAvailabilityId",
                table: "Appointments");

            migrationBuilder.RenameColumn(
                name: "Status",
                table: "Appointments",
                newName: "ReviewId");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Appointments",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Service",
                table: "Appointments",
                newName: "ReceiptNumber");
        }
    }
}
