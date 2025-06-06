using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

using System;
using System.Collections.Generic;

namespace StormEye.Domain.Entities
{
    /// <summary>
    /// Representa a tabela TGS_CATASTROFE_MAPEADA no banco.
    /// </summary>
    public class CatastrofeMapeada
    {
        public int IdCatastrofeM { get; set; }
        public string NomeCatastrofeM { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string Localizacao { get; set; }
        public string Tipo { get; set; }
        public string Gravidade { get; set; }
        public bool Ativo { get; set; }

        public ICollection<CartilhaMapeada> Cartilhas { get; set; } = new List<CartilhaMapeada>();
    }
}
