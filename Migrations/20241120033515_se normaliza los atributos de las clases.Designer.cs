﻿// <auto-generated />
using System;
using AMorfar_MVC.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AMorfar_MVC.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20241120033515_se normaliza los atributos de las clases")]
    partial class senormalizalosatributosdelasclases
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AMorfar_MVC.Models.Comanda", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PedidoActual")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<double>("TotalPorPersona")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PedidoActual");

                    b.ToTable("Comandas");
                });

            modelBuilder.Entity("AMorfar_MVC.Models.ComandasPersonas", b =>
                {
                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<int>("IdComanda")
                        .HasColumnType("int");

                    b.Property<int>("ComandaId")
                        .HasColumnType("int");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.HasKey("IdPersona", "IdComanda");

                    b.HasIndex("ComandaId");

                    b.HasIndex("PersonaId");

                    b.ToTable("ComandasPersonas");
                });

            modelBuilder.Entity("AMorfar_MVC.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("Propina")
                        .HasColumnType("float");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("AMorfar_MVC.Models.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PedidoActual")
                        .HasColumnType("int");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("PedidoActual");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("AMorfar_MVC.Models.Comanda", b =>
                {
                    b.HasOne("AMorfar_MVC.Models.Pedido", "Pedido")
                        .WithMany("Comandas")
                        .HasForeignKey("PedidoActual")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("AMorfar_MVC.Models.ComandasPersonas", b =>
                {
                    b.HasOne("AMorfar_MVC.Models.Comanda", "Comanda")
                        .WithMany()
                        .HasForeignKey("ComandaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMorfar_MVC.Models.Persona", "Persona")
                        .WithMany()
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comanda");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("AMorfar_MVC.Models.Persona", b =>
                {
                    b.HasOne("AMorfar_MVC.Models.Pedido", "Pedido")
                        .WithMany("Personas")
                        .HasForeignKey("PedidoActual")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("AMorfar_MVC.Models.Pedido", b =>
                {
                    b.Navigation("Comandas");

                    b.Navigation("Personas");
                });
#pragma warning restore 612, 618
        }
    }
}