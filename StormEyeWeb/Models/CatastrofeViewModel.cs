using StormEyeApi.Models;
using System;
using System.Collections.Generic;

namespace StormEye.Web.Models
{
    public class CatastrofeViewModel
    {
        public int IdCatastrofeM { get; set; }
        public string NomeCatastrofeM { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public string Tipo { get; set; }
        public string Gravidade { get; set; }
        public bool Ativo { get; set; }

        public List<CartilhaViewModel> Cartilhas { get; set; } = new();
    }
}
