using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiteratureProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class changedProps : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LiteratureWorks_AspNetUsers_ApplicationUserId",
                table: "LiteratureWorks");

            migrationBuilder.DropIndex(
                name: "IX_LiteratureWorks_ApplicationUserId",
                table: "LiteratureWorks");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "LiteratureWorks");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10b2f63d-cda7-48e2-9559-2900a44122c0", "AQAAAAIAAYagAAAAELFnPT7AePX8kUsn71iWnwDjjfrDmhvSEVjj6Eek+cwvS06Nkq1N+dv+2KP8SGvC2w==", "46fe08c9-8796-4da8-b4a9-402c0dada276" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f8a6b88f-3e43-4efd-9a36-069f85d5a593", "AQAAAAIAAYagAAAAEGbAbfus3mFwFgtnC1URVHgP6kyzmXQlROSMTVQqNts5y5M525SshwjuyJs3kGtPhA==", "6676148a-cabd-467c-a4aa-2a360f85b5d4" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "LiteratureWorks",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f1167ae1-768a-42c9-b395-32f5ca9493e5", "AQAAAAIAAYagAAAAEIbPKIfNPcA5qE7tBJiIIEzonV4wSAjBR0u0NCk8Cves1S4NszrZ3LDkEMLvPgJo3Q==", "2a2494df-6071-4da0-9152-052d4f1fb25d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c729d14b-30c6-4b1e-ad56-ce16ab1c1aeb", "AQAAAAIAAYagAAAAECmFtdoeBBGg8RnLJ3ZV7vwd3/pq7QoI7YTcrEIt7ydJzs68CHEWjww7ESSIfWXEYg==", "125fd6dc-5e5c-449a-a1f1-4043db6fb17c" });

            migrationBuilder.UpdateData(
                table: "LiteratureWorks",
                keyColumn: "Id",
                keyValue: 1,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "LiteratureWorks",
                keyColumn: "Id",
                keyValue: 3,
                column: "ApplicationUserId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_LiteratureWorks_ApplicationUserId",
                table: "LiteratureWorks",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LiteratureWorks_AspNetUsers_ApplicationUserId",
                table: "LiteratureWorks",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
