using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCinema.Data.Migrations
{
    /// <inheritdoc />
    public partial class change : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScheduleSeatId",
                table: "Schedules",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "ScheduleSeatId", "StartTime" },
                values: new object[] { new DateTime(2023, 2, 19, 18, 41, 7, 247, DateTimeKind.Local).AddTicks(6503), null, new DateTime(2023, 2, 19, 18, 41, 7, 247, DateTimeKind.Local).AddTicks(6567) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "pT6+O41e8uAPiPi2wHkJpRSPchI=", "x+D01pkHyndDddlVLnHpJQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "pT6+O41e8uAPiPi2wHkJpRSPchI=", "x+D01pkHyndDddlVLnHpJQ==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScheduleSeatId",
                table: "Schedules");

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "StartTime" },
                values: new object[] { new DateTime(2023, 2, 19, 18, 3, 5, 155, DateTimeKind.Local).AddTicks(7569), new DateTime(2023, 2, 19, 18, 3, 5, 155, DateTimeKind.Local).AddTicks(7614) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "FgA/Kjcndg3tOL/lYqA0EqP+ULg=", "eheq4x+XTXfTwEWbGDXxCQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "FgA/Kjcndg3tOL/lYqA0EqP+ULg=", "eheq4x+XTXfTwEWbGDXxCQ==" });
        }
    }
}
