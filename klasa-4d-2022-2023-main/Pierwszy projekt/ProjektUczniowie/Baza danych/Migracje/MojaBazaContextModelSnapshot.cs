﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjektUczniowie.Baza_danych.Context;

namespace ProjektUczniowie.Bazadanych.Migracje
{
    [DbContext(typeof(MojaBazaContext))]
    partial class MojaBazaContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.16");

            modelBuilder.Entity("ProjektUczniowie.Baza_danych.Model.Klasa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("NazwaKlasy")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Klasy");
                });

            modelBuilder.Entity("ProjektUczniowie.Baza_danych.Model.Uczen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Imie")
                        .HasColumnType("TEXT");

                    b.Property<int>("KlasaId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nazwisko")
                        .HasColumnType("TEXT");

                    b.Property<int>("RokUrodzenia")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("KlasaId");

                    b.ToTable("Uczniowie");
                });

            modelBuilder.Entity("ProjektUczniowie.Baza_danych.Model.Uczen", b =>
                {
                    b.HasOne("ProjektUczniowie.Baza_danych.Model.Klasa", "Klasa")
                        .WithMany()
                        .HasForeignKey("KlasaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Klasa");
                });
#pragma warning restore 612, 618
        }
    }
}
