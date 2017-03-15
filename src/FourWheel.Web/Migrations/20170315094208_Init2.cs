using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FourWheel.Web.Migrations
{
    public partial class Init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpareParts_Cars_CarMake_CarModel_CarYear",
                table: "SpareParts");

            migrationBuilder.DropIndex(
                name: "IX_SpareParts_CarMake_CarModel_CarYear",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "CarMake",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "CarModel",
                table: "SpareParts");

            migrationBuilder.DropColumn(
                name: "CarYear",
                table: "SpareParts");

            migrationBuilder.AddColumn<string>(
                name: "CarMake",
                table: "CarSparePart",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarModel",
                table: "CarSparePart",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarYear",
                table: "CarSparePart",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarSparePart_CarMake_CarModel_CarYear",
                table: "CarSparePart",
                columns: new[] { "CarMake", "CarModel", "CarYear" });

            migrationBuilder.AddForeignKey(
                name: "FK_CarSparePart_Cars_CarMake_CarModel_CarYear",
                table: "CarSparePart",
                columns: new[] { "CarMake", "CarModel", "CarYear" },
                principalTable: "Cars",
                principalColumns: new[] { "Make", "Model", "Year" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarSparePart_Cars_CarMake_CarModel_CarYear",
                table: "CarSparePart");

            migrationBuilder.DropIndex(
                name: "IX_CarSparePart_CarMake_CarModel_CarYear",
                table: "CarSparePart");

            migrationBuilder.DropColumn(
                name: "CarMake",
                table: "CarSparePart");

            migrationBuilder.DropColumn(
                name: "CarModel",
                table: "CarSparePart");

            migrationBuilder.DropColumn(
                name: "CarYear",
                table: "CarSparePart");

            migrationBuilder.AddColumn<string>(
                name: "CarMake",
                table: "SpareParts",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CarModel",
                table: "SpareParts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CarYear",
                table: "SpareParts",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_CarMake_CarModel_CarYear",
                table: "SpareParts",
                columns: new[] { "CarMake", "CarModel", "CarYear" });

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_Cars_CarMake_CarModel_CarYear",
                table: "SpareParts",
                columns: new[] { "CarMake", "CarModel", "CarYear" },
                principalTable: "Cars",
                principalColumns: new[] { "Make", "Model", "Year" },
                onDelete: ReferentialAction.Restrict);
        }
    }
}
