using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class DalUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternatives_Goals_GoalId",
                table: "Alternatives");

            migrationBuilder.DropForeignKey(
                name: "FK_Criteriums_Goals_GoalId",
                table: "Criteriums");

            migrationBuilder.DropTable(
                name: "Criterium_Alternatives");

            migrationBuilder.RenameColumn(
                name: "GoalId",
                table: "Criteriums",
                newName: "GoalEntityGoalId");

            migrationBuilder.RenameIndex(
                name: "IX_Criteriums_GoalId",
                table: "Criteriums",
                newName: "IX_Criteriums_GoalEntityGoalId");

            migrationBuilder.RenameColumn(
                name: "GoalId",
                table: "Alternatives",
                newName: "GoalEntityGoalId");

            migrationBuilder.RenameIndex(
                name: "IX_Alternatives_GoalId",
                table: "Alternatives",
                newName: "IX_Alternatives_GoalEntityGoalId");

            migrationBuilder.CreateTable(
                name: "CriteriumAlternatives",
                columns: table => new
                {
                    CriteriumId = table.Column<int>(nullable: false),
                    AlternativeId = table.Column<int>(nullable: false),
                    LocalPriority = table.Column<float>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriteriumAlternatives", x => new { x.CriteriumId, x.AlternativeId });
                    table.UniqueConstraint("AK_CriteriumAlternatives_AlternativeId", x => x.AlternativeId);
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

            migrationBuilder.AddForeignKey(
                name: "FK_Alternatives_Goals_GoalEntityGoalId",
                table: "Alternatives",
                column: "GoalEntityGoalId",
                principalTable: "Goals",
                principalColumn: "GoalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Criteriums_Goals_GoalEntityGoalId",
                table: "Criteriums",
                column: "GoalEntityGoalId",
                principalTable: "Goals",
                principalColumn: "GoalId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternatives_Goals_GoalEntityGoalId",
                table: "Alternatives");

            migrationBuilder.DropForeignKey(
                name: "FK_Criteriums_Goals_GoalEntityGoalId",
                table: "Criteriums");

            migrationBuilder.DropTable(
                name: "CriteriumAlternatives");

            migrationBuilder.RenameColumn(
                name: "GoalEntityGoalId",
                table: "Criteriums",
                newName: "GoalId");

            migrationBuilder.RenameIndex(
                name: "IX_Criteriums_GoalEntityGoalId",
                table: "Criteriums",
                newName: "IX_Criteriums_GoalId");

            migrationBuilder.RenameColumn(
                name: "GoalEntityGoalId",
                table: "Alternatives",
                newName: "GoalId");

            migrationBuilder.RenameIndex(
                name: "IX_Alternatives_GoalEntityGoalId",
                table: "Alternatives",
                newName: "IX_Alternatives_GoalId");

            migrationBuilder.CreateTable(
                name: "Criterium_Alternatives",
                columns: table => new
                {
                    CriteriumId = table.Column<int>(nullable: false),
                    AlternativeId = table.Column<int>(nullable: false),
                    LocalPriority = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criterium_Alternatives", x => new { x.CriteriumId, x.AlternativeId });
                    table.UniqueConstraint("AK_Criterium_Alternatives_AlternativeId_CriteriumId", x => new { x.AlternativeId, x.CriteriumId });
                    table.ForeignKey(
                        name: "FK_Criterium_Alternatives_Alternatives_AlternativeId",
                        column: x => x.AlternativeId,
                        principalTable: "Alternatives",
                        principalColumn: "AlternativeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Criterium_Alternatives_Criteriums_CriteriumId",
                        column: x => x.CriteriumId,
                        principalTable: "Criteriums",
                        principalColumn: "CriteriumId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Alternatives_Goals_GoalId",
                table: "Alternatives",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "GoalId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Criteriums_Goals_GoalId",
                table: "Criteriums",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "GoalId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
