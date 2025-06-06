using StormEye.Web.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StormEyeApi.Models
{
    [Table("TGS_CARTILHA_MAPEADA")]
    public class CartilhaViewModel
    {
        [Key]
        [Column("IDCARTILHAM")]
        public int IdCartilhaM { get; set; }

        [Column("IDCATASTROFEM")]
        public int IdCatastrofeM { get; set; } 

        [Column("NOMECARTILHAM")]
        public string Nome { get; set; } = string.Empty;

        [Column("DESCRICAOCARTILHA")]
        public string? Descricao { get; set; }

        [Column("ATIVO")]
        public bool Ativo { get; set; }

        public virtual CatastrofeViewModel Catastrofe { get; set; }
    }
}
