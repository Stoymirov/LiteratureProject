using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiteratureProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedTopicToDeckOfProblems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Topic",
                table: "DecksOfBulgarianProblems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7c60c05f-9dac-4730-b782-ee4008a8f2a0", "AQAAAAIAAYagAAAAEDfs1h33AT3O+qwuKllIWvIcXp8psgU2C8fy3z/KYcILHQaHlhpbnLWN8vuciAIrBA==", "20f8abff-9dab-4a30-a3f1-59f248215dd1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "dea12856-c198-4129-b3f3-b893d8395082",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "77ea89cf-4147-4b9e-9e51-0dad8ae68947", "AQAAAAIAAYagAAAAEMXT0FEV9qAig6HCRvAg97emyryUUTg/rZXrrdHe6MIZmKd7j4BSKiwQ3mbDk36Ghw==", "0ecea623-00e3-4f93-9b22-06acb3f34f5a" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Topic",
                table: "DecksOfBulgarianProblems");

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
        }
    }
}
