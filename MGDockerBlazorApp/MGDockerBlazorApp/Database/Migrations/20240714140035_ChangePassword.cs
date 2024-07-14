using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MGDockerBlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangePassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f0d18072-2a13-4fb0-959e-b8c19b22a89b", "AQAAAAIAAYagAAAAEHb36kJ38DlP60XdZv2mCmrSnfvqniQSEIfRescL7cl3RfsWc7hIcLrpof9LZoTqgw==", "a442acb4-e141-46a3-a53b-c02dfd2bcf1b" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "258a82b6-ce4c-4fc5-9cca-5219fd4bf6c9", "AQAAAAIAAYagAAAAEEnx5KDJKoOaAyBUrX+yeGQrOMvesUiiTa2e0IJn+NDkFSGe3iw9NaFFd0iyodSdjw==", "598c59be-f971-435b-88d8-f854c22e9d54" });
        }
    }
}
