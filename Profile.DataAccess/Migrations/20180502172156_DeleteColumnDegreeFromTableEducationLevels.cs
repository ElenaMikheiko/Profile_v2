using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Profile.DataAccess.Migrations
{
    public partial class DeleteColumnDegreeFromTableEducationLevels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Degree",
                table: "EducationLevels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Degree",
                table: "EducationLevels",
                maxLength: 100,
                nullable: true);
        }
    }
}
