using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Profile.DataAccess.Migrations
{
    public partial class ChangeColumnsInRecommendationsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LetterLink",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "PersonContact",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "PersonPosition",
                table: "Recommendations");

            migrationBuilder.AddColumn<string>(
                name: "ContactAndLetterLink",
                table: "Recommendations",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonPositionAndOrganization",
                table: "Recommendations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContactAndLetterLink",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "PersonPositionAndOrganization",
                table: "Recommendations");

            migrationBuilder.AddColumn<string>(
                name: "LetterLink",
                table: "Recommendations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "Recommendations",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonContact",
                table: "Recommendations",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PersonPosition",
                table: "Recommendations",
                maxLength: 100,
                nullable: true);
        }
    }
}
