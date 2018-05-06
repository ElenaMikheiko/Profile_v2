using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Profile.DataAccess.Migrations
{
    public partial class AddNavigationPropertyToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserInfoId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_UserInfoId",
                table: "User",
                column: "UserInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserInfo_UserInfoId",
                table: "User",
                column: "UserInfoId",
                principalTable: "UserInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserInfo_UserInfoId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserInfoId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserInfoId",
                table: "User");
        }
    }
}
