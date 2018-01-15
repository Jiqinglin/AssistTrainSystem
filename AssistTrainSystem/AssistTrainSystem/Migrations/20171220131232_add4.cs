using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AssistTrainSystem.Migrations
{
    public partial class add4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NormalTrain",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Leg_train = table.Column<int>(type: "int", nullable: false),
                    abdomen_train = table.Column<int>(type: "int", nullable: false),
                    arm_train = table.Column<int>(type: "int", nullable: false),
                    back_train = table.Column<int>(type: "int", nullable: false),
                    chesk_train = table.Column<int>(type: "int", nullable: false),
                    create_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    explosive_train = table.Column<int>(type: "int", nullable: false),
                    shoulder_train = table.Column<int>(type: "int", nullable: false),
                    stamina_train = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormalTrain", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PersonalNormlTrain",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Leg_train = table.Column<int>(type: "int", nullable: false),
                    abdomen_train = table.Column<int>(type: "int", nullable: false),
                    arm_train = table.Column<int>(type: "int", nullable: false),
                    back_train = table.Column<int>(type: "int", nullable: false),
                    chesk_train = table.Column<int>(type: "int", nullable: false),
                    explosive_train = table.Column<int>(type: "int", nullable: false),
                    shoulder_train = table.Column<int>(type: "int", nullable: false),
                    stamina_train = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalNormlTrain", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NormalTrain");

            migrationBuilder.DropTable(
                name: "PersonalNormlTrain");
        }
    }
}
