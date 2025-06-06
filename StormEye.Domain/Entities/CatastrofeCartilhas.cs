using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StormEye.Domain.Entities
{
    public class CatastrofeCartilhas
    {
        public int CatastrofeId { get; set; }
        public CatastrofeMapeada Catastrofe { get; set; }

        public int CartilhaId { get; set; }
        public CartilhaMapeada Cartilha { get; set; }
    }
}

