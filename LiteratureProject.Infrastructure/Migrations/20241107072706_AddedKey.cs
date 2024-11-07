using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiteratureProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f03d79b6-29ca-4267-bdb3-42da461898f3", "AQAAAAIAAYagAAAAEBQ/RJ+wOruwnyF0m79ECFLyTRRBwkHXmCvmSo6mDP0UsD9g2PtwPAeNOJM7jhBWCA==", "ec37c78c-6ef4-4e7b-96e4-fff210b15570" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "587a3d44-9d0a-402c-a49d-8f8d198a7818", "AQAAAAIAAYagAAAAEBSo2VUsve1MNZDZtHQw/d10htALzWew+8JKaMueKMZihqJolKs2TTJxQ+IL7EhI2Q==", "6a7fd7ed-e25e-40dc-8d6e-e4cb8b502411" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cc961911-b7e4-4c65-9d85-758ca38739eb", "AQAAAAIAAYagAAAAEH3RGJ6hrd74lxwUP/lpaW0a4W24HPqLirCM1TVT5hRfdyM0UCEXsDo5MKfnqU7dNg==", "266f94fd-cafa-4e62-9ec0-57a4a1c6e457" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b2453169-6a87-495b-ab1c-094b98745bdf", "AQAAAAIAAYagAAAAEOWumrjTyKUwuxnqT/diJzOt3XMSxXJwVgelRTf2tsUBhOEYERnebStBCve3oYolwg==", "5ff0dfad-afd8-471b-a85b-7ced41b09b97" });
        }
    }
}
