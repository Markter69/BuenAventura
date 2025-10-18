using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using AppBuenaAventura.Models; 

namespace AppBuenaAventura.Contexto
{
    public class BuenaAventuraContext : DbContext
    {
        public BuenaAventuraContext(DbContextOptions<BuenaAventuraContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Si más adelante agregas vistas o relaciones especiales, se configuran aquí.
        }

        // Tablas principales
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Agencia> Agencias { get; set; }
        public DbSet<AgenteViaje> AgentesViaje { get; set; }
        public DbSet<Hotel> Hoteles { get; set; }
        public DbSet<Presupuesto> Presupuestos { get; set; }
        public DbSet<Reseñas> Reseñas { get; set; }
    }
}
