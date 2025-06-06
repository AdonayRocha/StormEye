using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using StormEye.Domain.Entities;

using Microsoft.EntityFrameworkCore;
using StormEye.Domain.Entities;

namespace StormEye.Infrastructure.Data
{
    public class StormEyeContext : DbContext
    {
        public StormEyeContext(DbContextOptions<StormEyeContext> options)
            : base(options)
        {
        }

        // Cada DbSet reflete uma tabela no banco
        public DbSet<CatastrofeMapeada> Catastrofes { get; set; }
        public DbSet<CartilhaMapeada> Cartilhas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CatastrofeMapeada>(entity =>
            {
                entity.ToTable("TGS_CATASTROFE_MAPEADA");
                entity.HasKey(e => e.IdCatastrofeM);
                entity.Property(e => e.IdCatastrofeM).HasColumnName("IDCATASTROFEM");
                entity.Property(e => e.NomeCatastrofeM).HasColumnName("NOMECATASTROFEM");
                entity.Property(e => e.Data).HasColumnName("DATA");
                entity.Property(e => e.Descricao).HasColumnName("DESCRICAO");
                entity.Property(e => e.Localizacao).HasColumnName("LOCALIZACAO");
                entity.Property(e => e.Tipo).HasColumnName("TIPO");
                entity.Property(e => e.Gravidade).HasColumnName("GRAVIDADE");
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
                entity.Property(e => e.Categoria).HasColumnName("CATEGORIACARTILHA");
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
