using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Profile.DataAccess.Migrations
{
    public partial class ChangeFieldStartAndEndMonthsAndYearsToStartDateAndEndDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndMonth",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "EndYear",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "StartMonth",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "StartYear",
                table: "WorkExperience");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "WorkExperience",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "WorkExperience",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "WorkExperience");

            migrationBuilder.AddColumn<string>(
                name: "EndMonth",
                table: "WorkExperience",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EndYear",
                table: "WorkExperience",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartMonth",
                table: "WorkExperience",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartYear",
                table: "WorkExperience",
                nullable: true);
        }
    }
}
