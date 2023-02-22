using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCinema.Data.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "City", "CustomerType", "Discriminator", "Email", "FirstName", "IdentificationNumber", "LastName", "PasswordHash", "PasswordSalt", "Phone", "ProfilePicture", "UserName", "UserRole" },
                values: new object[] { 2, null, 0, 1, "customer@gmail.com", "Customer", null, "Customer", "FgA/Kjcndg3tOL/lYqA0EqP+ULg=", "eheq4x+XTXfTwEWbGDXxCQ==", "041233234", null, "Customer", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Schedules",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Date", "StartTime" },
                values: new object[] { new DateTime(2023, 2, 19, 17, 25, 32, 833, DateTimeKind.Local).AddTicks(5372), new DateTime(2023, 2, 19, 17, 25, 32, 833, DateTimeKind.Local).AddTicks(5415) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PasswordHash", "PasswordSalt" },
                values: new object[] { "g3/tcSWdtwWmKeFahZGvuZc8AFA=", "aBqAkUQeDiTplEkebDBsJw==" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Discriminator", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Phone", "ProfilePicture", "UserName", "UserRole" },
                values: new object[] { 2, 0, "customer@gmail.com", "Customer", "Customer", "g3/tcSWdtwWmKeFahZGvuZc8AFA=", "aBqAkUQeDiTplEkebDBsJw==", "041233234", null, "Customer", 1 });
        }
    }
}
