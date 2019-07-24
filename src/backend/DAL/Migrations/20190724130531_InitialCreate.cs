using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Goals",
                columns: table => new
                {
                    GoalId = table.Column<Guid>(nullable: false),
                    GoalName = table.Column<string>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goals", x => x.GoalId);
                });

            migrationBuilder.CreateTable(
                name: "Alternatives",
                columns: table => new
                {
                    AlternativeId = table.Column<Guid>(nullable: false),
                    AlternativeName = table.Column<string>(nullable: false),
                    GlobalPriority = table.Column<float>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    goalEntityGoalId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alternatives", x => x.AlternativeId);
                    table.ForeignKey(
                        name: "FK_Alternatives_Goals_goalEntityGoalId",
                        column: x => x.goalEntityGoalId,
                        principalTable: "Goals",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Criteriums",
                columns: table => new
                {
                    CriteriumId = table.Column<Guid>(nullable: false),
                    CriteriumName = table.Column<string>(nullable: false),
                    GlobalCriteriumPriority = table.Column<float>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    goalEntityGoalId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criteriums", x => x.CriteriumId);
                    table.ForeignKey(
                        name: "FK_Criteriums_Goals_goalEntityGoalId",
                        column: x => x.goalEntityGoalId,
                        principalTable: "Goals",
                        principalColumn: "GoalId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CriteriumAlternatives",
                columns: table => new
                {
                    CriteriumAlternativeId = table.Column<Guid>(nullable: false),
                    CriteriumId = table.Column<Guid>(nullable: false),
                    AlternativeId = table.Column<Guid>(nullable: false),
                    LocalPriority = table.Column<float>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriteriumAlternatives", x => new { x.CriteriumId, x.AlternativeId });
                    table.UniqueConstraint("AK_CriteriumAlternatives_AlternativeId_CriteriumAlternativeId", x => new { x.AlternativeId, x.CriteriumAlternativeId });
                    table.ForeignKey(
                        name: "FK_CriteriumAlternatives_Alternatives_AlternativeId",
                        column: x => x.AlternativeId,
                        principalTable: "Alternatives",
                        principalColumn: "AlternativeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriteriumAlternatives_Criteriums_CriteriumId",
                        column: x => x.CriteriumId,
                        principalTable: "Criteriums",
                        principalColumn: "CriteriumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alternatives_goalEntityGoalId",
                table: "Alternatives",
                column: "goalEntityGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Criteriums_goalEntityGoalId",
                table: "Criteriums",
                column: "goalEntityGoalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CriteriumAlternatives");

            migrationBuilder.DropTable(
                name: "Alternatives");

            migrationBuilder.DropTable(
                name: "Criteriums");

            migrationBuilder.DropTable(
                name: "Goals");
        }
    }
}
