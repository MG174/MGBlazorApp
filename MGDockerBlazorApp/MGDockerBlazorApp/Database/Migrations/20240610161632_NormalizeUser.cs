using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MGDockerBlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class NormalizeUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "258a82b6-ce4c-4fc5-9cca-5219fd4bf6c9", "ADMIN@ADMIN.COM", "ADMIN", "AQAAAAIAAYagAAAAEEnx5KDJKoOaAyBUrX+yeGQrOMvesUiiTa2e0IJn+NDkFSGe3iw9NaFFd0iyodSdjw==", "598c59be-f971-435b-88d8-f854c22e9d54" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73ccda7b-de44-47ff-ab15-5bab75e479cd", null, "admin", "AQAAAAIAAYagAAAAECk7NEnyModaACed6FlZ/QkAwYuxElBaHSp1rQujd1da2vosO8I7zRGC6jmQ9Q0qNw==", "7a7cf711-d00c-4441-a161-34491364483d" });
        }
    }
}
