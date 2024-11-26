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
    [Migration("20241126010001_Migracion1")]
    partial class Migracion1
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
                    b.Property<int>("ComandaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComandaId"));

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.Property<double>("TotalPorPersona")
                        .HasColumnType("float");

                    b.HasKey("ComandaId");

                    b.ToTable("Comandas");
                });

            modelBuilder.Entity("AMorfar_MVC.Models.ComandasPersonas", b =>
                {
                    b.Property<int>("IdPersona")
                        .HasColumnType("int");

                    b.Property<int>("IdComanda")
                        .HasColumnType("int");

                    b.HasKey("IdPersona", "IdComanda");

                    b.HasIndex("IdComanda");

                    b.ToTable("ComandasPersonas");
                });

            modelBuilder.Entity("AMorfar_MVC.Models.Pedido", b =>
                {
                    b.Property<int>("PedidoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PedidoId"));

                    b.Property<bool>("Activo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<double>("Propina")
                        .HasColumnType("float");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("PedidoId");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("AMorfar_MVC.Models.Persona", b =>
                {
                    b.Property<int>("PersonaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonaId"));

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PedidoActual")
                        .HasColumnType("int");

                    b.Property<double>("Saldo")
                        .HasColumnType("float");

                    b.HasKey("PersonaId");

                    b.HasIndex("PedidoActual");

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("AMorfar_MVC.Models.ComandasPersonas", b =>
                {
                    b.HasOne("AMorfar_MVC.Models.Comanda", "Comanda")
                        .WithMany("ComandasPersonas")
                        .HasForeignKey("IdComanda")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AMorfar_MVC.Models.Persona", "Persona")
                        .WithMany("ComandasPersonas")
                        .HasForeignKey("IdPersona")
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
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pedido");
                });

            modelBuilder.Entity("AMorfar_MVC.Models.Comanda", b =>
                {
                    b.Navigation("ComandasPersonas");
                });

            modelBuilder.Entity("AMorfar_MVC.Models.Pedido", b =>
                {
                    b.Navigation("Personas");
                });

            modelBuilder.Entity("AMorfar_MVC.Models.Persona", b =>
                {
                    b.Navigation("ComandasPersonas");
                });
#pragma warning restore 612, 618
        }
    }
}
