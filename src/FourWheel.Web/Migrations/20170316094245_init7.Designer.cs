using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using FourWheel.Web.DataContext;

namespace FourWheel.Web.Migrations
{
    [DbContext(typeof(FourWheelContext))]
    [Migration("20170316094245_init7")]
    partial class init7
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

            modelBuilder.Entity("FourWheel.Web.Models.Mechanic", b =>
                {
                    b.Property<string>("Username");

                    b.HasKey("Username");

                    b.ToTable("Mechanics");
                });

            modelBuilder.Entity("FourWheel.Web.Models.RegisteredCar", b =>
                {
                    b.Property<string>("Registration");

                    b.Property<string>("CarMake");

                    b.Property<string>("CarModel");

                    b.Property<int?>("CarYear");

                    b.Property<int?>("TaskId");

                    b.HasKey("Registration");

                    b.HasIndex("TaskId");

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

                    b.HasKey("Id");

                    b.ToTable("SpareParts");
                });

            modelBuilder.Entity("FourWheel.Web.Models.WorkTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndTime");

                    b.Property<bool>("IsCompleted");

                    b.Property<bool>("IsStarted");

                    b.Property<string>("MechanicUsername");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("MechanicUsername");

                    b.ToTable("Tasks");
                });

            modelBuilder.Entity("FourWheel.Web.Models.WorkTaskSparePart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("SparePartId");

                    b.Property<int?>("TaskId");

                    b.HasKey("Id");

                    b.HasIndex("SparePartId");

                    b.HasIndex("TaskId");

                    b.ToTable("WorkTaskSparePart");
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
                    b.HasOne("FourWheel.Web.Models.WorkTask", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId");

                    b.HasOne("FourWheel.Web.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarMake", "CarModel", "CarYear");
                });

            modelBuilder.Entity("FourWheel.Web.Models.WorkTask", b =>
                {
                    b.HasOne("FourWheel.Web.Models.Mechanic", "Mechanic")
                        .WithMany("Tasks")
                        .HasForeignKey("MechanicUsername");
                });

            modelBuilder.Entity("FourWheel.Web.Models.WorkTaskSparePart", b =>
                {
                    b.HasOne("FourWheel.Web.Models.SparePart", "SparePart")
                        .WithMany()
                        .HasForeignKey("SparePartId");

                    b.HasOne("FourWheel.Web.Models.WorkTask", "Task")
                        .WithMany("WorkTaskSpareParts")
                        .HasForeignKey("TaskId");
                });
        }
    }
}
