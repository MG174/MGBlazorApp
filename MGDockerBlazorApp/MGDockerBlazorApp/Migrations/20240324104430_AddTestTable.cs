using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MGDockerBlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTestTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TestTable",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uuid", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestTable", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TestTable");
        }
    }
}
