using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCinema.Data.Migrations
{
    /// <inheritdoc />
    public partial class schedule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Schedule_ScheduleId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Halls_HallId",
                table: "Schedule");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Movies_MovieId",
                table: "Schedule");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule");

            migrationBuilder.RenameTable(
                name: "Schedule",
                newName: "Schedules");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_MovieId",
                table: "Schedules",
                newName: "IX_Schedules_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedule_HallId",
                table: "Schedules",
                newName: "IX_Schedules_HallId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Schedules_ScheduleId",
                table: "Reservations",
                column: "ScheduleId",
                principalTable: "Schedules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Halls_HallId",
                table: "Schedules",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedules_Movies_MovieId",
                table: "Schedules",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Schedules_ScheduleId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Halls_HallId",
                table: "Schedules");

            migrationBuilder.DropForeignKey(
                name: "FK_Schedules_Movies_MovieId",
                table: "Schedules");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Schedules",
                table: "Schedules");

            migrationBuilder.RenameTable(
                name: "Schedules",
                newName: "Schedule");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_MovieId",
                table: "Schedule",
                newName: "IX_Schedule_MovieId");

            migrationBuilder.RenameIndex(
                name: "IX_Schedules_HallId",
                table: "Schedule",
                newName: "IX_Schedule_HallId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Schedule",
                table: "Schedule",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Schedule_ScheduleId",
                table: "Reservations",
                column: "ScheduleId",
                principalTable: "Schedule",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Halls_HallId",
                table: "Schedule",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Movies_MovieId",
                table: "Schedule",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
