using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LiteratureProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "f1167ae1-768a-42c9-b395-32f5ca9493e5", "student@mail.com", false, "", "", false, null, "student@mail.com", "student@mail.com", "AQAAAAIAAYagAAAAEIbPKIfNPcA5qE7tBJiIIEzonV4wSAjBR0u0NCk8Cves1S4NszrZ3LDkEMLvPgJo3Q==", null, false, "2a2494df-6071-4da0-9152-052d4f1fb25d", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "c729d14b-30c6-4b1e-ad56-ce16ab1c1aeb", "teacher@mail.com", false, "", "", false, null, "teacher@mail.com", "teacher@mail.com", "AQAAAAIAAYagAAAAECmFtdoeBBGg8RnLJ3ZV7vwd3/pq7QoI7YTcrEIt7ydJzs68CHEWjww7ESSIfWXEYg==", null, false, "125fd6dc-5e5c-449a-a1f1-4043db6fb17c", false, "teacher@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Иван Вазов" },
                    { 2, "Станислав Стратиев" },
                    { 3, "Алеко Константинов" }
                });

            migrationBuilder.InsertData(
                table: "LiteratureWorks",
                columns: new[] { "Id", "ApplicationUserId", "AuthorId", "Name" },
                values: new object[,]
                {
                    { 1, null, 1, "Железният Светилник" },
                    { 3, null, 2, "Балкански синдром" }
                });

            migrationBuilder.InsertData(
                table: "AnalysisParts",
                columns: new[] { "Id", "Content", "LiteratureWorkId", "Name", "Type" },
                values: new object[,]
                {
                    { 1, "Написана вчера", 3, "История на Творбата", 3 },
                    { 2, "За една пиеса", 3, "Име на творбата", 0 }
                });

            migrationBuilder.InsertData(
                table: "UserLiteratureWorks",
                columns: new[] { "ApplicationUserId", "LiteratureWorkId" },
                values: new object[] { "dea12856-c198-4129-b3f3-b893d8395082", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AnalysisParts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AnalysisParts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "LiteratureWorks",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserLiteratureWorks",
                keyColumns: new[] { "ApplicationUserId", "LiteratureWorkId" },
                keyValues: new object[] { "dea12856-c198-4129-b3f3-b893d8395082", 3 });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LiteratureWorks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
