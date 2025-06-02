using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StormEyeApi.Models
{
    [Table("TGS_CATASTROFE_MAPEADA")]
    public class CatastrofeMapeada
    {
        [Key]
        [Column("IDCATASTROFEM")]
        public int IdCatastrofeM { get; set; }

        [Required]
        [Column("NOMECATASTROFEM")]
        public string NomeCatastrofeM { get; set; } = string.Empty;

        [Column("SINTOMACATASTROFEM")]
        public string? SintomaCatastrofeM { get; set; }

        [Column("ATIVO")]
        public bool Ativo { get; set; }

        public virtual ICollection<CartilhaMapeada> Cartilhas { get; set; } = new List<CartilhaMapeada>();
    }
}
