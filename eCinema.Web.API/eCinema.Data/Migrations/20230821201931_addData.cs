using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace eCinema.Data.Migrations
{
    /// <inheritdoc />
    public partial class addData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "Script", "script.sql");
            var query = File.ReadAllText(path);
            migrationBuilder.Sql(query);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
