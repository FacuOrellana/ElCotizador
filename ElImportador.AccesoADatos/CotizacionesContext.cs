using ElImportador.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElImportador.AccesoADatos
{
    public class CotizacionesContext : DbContext
    {
        public CotizacionesContext() : base("name=CotizacionesConnection")
        {

        }

        public DbSet<Producto> Productos{get;set;}
        public DbSet<Marca> Marcas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder.
                Entity<Producto>().
                HasKey(p => p.Id).
                ToTable("Productos");
              
                
            modelBuilder.
                Entity<Marca>().                
                ToTable("Marcas");                
               
            base.OnModelCreating(modelBuilder);
        }

    }
}
