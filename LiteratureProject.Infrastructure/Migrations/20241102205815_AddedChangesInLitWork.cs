using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LiteratureProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedChangesInLitWork : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUserLiteratureWork");

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

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "LiteratureWorks",
                type: "nvarchar(450)",
                nullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ApplicationUserLiteratureWork",
                columns: table => new
                {
                    CreatorsOfAnalysisId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LiteratureWorksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUserLiteratureWork", x => new { x.CreatorsOfAnalysisId, x.LiteratureWorksId });
                    table.ForeignKey(
                        name: "FK_ApplicationUserLiteratureWork_AspNetUsers_CreatorsOfAnalysisId",
                        column: x => x.CreatorsOfAnalysisId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ApplicationUserLiteratureWork_LiteratureWorks_LiteratureWorksId",
                        column: x => x.LiteratureWorksId,
                        principalTable: "LiteratureWorks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e", 0, "6d217b42-e40f-494b-9d8a-284715fba587", "student@mail.com", false, "", "", false, null, "student@mail.com", "student@mail.com", "AQAAAAIAAYagAAAAEIRFjT2DRwkC1XYQjqm/nT7lwvYMsl4e5MTJYZd1DOEmaE/qip+1qQW1WoU3E3mhKQ==", null, false, "b8c233bc-7efe-4df3-80ac-d60939b7b446", false, "guest@mail.com" },
                    { "dea12856-c198-4129-b3f3-b893d8395082", 0, "d4aacd68-4525-4602-b964-3d1b24fea19c", "teacher@mail.com", false, "", "", false, null, "teacher@mail.com", "teacher@mail.com", "AQAAAAIAAYagAAAAEPe/A7Ty6eT5eYbbvYpPvo+dTCHRRDWB0PW/qN/LECVRLdX2gO4m6g28RCefRdn9oQ==", null, false, "36fe2187-fc90-42c0-b02c-9dcbe0a68031", false, "teacher@mail.com" }
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
                columns: new[] { "Id", "AuthorId", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Железният Светилник" },
                    { 3, 2, "Балкански синдром" }
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

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUserLiteratureWork_LiteratureWorksId",
                table: "ApplicationUserLiteratureWork",
                column: "LiteratureWorksId");
        }
    }
}
