using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FourWheel.Web.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mechanics",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanics", x => x.Username);
                });

            migrationBuilder.AddColumn<bool>(
                name: "IsCompleted",
                table: "Tasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsStarted",
                table: "Tasks",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "MechanicUsername",
                table: "Tasks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_MechanicUsername",
                table: "Tasks",
                column: "MechanicUsername");

            migrationBuilder.AddForeignKey(
                name: "FK_Tasks_Mechanics_MechanicUsername",
                table: "Tasks",
                column: "MechanicUsername",
                principalTable: "Mechanics",
                principalColumn: "Username",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tasks_Mechanics_MechanicUsername",
                table: "Tasks");

            migrationBuilder.DropIndex(
                name: "IX_Tasks_MechanicUsername",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsCompleted",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "IsStarted",
                table: "Tasks");

            migrationBuilder.DropColumn(
                name: "MechanicUsername",
                table: "Tasks");

            migrationBuilder.DropTable(
                name: "Mechanics");
        }
    }
}
