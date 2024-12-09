﻿// <auto-generated />
using System;
using IntroduccionAEFCore.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IntroduccionAEFCore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241208201022_otra")]
    partial class otra
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GeneroPelicula", b =>
                {
                    b.Property<int>("GenerosId")
                        .HasColumnType("int");

                    b.Property<int>("PeliculasId")
                        .HasColumnType("int");

                    b.HasKey("GenerosId", "PeliculasId");

                    b.HasIndex("PeliculasId");

                    b.ToTable("GeneroPelicula");

                    b.HasData(
                        new
                        {
                            GenerosId = 5,
                            PeliculasId = 2
                        },
                        new
                        {
                            GenerosId = 5,
                            PeliculasId = 3
                        },
                        new
                        {
                            GenerosId = 6,
                            PeliculasId = 4
                        });
                });

            modelBuilder.Entity("IntroduccionAEFCore.Modelos.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("FechaNacimiento")
                        .HasColumnType("date");

                    b.Property<decimal>("Fortuna")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Actores");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            FechaNacimiento = new DateTime(1948, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fortuna = 15000m,
                            Name = "Samuel L. Jackson"
                        },
                        new
                        {
                            Id = 3,
                            FechaNacimiento = new DateTime(1965, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Fortuna = 18000m,
                            Name = "Robert Downey Jr."
                        });
                });

            modelBuilder.Entity("IntroduccionAEFCore.Modelos.Comentario", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("Contenido")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.Property<bool>("Recomendar")
                        .HasColumnType("bit");

                    b.HasKey("id");

                    b.HasIndex("PeliculaId");

                    b.ToTable("Comentarios");

                    b.HasData(
                        new
                        {
                            id = 2,
                            Contenido = "Muy Buena!!",
                            PeliculaId = 2,
                            Recomendar = true
                        },
                        new
                        {
                            id = 3,
                            Contenido = "Dura dura",
                            PeliculaId = 2,
                            Recomendar = true
                        },
                        new
                        {
                            id = 4,
                            Contenido = "no debieron hacer eso....",
                            PeliculaId = 3,
                            Recomendar = false
                        });
                });

            modelBuilder.Entity("IntroduccionAEFCore.Modelos.Genero", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Generos");

                    b.HasData(
                        new
                        {
                            Id = 5,
                            Name = "Ciencia Ficcion"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Animacion"
                        });
                });

            modelBuilder.Entity("IntroduccionAEFCore.Modelos.Pelicula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("EnCine")
                        .HasColumnType("bit");

                    b.Property<DateTime>("FechaEstreno")
                        .HasColumnType("date");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("Id");

                    b.ToTable("Peliculas");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            EnCine = false,
                            FechaEstreno = new DateTime(2019, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titulo = "Avengers Endgame"
                        },
                        new
                        {
                            Id = 3,
                            EnCine = false,
                            FechaEstreno = new DateTime(2021, 12, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titulo = "Spider-Man: No Way Home"
                        },
                        new
                        {
                            Id = 4,
                            EnCine = false,
                            FechaEstreno = new DateTime(2022, 10, 7, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Titulo = "Spider-Man: Across the Spider-Verse (Part One)"
                        });
                });

            modelBuilder.Entity("IntroduccionAEFCore.Modelos.PeliculaActor", b =>
                {
                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.Property<int>("ActorId")
                        .HasColumnType("int");

                    b.Property<int>("Orden")
                        .HasColumnType("int");

                    b.Property<string>("Personaje")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.HasKey("PeliculaId", "ActorId");

                    b.HasIndex("ActorId");

                    b.ToTable("PeliculasActores");

                    b.HasData(
                        new
                        {
                            PeliculaId = 2,
                            ActorId = 2,
                            Orden = 2,
                            Personaje = "Nick Fury"
                        },
                        new
                        {
                            PeliculaId = 3,
                            ActorId = 2,
                            Orden = 1,
                            Personaje = "Nick Fury"
                        },
                        new
                        {
                            PeliculaId = 2,
                            ActorId = 3,
                            Orden = 1,
                            Personaje = "Iron Man"
                        });
                });

            modelBuilder.Entity("GeneroPelicula", b =>
                {
                    b.HasOne("IntroduccionAEFCore.Modelos.Genero", null)
                        .WithMany()
                        .HasForeignKey("GenerosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntroduccionAEFCore.Modelos.Pelicula", null)
                        .WithMany()
                        .HasForeignKey("PeliculasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IntroduccionAEFCore.Modelos.Comentario", b =>
                {
                    b.HasOne("IntroduccionAEFCore.Modelos.Pelicula", "Pelicula")
                        .WithMany("Comentarios")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("IntroduccionAEFCore.Modelos.PeliculaActor", b =>
                {
                    b.HasOne("IntroduccionAEFCore.Modelos.Actor", "Actor")
                        .WithMany("PeliculasActores")
                        .HasForeignKey("ActorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IntroduccionAEFCore.Modelos.Pelicula", "Pelicula")
                        .WithMany("PeliculasActores")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Actor");

                    b.Navigation("Pelicula");
                });

            modelBuilder.Entity("IntroduccionAEFCore.Modelos.Actor", b =>
                {
                    b.Navigation("PeliculasActores");
                });

            modelBuilder.Entity("IntroduccionAEFCore.Modelos.Pelicula", b =>
                {
                    b.Navigation("Comentarios");

                    b.Navigation("PeliculasActores");
                });
#pragma warning restore 612, 618
        }
    }
}
