using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiteratureProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedBulgarianEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DecksOfBulgarianProblems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DecksOfBulgarianProblems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BulgarianProblems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAnswer1Correct = table.Column<bool>(type: "bit", nullable: false),
                    Answer2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAnswer2Correct = table.Column<bool>(type: "bit", nullable: false),
                    Answer3 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAnswer3Correct = table.Column<bool>(type: "bit", nullable: false),
                    Answer4 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAnswer4Correct = table.Column<bool>(type: "bit", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeckOfProblemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BulgarianProblems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BulgarianProblems_DecksOfBulgarianProblems_DeckOfProblemsId",
                        column: x => x.DeckOfProblemsId,
                        principalTable: "DecksOfBulgarianProblems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "669272cc-e0fc-4ce0-b532-8f49798392a7", "AQAAAAIAAYagAAAAECLszqL7qOXTX8XqyXFu4ix55haPeixwumBPnzXMCpmX5Aoer1bE8w+d94Zep7FzCA==", "f6bd0426-91af-4979-a6aa-a8920a851cf5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7625613-496f-4a9e-a093-49bdf66422f6", "AQAAAAIAAYagAAAAEP7aWYzcgZc+z71y8jhRSaNmGhv3giKkF2y58dtg4rr3nrL1tYSy0K2vkOWP+/M/og==", "c657a8d7-f155-4d30-96ce-5446b63b4186" });

            migrationBuilder.CreateIndex(
                name: "IX_BulgarianProblems_DeckOfProblemsId",
                table: "BulgarianProblems",
                column: "DeckOfProblemsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BulgarianProblems");

            migrationBuilder.DropTable(
                name: "DecksOfBulgarianProblems");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ae1e8be4-a37a-433a-9fbb-b3224a48a577", "AQAAAAIAAYagAAAAEH2bZuwLMBW/RtRUeW4EXRyGhVQ5tLH75x07HnP1uEApr8PQ0kWfK+KEgOjeLgSaMw==", "8e99ef77-6162-4d95-be24-3412a5f8f2b7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f39b2f13-f5e9-4980-96ca-49a25facc3cf", "AQAAAAIAAYagAAAAEFs5Ow3PwGQj3pzIIMOhjmzt4mM5d7YINHxUchAdJMItKNXH+oJ4iX5XwZomFgKQ6w==", "b47521a9-7471-4529-abe7-1e718c221a56" });
        }
    }
}
