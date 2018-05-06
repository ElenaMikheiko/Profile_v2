using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Profile.DataAccess.Migrations
{
    public partial class NavigationPropertiesForStudentAndUserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Students_UserInfoId",
                table: "Students",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_UserInfo_UserInfoId",
                table: "Students",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Students_UserInfo_UserInfoId",
                table: "Students");

            migrationBuilder.DropIndex(
                name: "IX_Students_UserInfoId",
                table: "Students");
        }
    }
}
