using System;
using System.Collections.Generic;

namespace StormEyeWeb.Models
{
    public class CatastrofeViewModel
    {
        public int Id { get; set; }

        public string NomeCatastrofeM { get; set; } = string.Empty;
        public DateTime Data { get; set; }

        public List<CartilhaViewModel> Cartilhas { get; set; } = new();
    }
}
