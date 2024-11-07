using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LiteratureProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedById",
                table: "DecksOfBulgarianProblems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "DecksOfBulgarianProblems");

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
    }
}
