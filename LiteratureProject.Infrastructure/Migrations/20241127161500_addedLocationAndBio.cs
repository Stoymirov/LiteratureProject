using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiteratureProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedLocationAndBio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Bio",
                table: "AspNetUsers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "AspNetUsers",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "Bio", "ConcurrencyStamp", "Location", "PasswordHash", "SecurityStamp" },
                values: new object[] { "", "6ae40f35-1547-495d-8b79-f968e4dcbd14", "", "AQAAAAIAAYagAAAAECfnmOQOTYaoSA9RzE2E5rfsXzcx++M496k0fHuJ1FkMPD32WVZdPLExw3R4Fx5HQg==", "8c2546b4-8a85-401e-9e62-ef4b88724710" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "Bio", "ConcurrencyStamp", "Location", "PasswordHash", "SecurityStamp" },
                values: new object[] { "", "bdd667ed-9bcc-4ac1-8659-53d4160fb9c3", "", "AQAAAAIAAYagAAAAEO1Q5Qr1fdzuxhkM7XphoquxA0n1TooMWVxQd8deP1vGFdkQR2xZKvzRsgWURyPBHg==", "da15bf5e-3eab-464b-b17f-480922ffd7fc" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bio",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21d23dd2-5b23-4d4b-94db-02af1be4a66b", "AQAAAAIAAYagAAAAENZ3zJaDY9OzyZM4f+yApUCaADkOn8YWkeVsSEIuEAuhqcg1TQgFgigYsFfTeKZLSQ==", "9be063ed-d2ac-4b08-9163-9ed006d83871" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "af704ce5-e58a-4605-b63d-24cd1e01bdff", "AQAAAAIAAYagAAAAEKokM7a8HQ1bDALyfhagPQBJ55gx7Vu+yFV1/1b9LG/kM2XGSluGRj47HfLzIKgXEQ==", "d5d74be4-7aa5-4a16-99d0-c1b6708a49f4" });
        }
    }
}
