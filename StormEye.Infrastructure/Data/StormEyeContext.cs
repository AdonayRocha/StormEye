using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using StormEye.Domain.Entities;

namespace StormEye.Infrastructure.Data
{
    public class StormEyeContext : DbContext
    {
        public StormEyeContext(DbContextOptions<StormEyeContext> options)
            : base(options)
        { }

        // Cada DbSet equivale a uma tabela no banco
        public DbSet<Catastrofe> Catastrofes { get; set; }
        public DbSet<Cartilha> Cartilhas { get; set; }
        public DbSet<CatastrofeCartilha> CatastrofeCartilhas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CatastrofeCartilha>()
                .HasKey(cc => new { cc.CatastrofeId, cc.CartilhaId });

            modelBuilder.Entity<CatastrofeCartilha>()
                .HasOne(cc => cc.Catastrofe)
                .WithMany(c => c.CatastrofeCartilhas)
                .HasForeignKey(cc => cc.CatastrofeId);

            modelBuilder.Entity<CatastrofeCartilha>()
                .HasOne(cc => cc.Cartilha)
                .WithMany(c => c.CatastrofeCartilhas)
                .HasForeignKey(cc => cc.CartilhaId);
        }
    }
}
