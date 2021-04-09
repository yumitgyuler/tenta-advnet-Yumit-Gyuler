using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Name" },
                values: new object[] { 5, "Spa" });

            migrationBuilder.InsertData(
                table: "AreaTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Spa" });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "AreaTypeId", "Capacity", "StatusId" },
                values: new object[] { 12, 3, 4, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Areas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AreaTypes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
