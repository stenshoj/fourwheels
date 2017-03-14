using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FourWheel.Web.DataContext;

namespace FourWheel.Web.Migrations
{
    [DbContext(typeof(FourWheelContext))]
    [Migration("20170314143532_Init1")]
    partial class Init1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FourWheel.Web.Models.Car", b =>
                {
                    b.Property<string>("Make");

                    b.Property<string>("Model");

                    b.Property<int>("Year");

                    b.HasKey("Make", "Model", "Year");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("FourWheel.Web.Models.CarSparePart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("SparePartId");

                    b.HasKey("Id");

                    b.HasIndex("SparePartId");

                    b.ToTable("CarSparePart");
                });

            modelBuilder.Entity("FourWheel.Web.Models.RegisteredCar", b =>
                {
                    b.Property<string>("Registration");

                    b.Property<string>("CarMake");

                    b.Property<string>("CarModel");

                    b.Property<int?>("CarYear");

                    b.HasKey("Registration");

                    b.HasIndex("CarMake", "CarModel", "CarYear");

                    b.ToTable("RegisteredCars");
                });

            modelBuilder.Entity("FourWheel.Web.Models.SparePart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CarMake");

                    b.Property<string>("CarModel");

                    b.Property<int?>("CarYear");

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CarMake", "CarModel", "CarYear");

                    b.ToTable("SpareParts");
                });

            modelBuilder.Entity("FourWheel.Web.Models.CarSparePart", b =>
                {
                    b.HasOne("FourWheel.Web.Models.SparePart")
                        .WithMany("Cars")
                        .HasForeignKey("SparePartId");
                });

            modelBuilder.Entity("FourWheel.Web.Models.RegisteredCar", b =>
                {
                    b.HasOne("FourWheel.Web.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarMake", "CarModel", "CarYear");
                });

            modelBuilder.Entity("FourWheel.Web.Models.SparePart", b =>
                {
                    b.HasOne("FourWheel.Web.Models.Car")
                        .WithMany("SpareParts")
                        .HasForeignKey("CarMake", "CarModel", "CarYear");
                });
        }
    }
}
