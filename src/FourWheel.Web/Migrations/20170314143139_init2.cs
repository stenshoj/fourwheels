using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FourWheel.Web.Migrations
{
    public partial class init2 : Migration
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
                    CarMake = table.Column<string>(nullable: true),
                    CarModel = table.Column<string>(nullable: true),
                    CarYear = table.Column<int>(nullable: true),
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
                    table.ForeignKey(
                        name: "FK_CarSparePart_Cars_CarMake_CarModel_CarYear",
                        columns: x => new { x.CarMake, x.CarModel, x.CarYear },
                        principalTable: "Cars",
                        principalColumns: new[] { "Make", "Model", "Year" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarSparePart_SparePartId",
                table: "CarSparePart",
                column: "SparePartId");

            migrationBuilder.CreateIndex(
                name: "IX_CarSparePart_CarMake_CarModel_CarYear",
                table: "CarSparePart",
                columns: new[] { "CarMake", "CarModel", "CarYear" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
