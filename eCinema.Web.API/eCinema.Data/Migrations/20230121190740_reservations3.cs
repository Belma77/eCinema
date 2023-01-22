using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCinema.Data.Migrations
{
    /// <inheritdoc />
    public partial class reservations3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Movies_MovieId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "MovieId",
                table: "Reservations",
                newName: "ScheduleId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_MovieId",
                table: "Reservations",
                newName: "IX_Reservations_ScheduleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Schedule_ScheduleId",
                table: "Reservations",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Schedule_ScheduleId",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "ScheduleId",
                table: "Reservations",
                newName: "MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_ScheduleId",
                table: "Reservations",
                newName: "IX_Reservations_MovieId");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Reservations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Movies_MovieId",
                table: "Reservations",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
