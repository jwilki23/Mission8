using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission8.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Quadrants",
                columns: table => new
                {
                    QuadrantId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    QuadrantName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quadrants", x => x.QuadrantId);
                });

            migrationBuilder.CreateTable(
                name: "Responses",
                columns: table => new
                {
                    TaskId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryId = table.Column<int>(nullable: false),
                    Task = table.Column<string>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    QuadrantId = table.Column<int>(nullable: false),
                    Completed = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Responses", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_Responses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Responses_Quadrants_QuadrantId",
                        column: x => x.QuadrantId,
                        principalTable: "Quadrants",
                        principalColumn: "QuadrantId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 1, "Home" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 2, "School" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 3, "Work" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryName" },
                values: new object[] { 4, "Church" });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "QuadrantId", "QuadrantName" },
                values: new object[] { 1, "1" });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "QuadrantId", "QuadrantName" },
                values: new object[] { 2, "2" });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "QuadrantId", "QuadrantName" },
                values: new object[] { 3, "3" });

            migrationBuilder.InsertData(
                table: "Quadrants",
                columns: new[] { "QuadrantId", "QuadrantName" },
                values: new object[] { 4, "4" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "QuadrantId", "Task" },
                values: new object[] { 1, 2, false, new DateTime(2023, 2, 24, 11, 59, 59, 0, DateTimeKind.Unspecified), 1, "Mission #8 Project" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "QuadrantId", "Task" },
                values: new object[] { 2, 4, false, new DateTime(2023, 2, 26, 11, 30, 0, 0, DateTimeKind.Unspecified), 2, "Write a talk" });

            migrationBuilder.InsertData(
                table: "Responses",
                columns: new[] { "TaskId", "CategoryId", "Completed", "DueDate", "QuadrantId", "Task" },
                values: new object[] { 3, 1, false, new DateTime(2023, 2, 27, 6, 0, 0, 0, DateTimeKind.Unspecified), 4, "Do my laundry" });

            migrationBuilder.CreateIndex(
                name: "IX_Responses_CategoryId",
                table: "Responses",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Responses_QuadrantId",
                table: "Responses",
                column: "QuadrantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Responses");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Quadrants");
        }
    }
}
