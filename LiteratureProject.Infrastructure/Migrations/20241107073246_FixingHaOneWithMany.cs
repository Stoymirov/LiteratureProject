using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiteratureProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixingHaOneWithMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BulgarianProblems_DecksOfBulgarianProblems_DeckOfProblemsId",
                table: "BulgarianProblems");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BulgarianProblems_DecksOfBulgarianProblems_DeckOfProblemsId",
                table: "BulgarianProblems",
                column: "DeckOfProblemsId",
                principalTable: "DecksOfBulgarianProblems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BulgarianProblems_DecksOfBulgarianProblems_DeckOfProblemsId",
                table: "BulgarianProblems");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BulgarianProblems_DecksOfBulgarianProblems_DeckOfProblemsId",
                table: "BulgarianProblems",
                column: "DeckOfProblemsId",
                principalTable: "DecksOfBulgarianProblems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
