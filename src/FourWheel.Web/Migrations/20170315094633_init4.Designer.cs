using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FourWheel.Web.DataContext;

namespace FourWheel.Web.Migrations
{
    [DbContext(typeof(FourWheelContext))]
    [Migration("20170315094633_init4")]
    partial class init4
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

                    b.Property<string>("CarMake");

                    b.Property<string>("CarModel");

                    b.Property<int?>("CarYear");

                    b.Property<int?>("SparePartId");

                    b.HasKey("Id");

                    b.HasIndex("SparePartId");

                    b.HasIndex("CarMake", "CarModel", "CarYear");

                    b.ToTable("CarSpareParts");
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

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int?>("WorkTaskId");

                    b.HasKey("Id");

                    b.HasIndex("WorkTaskId");

                    b.ToTable("SpareParts");
                });

            modelBuilder.Entity("FourWheel.Web.Models.WorkTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndTime");

                    b.Property<string>("RegisteredCarRegistration");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("RegisteredCarRegistration");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("FourWheel.Web.Models.CarSparePart", b =>
                {
                    b.HasOne("FourWheel.Web.Models.SparePart", "SparePart")
                        .WithMany("CarSpareParts")
                        .HasForeignKey("SparePartId");

                    b.HasOne("FourWheel.Web.Models.Car", "Car")
                        .WithMany("CarSpareParts")
                        .HasForeignKey("CarMake", "CarModel", "CarYear");
                });

            modelBuilder.Entity("FourWheel.Web.Models.RegisteredCar", b =>
                {
                    b.HasOne("FourWheel.Web.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarMake", "CarModel", "CarYear");
                });

            modelBuilder.Entity("FourWheel.Web.Models.SparePart", b =>
                {
                    b.HasOne("FourWheel.Web.Models.WorkTask")
                        .WithMany("SpareParts")
                        .HasForeignKey("WorkTaskId");
                });

            modelBuilder.Entity("FourWheel.Web.Models.WorkTask", b =>
                {
                    b.HasOne("FourWheel.Web.Models.RegisteredCar", "RegisteredCar")
                        .WithMany()
                        .HasForeignKey("RegisteredCarRegistration");
                });
        }
    }
}
