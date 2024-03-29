﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SistemaDealer1.Models
{
    public class SistemaDealer1DBContext : DbContext
    {
        public SistemaDealer1DBContext() : base("name=SistemaDealerDataContext")
        {

        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Combustible> Combustibles { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Vehiculo> Vehiculoes { get; set; }
        public DbSet<Sucursal> Sucursals { get; set; }
        public DbSet<Transmision> Transmisions { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Factura_Detalle> Factura_Detalles { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Inventario> Inventarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>().HasRequired(x => x.Rol);
            modelBuilder.Entity<Factura>().HasRequired(x => x.Cliente);
            modelBuilder.Entity<Factura>().HasRequired(x => x.Empleado);
            modelBuilder.Entity<Vehiculo>().HasRequired(x => x.Marca);
            modelBuilder.Entity<Vehiculo>().HasRequired(x => x.Modelo);
            modelBuilder.Entity<Vehiculo>().HasRequired(x => x.Combustible);
            modelBuilder.Entity<Vehiculo>().HasRequired(x => x.Transmision);
            modelBuilder.Entity<Modelo>().HasRequired(x => x.Marca);
            modelBuilder.Entity<Sucursal>().HasRequired(x => x.Encargado);
            modelBuilder.Entity<Factura_Detalle>().HasRequired(x => x.Factura);
            modelBuilder.Entity<Factura_Detalle>().HasRequired(x => x.Vehiculo);
            modelBuilder.Entity<Inventario>().HasRequired(x => x.Vehiculo);
            modelBuilder.Entity<Movimiento>().HasRequired(x => x.Vehiculo);
            modelBuilder.Entity<Movimiento>().HasRequired(x => x.Empleado);


        }

    }
}