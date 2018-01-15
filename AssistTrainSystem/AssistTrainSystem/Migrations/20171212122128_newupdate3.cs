using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AssistTrainSystem.Migrations
{
    public partial class newupdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "FlexiableAbility");

            migrationBuilder.AddColumn<double>(
                name: "flexible_num",
                table: "FlexiableAbility",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "flexible_score",
                table: "FlexiableAbility",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "flexible_num",
                table: "FlexiableAbility");

            migrationBuilder.DropColumn(
                name: "flexible_score",
                table: "FlexiableAbility");

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "FlexiableAbility",
                nullable: false,
                defaultValue: 0);
        }
    }
}
