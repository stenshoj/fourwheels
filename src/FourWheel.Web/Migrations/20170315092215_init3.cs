using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FourWheel.Web.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpareParts_Tasks_TaskId",
                table: "SpareParts");

            migrationBuilder.DropIndex(
                name: "IX_SpareParts_TaskId",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "SpareParts");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "SpareParts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_TaskId",
                table: "SpareParts",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_Tasks_TaskId",
                table: "SpareParts",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
