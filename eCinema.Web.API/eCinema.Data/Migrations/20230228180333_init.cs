using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCinema.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "StartTime" },
                values: new object[] { new DateTime(2023, 2, 28, 19, 3, 32, 701, DateTimeKind.Local).AddTicks(2438), new DateTime(2023, 2, 28, 19, 3, 32, 701, DateTimeKind.Local).AddTicks(2479) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "wWkgRwOi65hk+ufylkpbVw6TjTM=", "fQE9B1VZbU3bAl2VxLPOtQ==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "wWkgRwOi65hk+ufylkpbVw6TjTM=", "fQE9B1VZbU3bAl2VxLPOtQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_UserName",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "StartTime" },
                values: new object[] { new DateTime(2023, 2, 19, 18, 41, 7, 247, DateTimeKind.Local).AddTicks(6503), new DateTime(2023, 2, 19, 18, 41, 7, 247, DateTimeKind.Local).AddTicks(6567) });

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
    }
}
