using Microsoft.EntityFrameworkCore;
using StormEyeApi.Models;

namespace StormEyeApi.Data
{
    public class StormEyeContext : DbContext
    {
        public DbSet<CatastrofeMapeada> Catastrofes { get; set; }
        public DbSet<CartilhaMapeada> Cartilhas { get; set; }

        public StormEyeContext(DbContextOptions<StormEyeContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CatastrofeMapeada>(entity =>
            {
                entity.ToTable("TGS_CATASTROFE_MAPEADA");
                entity.HasKey(e => e.IdCatastrofeM);
                entity.Property(e => e.IdCatastrofeM).HasColumnName("IDCATASTROFEM");
                entity.Property(e => e.NomeCatastrofeM).HasColumnName("NOMECATASTROFEM");
                entity.Property(e => e.SintomaCatastrofeM).HasColumnName("SINTOMACATASTROFEM");
                entity.Property(e => e.Ativo)
                    .HasColumnName("ATIVO")
                    .HasColumnType("NUMBER(1)")
                    .HasConversion(v => v ? 1 : 0, v => v == 1);
            });

            modelBuilder.Entity<CartilhaMapeada>(entity =>
            {
                entity.ToTable("TGS_CARTILHA_MAPEADA");
                entity.HasKey(e => e.IdCartilhaM);
                entity.Property(e => e.IdCartilhaM).HasColumnName("IDCARTILHAM");
                entity.Property(e => e.IdCatastrofeM).HasColumnName("IDCATASTROFEM");
                entity.Property(e => e.Nome).HasColumnName("NOMECARTILHAM");
                entity.Property(e => e.Descricao).HasColumnName("DESCRICAOCARTILHA");
                entity.Property(e => e.Ativo)
                    .HasColumnName("ATIVO")
                    .HasColumnType("NUMBER(1)")
                    .HasConversion(v => v ? 1 : 0, v => v == 1);

                entity.HasOne(e => e.Catastrofe)
                    .WithMany(c => c.Cartilhas)
                    .HasForeignKey(e => e.IdCatastrofeM);
            });
        }
    }
}
