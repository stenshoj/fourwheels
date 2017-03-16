using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace FourWheel.Web.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisteredCars",
                columns: table => new
                {
                    Registration = table.Column<string>(nullable: false),
                    CarMake = table.Column<string>(nullable: true),
                    CarModel = table.Column<string>(nullable: true),
                    CarYear = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisteredCars", x => x.Registration);
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    EndTime = table.Column<DateTime>(nullable: false),
                    RegisteredCarRegistration = table.Column<string>(nullable: true),
                    StartTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tasks_RegisteredCars_RegisteredCarRegistration",
                        column: x => x.RegisteredCarRegistration,
                        principalTable: "RegisteredCars",
                        principalColumn: "Registration",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SpareParts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpareParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpareParts_Tasks_TaskId",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cars",
                columns: table => new
                {
                    Make = table.Column<string>(nullable: false),
                    Model = table.Column<string>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    SparePartId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cars", x => new { x.Make, x.Model, x.Year });
                    table.ForeignKey(
                        name: "FK_Cars_SpareParts_SparePartId",
                        column: x => x.SparePartId,
                        principalTable: "SpareParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cars_SparePartId",
                table: "Cars",
                column: "SparePartId");

            migrationBuilder.CreateIndex(
                name: "IX_RegisteredCars_CarMake_CarModel_CarYear",
                table: "RegisteredCars",
                columns: new[] { "CarMake", "CarModel", "CarYear" });

            migrationBuilder.CreateIndex(
                name: "IX_SpareParts_TaskId",
                table: "SpareParts",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_RegisteredCarRegistration",
                table: "Tasks",
                column: "RegisteredCarRegistration");

            migrationBuilder.AddForeignKey(
                name: "FK_RegisteredCars_Cars_CarMake_CarModel_CarYear",
                table: "RegisteredCars",
                columns: new[] { "CarMake", "CarModel", "CarYear" },
                principalTable: "Cars",
                principalColumns: new[] { "Make", "Model", "Year" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cars_SpareParts_SparePartId",
                table: "Cars");

            migrationBuilder.DropTable(
                name: "SpareParts");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "RegisteredCars");

            migrationBuilder.DropTable(
                name: "Cars");
        }
    }
}
