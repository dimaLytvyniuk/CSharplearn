using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace EnglishProject.Migrations
{
    public partial class InitialDatabase4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.DropColumn(
                name: "TaskID",
                table: "TaskInfo");

            migrationBuilder.AddColumn<int>(
                name: "EnglishTaskID",
                table: "TaskInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EnglishTask",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    EnglishLevel = table.Column<int>(type: "int", nullable: false),
                    Example = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GrammarPart = table.Column<byte>(type: "tinyint", nullable: false),
                    TaskType = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnglishTask", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EnglishTask");

            migrationBuilder.DropColumn(
                name: "EnglishTaskID",
                table: "TaskInfo");

            migrationBuilder.AddColumn<int>(
                name: "TaskID",
                table: "TaskInfo",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Answer = table.Column<string>(nullable: false),
                    Count = table.Column<int>(nullable: false),
                    EnglishLevel = table.Column<int>(nullable: false),
                    Example = table.Column<string>(nullable: true),
                    GrammarPart = table.Column<byte>(nullable: false),
                    TaskType = table.Column<int>(nullable: false),
                    Text = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.ID);
                });
        }
    }
}
