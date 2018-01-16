using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AssistTrainSystem.Migrations
{
    public partial class t : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "income",
                table: "PersonalPay");

            migrationBuilder.AddColumn<double>(
                name: "all_income",
                table: "PersonalPay",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "breakfirset_income",
                table: "PersonalPay",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "dinner_income",
                table: "PersonalPay",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "lunch_income",
                table: "PersonalPay",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "all_income",
                table: "PersonalPay");

            migrationBuilder.DropColumn(
                name: "breakfirset_income",
                table: "PersonalPay");

            migrationBuilder.DropColumn(
                name: "dinner_income",
                table: "PersonalPay");

            migrationBuilder.DropColumn(
                name: "lunch_income",
                table: "PersonalPay");

            migrationBuilder.AddColumn<double>(
                name: "income",
                table: "PersonalPay",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
