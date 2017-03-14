using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FourWheel.Web.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_SpareParts_SparePartId",
                table: "Cars");

            migrationBuilder.DropIndex(
                name: "IX_Cars_SparePartId",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "SparePartId",
                table: "Cars");

            migrationBuilder.CreateTable(
                name: "CarSparePart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SparePartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarSparePart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarSparePart_SpareParts_SparePartId",
                        column: x => x.SparePartId,
                        principalTable: "SpareParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_CarSparePart_SparePartId",
                table: "CarSparePart",
                column: "SparePartId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpareParts_Cars_CarMake_CarModel_CarYear",
                table: "SpareParts",
                columns: new[] { "CarMake", "CarModel", "CarYear" },
                principalTable: "Cars",
                principalColumns: new[] { "Make", "Model", "Year" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropTable(
                name: "CarSparePart");

            migrationBuilder.AddColumn<int>(
                name: "SparePartId",
                table: "Cars",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SparePartId",
                table: "Cars",
                column: "SparePartId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_SpareParts_SparePartId",
                table: "Cars",
                column: "SparePartId",
                principalTable: "SpareParts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
