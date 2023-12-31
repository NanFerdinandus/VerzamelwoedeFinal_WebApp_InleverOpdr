﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApp_TestApp_W3_InlvrOpdr.Models;

#nullable disable

namespace WebApp_TestApp_W3_InlvrOpdr.Migrations
{
    [DbContext(typeof(AppDBContext))]
    [Migration("20231018135500_UpdatedPostzegel")]
    partial class UpdatedPostzegel
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebApp_TestApp_W3_InlvrOpdr.Models.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Beschrijving")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CategorieNaam")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EigenaarId")
                        .HasColumnType("int");

                    b.Property<int?>("PostzegelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EigenaarId");

                    b.HasIndex("PostzegelId");

                    b.ToTable("Categorieën");
                });

            modelBuilder.Entity("WebApp_TestApp_W3_InlvrOpdr.Models.Favoriet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GebruikerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GebruikerId");

                    b.ToTable("Favorieten");
                });

            modelBuilder.Entity("WebApp_TestApp_W3_InlvrOpdr.Models.Gebruiker", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Gebruikersnaam")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Wachtwoord")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gebruikers");
                });

            modelBuilder.Entity("WebApp_TestApp_W3_InlvrOpdr.Models.Postzegel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Conditie")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EigenaarId")
                        .HasColumnType("int");

                    b.Property<int?>("FavorietId")
                        .HasColumnType("int");

                    b.Property<bool>("IsFavoriet")
                        .HasColumnType("bit");

                    b.Property<string>("LandVanHerkomst")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Uitgiftejaar")
                        .HasColumnType("int");

                    b.Property<decimal>("Waarde")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("EigenaarId");

                    b.HasIndex("FavorietId");

                    b.ToTable("Postzegels");
                });

            modelBuilder.Entity("WebApp_TestApp_W3_InlvrOpdr.Models.Categorie", b =>
                {
                    b.HasOne("WebApp_TestApp_W3_InlvrOpdr.Models.Gebruiker", "Eigenaar")
                        .WithMany()
                        .HasForeignKey("EigenaarId");

                    b.HasOne("WebApp_TestApp_W3_InlvrOpdr.Models.Postzegel", "Postzegel")
                        .WithMany()
                        .HasForeignKey("PostzegelId");

                    b.Navigation("Eigenaar");

                    b.Navigation("Postzegel");
                });

            modelBuilder.Entity("WebApp_TestApp_W3_InlvrOpdr.Models.Favoriet", b =>
                {
                    b.HasOne("WebApp_TestApp_W3_InlvrOpdr.Models.Gebruiker", "Eigenaar")
                        .WithMany("Favorieten")
                        .HasForeignKey("GebruikerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Eigenaar");
                });

            modelBuilder.Entity("WebApp_TestApp_W3_InlvrOpdr.Models.Postzegel", b =>
                {
                    b.HasOne("WebApp_TestApp_W3_InlvrOpdr.Models.Gebruiker", "Eigenaar")
                        .WithMany("Postzegels")
                        .HasForeignKey("EigenaarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebApp_TestApp_W3_InlvrOpdr.Models.Favoriet", null)
                        .WithMany("FavorietePostzegels")
                        .HasForeignKey("FavorietId");

                    b.Navigation("Eigenaar");
                });

            modelBuilder.Entity("WebApp_TestApp_W3_InlvrOpdr.Models.Favoriet", b =>
                {
                    b.Navigation("FavorietePostzegels");
                });

            modelBuilder.Entity("WebApp_TestApp_W3_InlvrOpdr.Models.Gebruiker", b =>
                {
                    b.Navigation("Favorieten");

                    b.Navigation("Postzegels");
                });
#pragma warning restore 612, 618
        }
    }
}
