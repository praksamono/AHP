using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class NamingUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternatives_Goals_GoalId",
                table: "Alternatives");

            migrationBuilder.DropForeignKey(
                name: "FK_Criteriums_Goals_GoalId",
                table: "Criteriums");

            migrationBuilder.DropIndex(
                name: "IX_Criteriums_GoalId",
                table: "Criteriums");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CriteriumAlternatives_AlternativeId_CriteriumAlternativeId",
                table: "CriteriumAlternatives");

            migrationBuilder.DropIndex(
                name: "IX_Alternatives_GoalId",
                table: "Alternatives");

            migrationBuilder.DropColumn(
                name: "CriteriumAlternativeId",
                table: "CriteriumAlternatives");

            migrationBuilder.RenameColumn(
                name: "GoalId",
                table: "Goals",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CriteriumId",
                table: "Criteriums",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "AlternativeId",
                table: "Alternatives",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "GoalEntityId",
                table: "Criteriums",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "Id",
                table: "CriteriumAlternatives",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "GoalEntityId",
                table: "Alternatives",
                nullable: true);

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CriteriumAlternatives_AlternativeId_CriteriumId",
                table: "CriteriumAlternatives",
                columns: new[] { "AlternativeId", "CriteriumId" });

            migrationBuilder.CreateIndex(
                name: "IX_Criteriums_GoalEntityId",
                table: "Criteriums",
                column: "GoalEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Alternatives_GoalEntityId",
                table: "Alternatives",
                column: "GoalEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alternatives_Goals_GoalEntityId",
                table: "Alternatives",
                column: "GoalEntityId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Criteriums_Goals_GoalEntityId",
                table: "Criteriums",
                column: "GoalEntityId",
                principalTable: "Goals",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alternatives_Goals_GoalEntityId",
                table: "Alternatives");

            migrationBuilder.DropForeignKey(
                name: "FK_Criteriums_Goals_GoalEntityId",
                table: "Criteriums");

            migrationBuilder.DropIndex(
                name: "IX_Criteriums_GoalEntityId",
                table: "Criteriums");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_CriteriumAlternatives_AlternativeId_CriteriumId",
                table: "CriteriumAlternatives");

            migrationBuilder.DropIndex(
                name: "IX_Alternatives_GoalEntityId",
                table: "Alternatives");

            migrationBuilder.DropColumn(
                name: "GoalEntityId",
                table: "Criteriums");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "CriteriumAlternatives");

            migrationBuilder.DropColumn(
                name: "GoalEntityId",
                table: "Alternatives");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Goals",
                newName: "GoalId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Criteriums",
                newName: "CriteriumId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Alternatives",
                newName: "AlternativeId");

            migrationBuilder.AddColumn<Guid>(
                name: "CriteriumAlternativeId",
                table: "CriteriumAlternatives",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddUniqueConstraint(
                name: "AK_CriteriumAlternatives_AlternativeId_CriteriumAlternativeId",
                table: "CriteriumAlternatives",
                columns: new[] { "AlternativeId", "CriteriumAlternativeId" });

            migrationBuilder.CreateIndex(
                name: "IX_Criteriums_GoalId",
                table: "Criteriums",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_Alternatives_GoalId",
                table: "Alternatives",
                column: "GoalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Alternatives_Goals_GoalId",
                table: "Alternatives",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "GoalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Criteriums_Goals_GoalId",
                table: "Criteriums",
                column: "GoalId",
                principalTable: "Goals",
                principalColumn: "GoalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
