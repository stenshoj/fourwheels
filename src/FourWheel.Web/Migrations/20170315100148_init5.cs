using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FourWheel.Web.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpareParts_Tasks_WorkTaskId",
                table: "SpareParts");

            migrationBuilder.DropIndex(
                name: "IX_SpareParts_WorkTaskId",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "WorkTaskId",
                table: "SpareParts");

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
                        name: "FK_WorkTaskSparePart_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkTaskSparePart_SparePartId",
                table: "WorkTaskSparePart",
                column: "SparePartId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTaskSparePart_TaskId",
                table: "WorkTaskSparePart",
                column: "TaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkTaskSparePart");

            migrationBuilder.AddColumn<int>(
                name: "WorkTaskId",
                table: "SpareParts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_WorkTaskId",
                table: "SpareParts",
                column: "WorkTaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_Tasks_WorkTaskId",
                table: "SpareParts",
                column: "WorkTaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
