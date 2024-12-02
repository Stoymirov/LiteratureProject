using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiteratureProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedImageToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d2eec17c-0e0b-4769-9360-2d7acde274b1", "", "AQAAAAIAAYagAAAAEMmXrfha2BLRJMuZbF59OGqrNCs5+fYPxZmDtcgCwi3pIxztT2ECbCAxTFSETa7UdQ==", "42143e61-c2b1-47ff-af6c-47e88567a90a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "ImageUrl", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e2462c5e-262f-4f44-98f1-0ea224c21659", "", "AQAAAAIAAYagAAAAEJwdrdZ2ZpQ992aJHrZLMh1NxR3mokXgNSfBvU/wXKaBds66gqGBo+It25/HP425Lg==", "9e133b7e-64ba-4fda-b3ac-07ad0bc55dec" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ae40f35-1547-495d-8b79-f968e4dcbd14", "AQAAAAIAAYagAAAAECfnmOQOTYaoSA9RzE2E5rfsXzcx++M496k0fHuJ1FkMPD32WVZdPLExw3R4Fx5HQg==", "8c2546b4-8a85-401e-9e62-ef4b88724710" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "bdd667ed-9bcc-4ac1-8659-53d4160fb9c3", "AQAAAAIAAYagAAAAEO1Q5Qr1fdzuxhkM7XphoquxA0n1TooMWVxQd8deP1vGFdkQR2xZKvzRsgWURyPBHg==", "da15bf5e-3eab-464b-b17f-480922ffd7fc" });
        }
    }
}
