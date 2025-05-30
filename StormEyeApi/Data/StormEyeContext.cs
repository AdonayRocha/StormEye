using Microsoft.EntityFrameworkCore;
using StormEyeApi.Models;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace StormEyeApi.Data
{
    public class StormEyeContext : DbContext
    {
        public StormEyeContext(DbContextOptions<StormEyeContext> options)
        : base(options) { }

        public DbSet<CatastrofeMapeada> Catastrofes { get; set; }
        public DbSet<CartilhaMapeada> Cartilhas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatastrofeMapeada>()
                .HasMany(c => c.Cartilhas)
                .WithOne(c => c.CatastrofeMapeada)
                .HasForeignKey(c => c.IdCatastrofeM);
        }
    }
}
