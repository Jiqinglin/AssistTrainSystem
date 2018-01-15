using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AssistTrainSystem.Migrations
{
    public partial class update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FlexiableAbility",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    create_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FlexiableAbility", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Horbara_Score",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    num = table.Column<int>(type: "int", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Horbara_Score", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SpeedAbility",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Gunrun_score = table.Column<int>(type: "int", nullable: false),
                    Gunrun_time = table.Column<double>(type: "float", nullable: false),
                    Trun_score = table.Column<int>(type: "int", nullable: false),
                    Trun_time = table.Column<double>(type: "float", nullable: false),
                    create_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpeedAbility", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "StaminaAbility",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    age = table.Column<int>(type: "int", nullable: false),
                    create_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fourrun_score = table.Column<int>(type: "int", nullable: false),
                    fourrun_time = table.Column<double>(type: "float", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    threerun_score = table.Column<int>(type: "int", nullable: false),
                    threerun_time = table.Column<double>(type: "float", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StaminaAbility", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FlexiableAbility");

            migrationBuilder.DropTable(
                name: "Horbara_Score");

            migrationBuilder.DropTable(
                name: "SpeedAbility");

            migrationBuilder.DropTable(
                name: "StaminaAbility");
        }
    }
}
