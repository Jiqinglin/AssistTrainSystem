using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AssistTrainSystem.Migrations
{
    public partial class xxx : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BodyAbility",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    age = table.Column<int>(type: "int", nullable: false),
                    bfp = table.Column<double>(type: "float", nullable: false),
                    bmi = table.Column<double>(type: "float", nullable: false),
                    create_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    height = table.Column<double>(type: "float", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    waist = table.Column<double>(type: "float", nullable: false),
                    weight = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BodyAbility", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "EnergyAbility",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    age = table.Column<int>(type: "int", nullable: false),
                    create_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    doubara_num = table.Column<int>(type: "int", nullable: false),
                    doubara_score = table.Column<int>(type: "int", nullable: false),
                    doubarb_num = table.Column<int>(type: "int", nullable: false),
                    doubarb_score = table.Column<int>(type: "int", nullable: false),
                    horbara_num = table.Column<int>(type: "int", nullable: false),
                    horbara_score = table.Column<int>(type: "int", nullable: false),
                    horbarb_num = table.Column<int>(type: "int", nullable: false),
                    horbarb_score = table.Column<int>(type: "int", nullable: false),
                    pushup_num = table.Column<int>(type: "int", nullable: false),
                    pushup_score = table.Column<int>(type: "int", nullable: false),
                    score = table.Column<int>(type: "int", nullable: false),
                    situp_num = table.Column<int>(type: "int", nullable: false),
                    situp_score = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnergyAbility", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BodyAbility");

            migrationBuilder.DropTable(
                name: "EnergyAbility");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
