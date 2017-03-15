using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FourWheel.Web.Migrations
{
    public partial class Init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WorkTask",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTask", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkTaskSparePart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SparePartId = table.Column<int>(nullable: true),
                    TaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkTaskSparePart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkTaskSparePart_SpareParts_SparePartId",
                        column: x => x.SparePartId,
                        principalTable: "SpareParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkTaskSparePart_WorkTask_TaskId",
                        column: x => x.TaskId,
                        principalTable: "WorkTask",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "RegisteredCars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredCars_TaskId",
                table: "RegisteredCars",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTaskSparePart_SparePartId",
                table: "WorkTaskSparePart",
                column: "SparePartId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTaskSparePart_TaskId",
                table: "WorkTaskSparePart",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredCars_WorkTask_TaskId",
                table: "RegisteredCars",
                column: "TaskId",
                principalTable: "WorkTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredCars_WorkTask_TaskId",
                table: "RegisteredCars");

            migrationBuilder.DropIndex(
                name: "IX_RegisteredCars_TaskId",
                table: "RegisteredCars");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "RegisteredCars");

            migrationBuilder.DropTable(
                name: "WorkTaskSparePart");

            migrationBuilder.DropTable(
                name: "WorkTask");
        }
    }
}
