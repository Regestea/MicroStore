using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserAccount.API.Migrations
{
    public partial class UserProfileImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "CreatedDate",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ModifiedDate",
                table: "Addresses",
                type: "timestamp with time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Addresses");
        }
    }
}
