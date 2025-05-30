using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StormEyeApi.Models
{
    public class CartilhaMapeada
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeCatastrofeM { get; set; }

        public string? SintomaCatastrofeM { get; set; }

        public bool Ativo { get; set; }

        [ForeignKey("CatastrofeMapeada")]
        public int IdCatastrofeM { get; set; }

        public CatastrofeMapeada? CatastrofeMapeada { get; set; }
    }
}
