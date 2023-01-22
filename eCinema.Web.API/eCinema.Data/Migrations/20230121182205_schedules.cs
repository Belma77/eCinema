using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCinema.Data.Migrations
{
    /// <inheritdoc />
    public partial class schedules : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NoHall",
                table: "Schedule",
                newName: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_Schedule_HallId",
                table: "Schedule",
                column: "HallId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schedule_Halls_HallId",
                table: "Schedule",
                column: "HallId",
                principalTable: "Halls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schedule_Halls_HallId",
                table: "Schedule");

            migrationBuilder.DropIndex(
                name: "IX_Schedule_HallId",
                table: "Schedule");

            migrationBuilder.RenameColumn(
                name: "HallId",
                table: "Schedule",
                newName: "NoHall");
        }
    }
}
