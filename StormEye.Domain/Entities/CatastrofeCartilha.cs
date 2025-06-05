using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StormEye.Domain.Entities
{
    public class CatastrofeCartilha
    {
        public int CatastrofeId { get; set; }
        public Catastrofe Catastrofe { get; set; }

        public int CartilhaId { get; set; }
        public Cartilha Cartilha { get; set; }
    }
}

