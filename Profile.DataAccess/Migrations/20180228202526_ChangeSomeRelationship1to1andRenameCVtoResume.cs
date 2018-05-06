using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Profile.DataAccess.Migrations
{
    public partial class ChangeSomeRelationship1to1andRenameCVtoResume : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_CVs_CVId",
                table: "ContactInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_CVs_CVId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Education_CVs_CVId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_CVs_CVId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_ForeignLanguages_CVs_CVId",
                table: "ForeignLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolio_CVs_CVId",
                table: "Portfolio");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_CVs_CVId",
                table: "Recommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_User_UserInfo_UserInfoId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_CVs_CVId",
                table: "WorkExperience");

            migrationBuilder.DropTable(
                name: "CVs");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperience_CVId",
                table: "WorkExperience");

            migrationBuilder.DropIndex(
                name: "IX_User_UserInfoId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Recommendations_CVId",
                table: "Recommendations");

            migrationBuilder.DropIndex(
                name: "IX_Portfolio_CVId",
                table: "Portfolio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForeignLanguages",
                table: "ForeignLanguages");

            migrationBuilder.DropIndex(
                name: "IX_Exams_CVId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Education_CVId",
                table: "Education");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CVId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_ContactInfo_CVId",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "Summary");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "Portfolio");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "MilitaryStatus");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "ForeignLanguages");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "CVId",
                table: "AdditionalInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Responsibilities",
                table: "WorkExperience",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "WorkExperience",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Organization",
                table: "WorkExperience",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "WorkExperience",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserInfo",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RuSurname",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RuName",
                table: "UserInfo",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnSurname",
                table: "UserInfo",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnName",
                table: "UserInfo",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserInfo",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Summary",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "Summary",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "StreamName",
                table: "Streams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skills",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonPosition",
                table: "Recommendations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonName",
                table: "Recommendations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "Recommendations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "Recommendations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Portfolio",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "Portfolio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "MilitaryStatus",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "MilitaryStatus",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "ForeignLanguages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Organization",
                table: "Exams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExamName",
                table: "Exams",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "Exams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                table: "Education",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EducationalInstitution",
                table: "Education",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "Education",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EducationLevelId",
                table: "Education",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "Education",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "YearOfGraduation",
                table: "Courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                table: "Courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Organization",
                table: "Courses",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "Courses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Skype",
                table: "ContactInfo",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Linkedin",
                table: "ContactInfo",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "ContactInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Certificates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Certificates",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "Certificates",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "AdditionalInfo",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResumeId",
                table: "AdditionalInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForeignLanguages",
                table: "ForeignLanguages",
                columns: new[] { "ResumeId", "LanguageId", "LanguageLevelId" });

            migrationBuilder.CreateTable(
                name: "EducationLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Degree = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Level = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resume",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resume_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_ResumeId",
                table: "WorkExperience",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserInfo_UserId",
                table: "UserInfo",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Summary_ResumeId",
                table: "Summary",
                column: "ResumeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_ResumeId",
                table: "Recommendations",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_ResumeId",
                table: "Portfolio",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_MilitaryStatus_ResumeId",
                table: "MilitaryStatus",
                column: "ResumeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ResumeId",
                table: "Exams",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_EducationLevelId",
                table: "Education",
                column: "EducationLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_ResumeId",
                table: "Education",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_ResumeId",
                table: "Courses",
                column: "ResumeId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_ResumeId",
                table: "ContactInfo",
                column: "ResumeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalInfo_ResumeId",
                table: "AdditionalInfo",
                column: "ResumeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resume_StudentId",
                table: "Resume",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalInfo_Resume_ResumeId",
                table: "AdditionalInfo",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_Resume_ResumeId",
                table: "ContactInfo",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Resume_ResumeId",
                table: "Courses",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Education_EducationLevels_EducationLevelId",
                table: "Education",
                column: "EducationLevelId",
                principalTable: "EducationLevels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Education_Resume_ResumeId",
                table: "Education",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Resume_ResumeId",
                table: "Exams",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ForeignLanguages_Resume_ResumeId",
                table: "ForeignLanguages",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MilitaryStatus_Resume_ResumeId",
                table: "MilitaryStatus",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolio_Resume_ResumeId",
                table: "Portfolio",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_Resume_ResumeId",
                table: "Recommendations",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Summary_Resume_ResumeId",
                table: "Summary",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserInfo_User_UserId",
                table: "UserInfo",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_Resume_ResumeId",
                table: "WorkExperience",
                column: "ResumeId",
                principalTable: "Resume",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalInfo_Resume_ResumeId",
                table: "AdditionalInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactInfo_Resume_ResumeId",
                table: "ContactInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Resume_ResumeId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_Education_EducationLevels_EducationLevelId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Education_Resume_ResumeId",
                table: "Education");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Resume_ResumeId",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_ForeignLanguages_Resume_ResumeId",
                table: "ForeignLanguages");

            migrationBuilder.DropForeignKey(
                name: "FK_MilitaryStatus_Resume_ResumeId",
                table: "MilitaryStatus");

            migrationBuilder.DropForeignKey(
                name: "FK_Portfolio_Resume_ResumeId",
                table: "Portfolio");

            migrationBuilder.DropForeignKey(
                name: "FK_Recommendations_Resume_ResumeId",
                table: "Recommendations");

            migrationBuilder.DropForeignKey(
                name: "FK_Summary_Resume_ResumeId",
                table: "Summary");

            migrationBuilder.DropForeignKey(
                name: "FK_UserInfo_User_UserId",
                table: "UserInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkExperience_Resume_ResumeId",
                table: "WorkExperience");

            migrationBuilder.DropTable(
                name: "EducationLevels");

            migrationBuilder.DropTable(
                name: "Resume");

            migrationBuilder.DropIndex(
                name: "IX_WorkExperience_ResumeId",
                table: "WorkExperience");

            migrationBuilder.DropIndex(
                name: "IX_UserInfo_UserId",
                table: "UserInfo");

            migrationBuilder.DropIndex(
                name: "IX_Summary_ResumeId",
                table: "Summary");

            migrationBuilder.DropIndex(
                name: "IX_Recommendations_ResumeId",
                table: "Recommendations");

            migrationBuilder.DropIndex(
                name: "IX_Portfolio_ResumeId",
                table: "Portfolio");

            migrationBuilder.DropIndex(
                name: "IX_MilitaryStatus_ResumeId",
                table: "MilitaryStatus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ForeignLanguages",
                table: "ForeignLanguages");

            migrationBuilder.DropIndex(
                name: "IX_Exams_ResumeId",
                table: "Exams");

            migrationBuilder.DropIndex(
                name: "IX_Education_EducationLevelId",
                table: "Education");

            migrationBuilder.DropIndex(
                name: "IX_Education_ResumeId",
                table: "Education");

            migrationBuilder.DropIndex(
                name: "IX_Courses_ResumeId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_ContactInfo_ResumeId",
                table: "ContactInfo");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalInfo_ResumeId",
                table: "AdditionalInfo");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "WorkExperience");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "Summary");

            migrationBuilder.DropColumn(
                name: "Organization",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "Recommendations");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "Portfolio");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "MilitaryStatus");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "ForeignLanguages");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "Exams");

            migrationBuilder.DropColumn(
                name: "EducationLevelId",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "Education");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "Courses");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "ContactInfo");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "Certificates");

            migrationBuilder.DropColumn(
                name: "ResumeId",
                table: "AdditionalInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Responsibilities",
                table: "WorkExperience",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Position",
                table: "WorkExperience",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Organization",
                table: "WorkExperience",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "WorkExperience",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "UserInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "RuSurname",
                table: "UserInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "RuName",
                table: "UserInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnSurname",
                table: "UserInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EnName",
                table: "UserInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "UserInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "User",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Summary",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "Summary",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "StreamName",
                table: "Streams",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skills",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonPosition",
                table: "Recommendations",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PersonName",
                table: "Recommendations",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "Recommendations",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Portfolio",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "Portfolio",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "MilitaryStatus",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "MilitaryStatus",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "ForeignLanguages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Organization",
                table: "Exams",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ExamName",
                table: "Exams",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "Exams",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                table: "Education",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EducationalInstitution",
                table: "Education",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Department",
                table: "Education",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "Education",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "Education",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "YearOfGraduation",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Specialization",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Organization",
                table: "Courses",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "Courses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Skype",
                table: "ContactInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Linkedin",
                table: "ContactInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "ContactInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Certificates",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "Certificates",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "Certificates",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "AdditionalInfo",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CVId",
                table: "AdditionalInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ForeignLanguages",
                table: "ForeignLanguages",
                columns: new[] { "CVId", "LanguageId", "LanguageLevelId" });

            migrationBuilder.CreateTable(
                name: "CVs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CVs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CVs_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkExperience_CVId",
                table: "WorkExperience",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserInfoId",
                table: "User",
                column: "UserInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_Recommendations_CVId",
                table: "Recommendations",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_Portfolio_CVId",
                table: "Portfolio",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_CVId",
                table: "Exams",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_Education_CVId",
                table: "Education",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_CVId",
                table: "Courses",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactInfo_CVId",
                table: "ContactInfo",
                column: "CVId");

            migrationBuilder.CreateIndex(
                name: "IX_CVs_StudentId",
                table: "CVs",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ContactInfo_CVs_CVId",
                table: "ContactInfo",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_CVs_CVId",
                table: "Courses",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Education_CVs_CVId",
                table: "Education",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_CVs_CVId",
                table: "Exams",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ForeignLanguages_CVs_CVId",
                table: "ForeignLanguages",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Portfolio_CVs_CVId",
                table: "Portfolio",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Recommendations_CVs_CVId",
                table: "Recommendations",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserInfo_UserInfoId",
                table: "User",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WorkExperience_CVs_CVId",
                table: "WorkExperience",
                column: "CVId",
                principalTable: "CVs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
