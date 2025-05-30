using Microsoft.EntityFrameworkCore;
using StormEyeApi.Models;

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
            modelBuilder.Entity<CatastrofeMapeada>().ToTable("TGS_CATASTROFE_MAPEADA");
            modelBuilder.Entity<CartilhaMapeada>().ToTable("TGS_CARTILHA_MAPEADA");

            // Relacionamento 1:N
            modelBuilder.Entity<CatastrofeMapeada>()
                .HasMany(c => c.Cartilhas)
                .WithOne(c => c.CatastrofeMapeada)
                .HasForeignKey(c => c.IdCatastrofeM);
        }
    }
}
