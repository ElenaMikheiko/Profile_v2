using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Profile.DataAccess.Migrations
{
    public partial class NewFieldsForStreamEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreamName",
                table: "Streams");

            migrationBuilder.AddColumn<string>(
                name: "StreamFullName",
                table: "Streams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StreamShortName",
                table: "Streams",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreamFullName",
                table: "Streams");

            migrationBuilder.DropColumn(
                name: "StreamShortName",
                table: "Streams");

            migrationBuilder.AddColumn<string>(
                name: "StreamName",
                table: "Streams",
                maxLength: 100,
                nullable: true);
        }
    }
}
