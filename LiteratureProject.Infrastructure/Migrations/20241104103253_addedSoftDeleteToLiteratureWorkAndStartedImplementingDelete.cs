using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiteratureProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedSoftDeleteToLiteratureWorkAndStartedImplementingDelete : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LiteratureWorks",
                type: "bit",
                nullable: false,
                defaultValue: false);

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

            migrationBuilder.UpdateData(
                table: "LiteratureWorks",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsDeleted",
                value: false);

            migrationBuilder.UpdateData(
                table: "LiteratureWorks",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsDeleted",
                value: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDeleted",
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
    }
}
