﻿// <auto-generated />
using System;
using App.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace App.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("App.Models.Tarea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Color")
                        .HasColumnType("text");

                    b.Property<DateTimeOffset>("Fim")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTimeOffset>("Inicio")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Responsable")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Tareas");
                });

            modelBuilder.Entity("TareaTarea", b =>
                {
                    b.Property<int>("TareasHijasId")
                        .HasColumnType("integer");

                    b.Property<int>("TareasPaisId")
                        .HasColumnType("integer");

                    b.HasKey("TareasHijasId", "TareasPaisId");

                    b.HasIndex("TareasPaisId");

                    b.ToTable("TareaTarea");
                });

            modelBuilder.Entity("TareaTarea", b =>
                {
                    b.HasOne("App.Models.Tarea", null)
                        .WithMany()
                        .HasForeignKey("TareasHijasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.Models.Tarea", null)
                        .WithMany()
                        .HasForeignKey("TareasPaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
