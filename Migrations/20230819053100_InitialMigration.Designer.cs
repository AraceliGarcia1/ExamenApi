﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyExam;

#nullable disable

namespace MyExam.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230819053100_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MyExam.Models.Propietario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Apellidos")
                        .HasColumnType("longtext");

                    b.Property<string>("CorreoElectronico")
                        .HasColumnType("longtext");

                    b.Property<string>("Direccion")
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .HasColumnType("longtext");

                    b.Property<string>("Telefono")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Propietarios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Apellidos = "Garcia",
                            CorreoElectronico = "araceligarcia@gmail.com",
                            Direccion = "Jiutepec,Morelos",
                            Nombre = "Araceli",
                            Telefono = "7771234567"
                        },
                        new
                        {
                            Id = 2,
                            Apellidos = "Villegas",
                            CorreoElectronico = "thay_villegas@gmail.com",
                            Direccion = "Jiutepec,Morelos",
                            Nombre = "Thayli",
                            Telefono = "7771234897"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
