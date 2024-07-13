using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MGDockerBlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class ChangePasswordUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "73ccda7b-de44-47ff-ab15-5bab75e479cd", "AQAAAAIAAYagAAAAECk7NEnyModaACed6FlZ/QkAwYuxElBaHSp1rQujd1da2vosO8I7zRGC6jmQ9Q0qNw==", "7a7cf711-d00c-4441-a161-34491364483d" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "895ca12c-05ad-4661-9741-7ba87bddb4b8", "AQAAAAIAAYagAAAAEMbGf0lnOi65gUFHmOOBZRsWtveXZQZFe5YFDIF3QXuKDnJKD9/moT107YG+RYlcgQ==", "8e1f7086-f3f4-4b05-ac40-728b38c3d5b8" });
        }
    }
}
