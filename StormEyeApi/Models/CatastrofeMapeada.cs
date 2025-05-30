using System.ComponentModel.DataAnnotations;

namespace StormEyeApi.Models
{
    public class CatastrofeMapeada
    {
        [Key]
        public int IdCatastrofeM { get; set; }

        [Required]
        public string NomeCatastrofeM { get; set; }

        public string? SintomaCatastrofeM { get; set; }

        public bool AtivoM { get; set; }

        public ICollection<CartilhaMapeada>? Cartilhas { get; set; }
    }
}
