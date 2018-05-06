using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Profile.DataAccess.Migrations
{
    public partial class AllTableChangesAreInOneMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StreamSkills_Stream_StreamId",
                table: "StreamSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentStreams_Stream_StreamId",
                table: "StudentStreams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stream",
                table: "Stream");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForeignLanguages",
                table: "ForeignLanguages");

            migrationBuilder.DropIndex(
                name: "IX_ForeignLanguages_CVId",
                table: "ForeignLanguages");

            migrationBuilder.DropColumn(
                name: "EndDate",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "StartDate",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ForeignLanguages");

            migrationBuilder.DropColumn(
                name: "LanguageLevel",
                table: "ForeignLanguages");

            migrationBuilder.DropColumn(
                name: "LanguageName",
                table: "ForeignLanguages");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "Stream",
                newName: "Streams");

            migrationBuilder.AddColumn<string>(
                name: "EndMonth",
                table: "WorkExperience",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EndYear",
                table: "WorkExperience",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartMonth",
                table: "WorkExperience",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StartYear",
                table: "WorkExperience",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ToPresent",
                table: "WorkExperience",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PersonPosition",
                table: "Recommendations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LanguageId",
                table: "ForeignLanguages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LanguageLevelId",
                table: "ForeignLanguages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "YearOfAttestation",
                table: "Exams",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "YearOfGraduation",
                table: "Education",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "YearOfAdmission",
                table: "Education",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<string>(
                name: "YearOfGraduation",
                table: "Courses",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Streams",
                table: "Streams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForeignLanguages",
                table: "ForeignLanguages",
                columns: new[] { "CVId", "LanguageId", "LanguageLevelId" });

            migrationBuilder.CreateTable(
                name: "Certificates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CVId = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Organization = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfAttestation = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguageLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LevelName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ForeignLanguages_LanguageId",
                table: "ForeignLanguages",
                column: "LanguageId");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignLanguages_LanguageLevelId",
                table: "ForeignLanguages",
                column: "LanguageLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_CVs_StudentId",
                table: "CVs",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_CVs_Students_StudentId",
                table: "CVs",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ForeignLanguages_Languages_LanguageId",
                table: "ForeignLanguages",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ForeignLanguages_LanguageLevels_LanguageLevelId",
                table: "ForeignLanguages",
                column: "LanguageLevelId",
                principalTable: "LanguageLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StreamSkills_Streams_StreamId",
                table: "StreamSkills",
                column: "StreamId",
                principalTable: "Streams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentStreams_Streams_StreamId",
                table: "StudentStreams",
                column: "StreamId",
                principalTable: "Streams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CVs_Students_StudentId",
                table: "CVs");

            migrationBuilder.DropForeignKey(
                name: "FK_ForeignLanguages_Languages_LanguageId",
                table: "ForeignLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_ForeignLanguages_LanguageLevels_LanguageLevelId",
                table: "ForeignLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_StreamSkills_Streams_StreamId",
                table: "StreamSkills");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentStreams_Streams_StreamId",
                table: "StudentStreams");

            migrationBuilder.DropTable(
                name: "Certificates");

            migrationBuilder.DropTable(
                name: "LanguageLevels");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Streams",
                table: "Streams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForeignLanguages",
                table: "ForeignLanguages");

            migrationBuilder.DropIndex(
                name: "IX_ForeignLanguages_LanguageId",
                table: "ForeignLanguages");

            migrationBuilder.DropIndex(
                name: "IX_ForeignLanguages_LanguageLevelId",
                table: "ForeignLanguages");

            migrationBuilder.DropIndex(
                name: "IX_CVs_StudentId",
                table: "CVs");

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

            migrationBuilder.DropColumn(
                name: "ToPresent",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "PersonPosition",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "ForeignLanguages");

            migrationBuilder.DropColumn(
                name: "LanguageLevelId",
                table: "ForeignLanguages");

            migrationBuilder.RenameTable(
                name: "Streams",
                newName: "Stream");

            migrationBuilder.AddColumn<DateTime>(
                name: "EndDate",
                table: "WorkExperience",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "StartDate",
                table: "WorkExperience",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ForeignLanguages",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "LanguageLevel",
                table: "ForeignLanguages",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanguageName",
                table: "ForeignLanguages",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "YearOfAttestation",
                table: "Exams",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "YearOfGraduation",
                table: "Education",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "YearOfAdmission",
                table: "Education",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "YearOfGraduation",
                table: "Courses",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Courses",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stream",
                table: "Stream",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForeignLanguages",
                table: "ForeignLanguages",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ForeignLanguages_CVId",
                table: "ForeignLanguages",
                column: "CVId");

            migrationBuilder.AddForeignKey(
                name: "FK_StreamSkills_Stream_StreamId",
                table: "StreamSkills",
                column: "StreamId",
                principalTable: "Stream",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentStreams_Stream_StreamId",
                table: "StudentStreams",
                column: "StreamId",
                principalTable: "Stream",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
