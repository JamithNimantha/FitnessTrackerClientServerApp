using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitnessTrackerServerApp.Migrations
{
    public partial class InitialCreateV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeightEntry",
                columns: table => new
                {
                    WeightEntryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Weight = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeightEntry", x => x.WeightEntryId);
                });

            migrationBuilder.CreateTable(
                name: "CheatMealEntry",
                columns: table => new
                {
                    CheatMealEntryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    MealName = table.Column<string>(type: "TEXT", nullable: false),
                    Calories = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    WeightEntryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheatMealEntry", x => x.CheatMealEntryId);
                    table.ForeignKey(
                        name: "FK_CheatMealEntry_WeightEntry_WeightEntryId",
                        column: x => x.WeightEntryId,
                        principalTable: "WeightEntry",
                        principalColumn: "WeightEntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutEntry",
                columns: table => new
                {
                    WorkoutEntryId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    WorkoutName = table.Column<string>(type: "TEXT", nullable: false),
                    UserName = table.Column<string>(type: "TEXT", nullable: false),
                    Intensity = table.Column<string>(type: "TEXT", nullable: false),
                    CaloriesBurned = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    WeightEntryId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutEntry", x => x.WorkoutEntryId);
                    table.ForeignKey(
                        name: "FK_WorkoutEntry_WeightEntry_WeightEntryId",
                        column: x => x.WeightEntryId,
                        principalTable: "WeightEntry",
                        principalColumn: "WeightEntryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserName", "DateofBirth", "Gender", "Height", "Name", "Password" },
                values: new object[] { "admin", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 183m, "Admin", "pCVA+jmMayKhtXV2/gUGP1wnYX3R5JNvy52q1Vy8Yj4=" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserName", "DateofBirth", "Gender", "Height", "Name", "Password" },
                values: new object[] { "jamith", new DateTime(1998, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 183m, "Jamith Nimantha", "pCVA+jmMayKhtXV2/gUGP1wnYX3R5JNvy52q1Vy8Yj4=" });

            migrationBuilder.InsertData(
                table: "WeightEntry",
                columns: new[] { "WeightEntryId", "Date", "UserName", "Weight" },
                values: new object[] { new Guid("0a5099b5-d7be-4948-871e-897c487a5f4c"), new DateTime(2021, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "jamith", 80m });

            migrationBuilder.CreateIndex(
                name: "IX_CheatMealEntry_WeightEntryId",
                table: "CheatMealEntry",
                column: "WeightEntryId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkoutEntry_WeightEntryId",
                table: "WorkoutEntry",
                column: "WeightEntryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheatMealEntry");

            migrationBuilder.DropTable(
                name: "WorkoutEntry");

            migrationBuilder.DropTable(
                name: "WeightEntry");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserName",
                keyValue: "admin");

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "UserName",
                keyValue: "jamith");
        }
    }
}
