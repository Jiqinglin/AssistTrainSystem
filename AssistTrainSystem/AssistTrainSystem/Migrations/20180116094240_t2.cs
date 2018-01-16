using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AssistTrainSystem.Migrations
{
    public partial class t2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "breakfirst",
                table: "PersonalPay",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "dinner",
                table: "PersonalPay",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "lunch",
                table: "PersonalPay",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "breakfirst",
                table: "PersonalPay");

            migrationBuilder.DropColumn(
                name: "dinner",
                table: "PersonalPay");

            migrationBuilder.DropColumn(
                name: "lunch",
                table: "PersonalPay");
        }
    }
}
