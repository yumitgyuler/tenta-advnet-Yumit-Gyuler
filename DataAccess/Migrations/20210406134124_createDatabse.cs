using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class createDatabse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AreaTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hamsters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OwnerFullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Age = table.Column<byte>(type: "tinyint", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hamsters", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaTypeId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Areas_AreaTypes_AreaTypeId",
                        column: x => x.AreaTypeId,
                        principalTable: "AreaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Areas_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActivityLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HamsterId = table.Column<int>(type: "int", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_Activities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "Activities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ActivityLogs_Hamsters_HamsterId",
                        column: x => x.HamsterId,
                        principalTable: "Hamsters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Arrived" },
                    { 2, "Exercise" },
                    { 3, "Cage" },
                    { 4, "Left" }
                });

            migrationBuilder.InsertData(
                table: "AreaTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Cage" },
                    { 2, "Exercise" }
                });

            migrationBuilder.InsertData(
                table: "Hamsters",
                columns: new[] { "Id", "Age", "Gender", "Name", "OwnerFullName" },
                values: new object[,]
                {
                    { 18, (byte)20, "K", "Amber", "Kim Carnes" },
                    { 19, (byte)19, "M", "Kimber", "Mork of Ork" },
                    { 20, (byte)18, "K", "Ruby", "Mindy Mendel" },
                    { 21, (byte)16, "K", "Fiffi", "GW Hansson" },
                    { 22, (byte)16, "K", "Neko", "Pia Hansson" },
                    { 23, (byte)15, "M", "Clint", "Bo Ek" },
                    { 26, (byte)110, "M", "Crawler", "Carita Gran" },
                    { 25, (byte)12, "K", "Gittan", "Hans Björk" },
                    { 17, (byte)21, "K", "Robin", "Bette Davis" },
                    { 27, (byte)9, "K", "Mimmi", "Mia Eriksson" },
                    { 28, (byte)8, "M", "Marvel", "Anna Linström" },
                    { 29, (byte)7, "M", "Storm", "Lennart Berg" },
                    { 30, (byte)6, "K", "Busan", "Bo Bergman" },
                    { 24, (byte)14, "M", "Sauron", "Anna Al" },
                    { 16, (byte)22, "K", "Bobo", "Hedy Lamar" },
                    { 13, (byte)3, "K", "Malin", "Bianca Ingrosso" },
                    { 14, (byte)24, "M", "Bulle", "Lorenzo Lamas" },
                    { 12, (byte)3, "M", "Chivas", "Pernilla Wahlgren" },
                    { 11, (byte)4, "K", "Starlight", "Anna Book" },
                    { 10, (byte)4, "M", "Kurt", "Anna Book" },
                    { 9, (byte)5, "M", "Kalle", "Anfers Murkwood" },
                    { 8, (byte)6, "K", "Miss Diggy", "Ottilla Murkwood" },
                    { 7, (byte)7, "K", "Mulan", "Jan Hallgren" },
                    { 6, (byte)8, "K", "Sussi", "Lisa Nilsson" },
                    { 5, (byte)9, "M", "Sneaky", "Lisa Nilsson" },
                    { 4, (byte)10, "M", "Nibbler", "Carl Hamilton" },
                    { 3, (byte)11, "M", "Fluff", "Carl Hamilton" },
                    { 2, (byte)12, "K", "Lisa", "Kallegurra Aktersnurra" },
                    { 1, (byte)4, "M", "Rufus", "Kallegurra Aktersnurra" },
                    { 15, (byte)23, "M", "Beppe", "Bobby Ewing" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Available" },
                    { 2, "Unavailable" }
                });

            migrationBuilder.InsertData(
                table: "Areas",
                columns: new[] { "Id", "AreaTypeId", "Capacity", "StatusId" },
                values: new object[,]
                {
                    { 1, 1, 3, 1 },
                    { 2, 1, 3, 1 },
                    { 3, 1, 3, 1 },
                    { 4, 1, 3, 1 },
                    { 5, 1, 3, 1 },
                    { 6, 1, 3, 1 },
                    { 7, 1, 3, 1 },
                    { 8, 1, 3, 1 },
                    { 9, 1, 3, 1 },
                    { 10, 1, 3, 1 },
                    { 11, 2, 6, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_ActivityId",
                table: "ActivityLogs",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_AreaId",
                table: "ActivityLogs",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityLogs_HamsterId",
                table: "ActivityLogs",
                column: "HamsterId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_AreaTypeId",
                table: "Areas",
                column: "AreaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Areas_StatusId",
                table: "Areas",
                column: "StatusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityLogs");

            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.DropTable(
                name: "Hamsters");

            migrationBuilder.DropTable(
                name: "AreaTypes");

            migrationBuilder.DropTable(
                name: "Statuses");
        }
    }
}
