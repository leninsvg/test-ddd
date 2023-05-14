using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDDD.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "persons",
                columns: table => new
                {
                    identification = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    firstNames = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    lastNames = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    gender = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_persons", x => x.identification);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "persons");
        }
    }
}
