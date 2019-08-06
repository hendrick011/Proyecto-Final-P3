﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence;

namespace Persistence.Migrations
{
    [DbContext(typeof(BreadDbContext))]
    partial class BreadDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Model.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<string>("Nombre");

                    b.Property<string>("Telefono");

                    b.HasKey("ClienteId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Model.Compra", b =>
                {
                    b.Property<int>("IdCompra")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClienteId");

                    b.Property<int?>("empleadoIdEmpleado");

                    b.Property<int?>("productoIdProducto");

                    b.HasKey("IdCompra");

                    b.HasIndex("ClienteId");

                    b.HasIndex("empleadoIdEmpleado");

                    b.HasIndex("productoIdProducto");

                    b.ToTable("Compra");
                });

            modelBuilder.Entity("Model.Empleado", b =>
                {
                    b.Property<int>("IdEmpleado")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<string>("Nombre");

                    b.Property<string>("puesto");

                    b.HasKey("IdEmpleado");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("Model.Producto", b =>
                {
                    b.Property<int>("IdProducto")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Precio");

                    b.Property<int?>("ProveedorIdProveedor");

                    b.Property<string>("Tipo");

                    b.HasKey("IdProducto");

                    b.HasIndex("ProveedorIdProveedor");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("Model.Proveedor", b =>
                {
                    b.Property<int>("IdProveedor")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido");

                    b.Property<string>("Empresa");

                    b.Property<string>("Nombre");

                    b.Property<string>("Telefono");

                    b.HasKey("IdProveedor");

                    b.ToTable("Proveedor");
                });

            modelBuilder.Entity("Model.Compra", b =>
                {
                    b.HasOne("Model.Cliente", "cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.HasOne("Model.Empleado", "empleado")
                        .WithMany()
                        .HasForeignKey("empleadoIdEmpleado");

                    b.HasOne("Model.Producto", "producto")
                        .WithMany()
                        .HasForeignKey("productoIdProducto");
                });

            modelBuilder.Entity("Model.Producto", b =>
                {
                    b.HasOne("Model.Proveedor", "Proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorIdProveedor");
                });
#pragma warning restore 612, 618
        }
    }
}
