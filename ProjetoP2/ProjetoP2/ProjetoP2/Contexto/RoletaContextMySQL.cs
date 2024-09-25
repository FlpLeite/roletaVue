using Microsoft.EntityFrameworkCore;
using ProjetoP2.Models;
using System.Collections.Generic;

namespace ProjetoP2.Contexto
{
    public class RoletaContextMySQL : DbContext
    {
        public RoletaContextMySQL(DbContextOptions<RoletaContextMySQL> context) : base(context)
        {
        }

        public DbSet<Premio> Premios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().ToTable("Usuarios");
            modelBuilder.Entity<Premio>().ToTable("Premios");
        }
    }
}