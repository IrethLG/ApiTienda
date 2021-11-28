using ApiTienda.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTienda.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }

        public DbSet<Producto> Producto { get; set; }
        public DbSet<Venta> Venta { get; set; }

        //N:M
        public DbSet<ProductoVenta> ProductoVenta { get; set; }
        public DbSet<ProductoProveedor> ProductoProveedor { get; set; }


    }
}
