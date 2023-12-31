﻿// <auto-generated />
using System;
using Backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace beckend.Migrations
{
    [DbContext(typeof(BatidaPontoContext))]
    partial class BatidaPontoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Backend.Models.Marcacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Data")
                        .HasColumnType("text");

                    b.Property<string>("Horario")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Marcacoes");
                });

            modelBuilder.Entity("Backend.Models.Registro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("EntradaId")
                        .HasColumnType("integer");

                    b.Property<int?>("SaidaId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EntradaId");

                    b.HasIndex("SaidaId");

                    b.ToTable("Registros");
                });

            modelBuilder.Entity("Backend.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("FullName")
                        .HasColumnType("text")
                        .HasColumnName("full_name");

                    b.Property<string>("Login")
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Backend.Models.Registro", b =>
                {
                    b.HasOne("Backend.Models.Marcacao", "Entrada")
                        .WithMany()
                        .HasForeignKey("EntradaId");

                    b.HasOne("Backend.Models.Marcacao", "Saida")
                        .WithMany()
                        .HasForeignKey("SaidaId");

                    b.Navigation("Entrada");

                    b.Navigation("Saida");
                });
#pragma warning restore 612, 618
        }
    }
}
