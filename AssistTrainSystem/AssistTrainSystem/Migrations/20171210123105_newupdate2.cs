using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace AssistTrainSystem.Migrations
{
    public partial class newupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComtrainAbilities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    age = table.Column<int>(type: "int", nullable: false),
                    create_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    gunhurdle_score = table.Column<int>(type: "int", nullable: false),
                    gunhurdle_time = table.Column<double>(type: "float", nullable: false),
                    threehurdle_score = table.Column<int>(type: "int", nullable: false),
                    threehurdle_time = table.Column<double>(type: "float", nullable: false),
                    threeoffroad_score = table.Column<int>(type: "int", nullable: false),
                    threeoffroad_time = table.Column<double>(type: "float", nullable: false),
                    twohurdle_score = table.Column<int>(type: "int", nullable: false),
                    twohurdle_time = table.Column<double>(type: "float", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComtrainAbilities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FiveoffroadAbilities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    age = table.Column<int>(type: "int", nullable: false),
                    create_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fiveoffroad_score = table.Column<int>(type: "int", nullable: false),
                    fiveoffroad_time = table.Column<double>(type: "float", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FiveoffroadAbilities", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "FourhurdleAbilities",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    age = table.Column<int>(type: "int", nullable: false),
                    create_time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fourhurdle_score = table.Column<int>(type: "int", nullable: false),
                    fourhurdle_time = table.Column<double>(type: "float", nullable: false),
                    user_id = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FourhurdleAbilities", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComtrainAbilities");

            migrationBuilder.DropTable(
                name: "FiveoffroadAbilities");

            migrationBuilder.DropTable(
                name: "FourhurdleAbilities");
        }
    }
}
