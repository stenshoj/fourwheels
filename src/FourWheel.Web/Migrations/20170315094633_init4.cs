using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FourWheel.Web.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarSparePart_SpareParts_SparePartId",
                table: "CarSparePart");

            migrationBuilder.DropForeignKey(
                name: "FK_CarSparePart_Cars_CarMake_CarModel_CarYear",
                table: "CarSparePart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarSparePart",
                table: "CarSparePart");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarSpareParts",
                table: "CarSparePart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarSpareParts_SpareParts_SparePartId",
                table: "CarSparePart",
                column: "SparePartId",
                principalTable: "SpareParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarSpareParts_Cars_CarMake_CarModel_CarYear",
                table: "CarSparePart",
                columns: new[] { "CarMake", "CarModel", "CarYear" },
                principalTable: "Cars",
                principalColumns: new[] { "Make", "Model", "Year" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_CarSparePart_CarMake_CarModel_CarYear",
                table: "CarSparePart",
                newName: "IX_CarSpareParts_CarMake_CarModel_CarYear");

            migrationBuilder.RenameIndex(
                name: "IX_CarSparePart_SparePartId",
                table: "CarSparePart",
                newName: "IX_CarSpareParts_SparePartId");

            migrationBuilder.RenameTable(
                name: "CarSparePart",
                newName: "CarSpareParts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarSpareParts_SpareParts_SparePartId",
                table: "CarSpareParts");

            migrationBuilder.DropForeignKey(
                name: "FK_CarSpareParts_Cars_CarMake_CarModel_CarYear",
                table: "CarSpareParts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CarSpareParts",
                table: "CarSpareParts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CarSparePart",
                table: "CarSpareParts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarSparePart_SpareParts_SparePartId",
                table: "CarSpareParts",
                column: "SparePartId",
                principalTable: "SpareParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CarSparePart_Cars_CarMake_CarModel_CarYear",
                table: "CarSpareParts",
                columns: new[] { "CarMake", "CarModel", "CarYear" },
                principalTable: "Cars",
                principalColumns: new[] { "Make", "Model", "Year" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.RenameIndex(
                name: "IX_CarSpareParts_CarMake_CarModel_CarYear",
                table: "CarSpareParts",
                newName: "IX_CarSparePart_CarMake_CarModel_CarYear");

            migrationBuilder.RenameIndex(
                name: "IX_CarSpareParts_SparePartId",
                table: "CarSpareParts",
                newName: "IX_CarSparePart_SparePartId");

            migrationBuilder.RenameTable(
                name: "CarSpareParts",
                newName: "CarSparePart");
        }
    }
}
