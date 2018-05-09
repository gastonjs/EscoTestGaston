using EscoTestGaston.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EscoTestGaston.DAL
{
    public class EscoTestGastonContext : DbContext
    {
        public EscoTestGastonContext() : base("EscoTestGastonContext")
        {

        }

        public DbSet<Propietario> Propietarios { get; set; }
        public DbSet<Auto> Autos { get; set; }
        public DbSet<Servicio> Servicios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}