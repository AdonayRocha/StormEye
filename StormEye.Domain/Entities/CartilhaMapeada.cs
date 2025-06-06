using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

using System.Collections.Generic;

namespace StormEye.Domain.Entities
{
    /// <summary>
    /// Representa a tabela TGS_CARTILHA_MAPEADA no banco.
    /// Cada CartilhaMapeada pode estar associada a várias CatastrofeMapeada,
    /// dependendo se você quiser modelar N:N (por exemplo, através de entidade de junção),
    /// mas no diagrama de exemplo do professor há apenas 1:N (Cartilha → Catastrofe).
    /// </summary>
    public class CartilhaMapeada
    {
        public int IdCartilhaM { get; set; }
        public int IdCatastrofeM { get; set; }       // FK 
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public bool Ativo { get; set; }

        public CatastrofeMapeada Catastrofe { get; set; }
    }
}
