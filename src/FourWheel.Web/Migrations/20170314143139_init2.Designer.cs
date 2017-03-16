using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FourWheel.Web.DataContext;

namespace FourWheel.Web.Migrations
{
    [DbContext(typeof(FourWheelContext))]
    [Migration("20170314143139_init2")]
    partial class init2
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

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.Property<int>("Quantity");

                    b.Property<int?>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("TaskId");

                    b.ToTable("SpareParts");
                });

            modelBuilder.Entity("FourWheel.Web.Models.Task", b =>
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
                    b.HasOne("FourWheel.Web.Models.SparePart")
                        .WithMany("CarSpareParts")
                        .HasForeignKey("SparePartId");

                    b.HasOne("FourWheel.Web.Models.Car")
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
                    b.HasOne("FourWheel.Web.Models.Task")
                        .WithMany("SpareParts")
                        .HasForeignKey("TaskId");
                });

            modelBuilder.Entity("FourWheel.Web.Models.Task", b =>
                {
                    b.HasOne("FourWheel.Web.Models.RegisteredCar", "RegisteredCar")
                        .WithMany()
                        .HasForeignKey("RegisteredCarRegistration");
                });
        }
    }
}
