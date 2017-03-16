using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FourWheel.Web.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_RegisteredCars_RegisteredCarRegistration",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_RegisteredCarRegistration",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "RegisteredCarRegistration",
                table: "Tasks");

            migrationBuilder.AddColumn<int>(
                name: "TaskId",
                table: "RegisteredCars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredCars_TaskId",
                table: "RegisteredCars",
                column: "TaskId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredCars_Tasks_TaskId",
                table: "RegisteredCars",
                column: "TaskId",
                principalTable: "Tasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegisteredCars_Tasks_TaskId",
                table: "RegisteredCars");

            migrationBuilder.DropIndex(
                name: "IX_RegisteredCars_TaskId",
                table: "RegisteredCars");

            migrationBuilder.DropColumn(
                name: "TaskId",
                table: "RegisteredCars");

            migrationBuilder.AddColumn<string>(
                name: "RegisteredCarRegistration",
                table: "Tasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_RegisteredCarRegistration",
                table: "Tasks",
                column: "RegisteredCarRegistration");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_RegisteredCars_RegisteredCarRegistration",
                table: "Tasks",
                column: "RegisteredCarRegistration",
                principalTable: "RegisteredCars",
                principalColumn: "Registration",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
