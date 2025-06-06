using System;

namespace StormEyeWeb.Models
{
    public class CartilhaViewModel
    {
        public int IdCartilhaM { get; set; }
        public int IdCatastrofeM { get; set; }

        public string Nome { get; set; } = string.Empty;
        public string? Descricao { get; set; }
        public bool Ativo { get; set; }
    }
}
