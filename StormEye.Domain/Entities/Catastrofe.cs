using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace StormEye.Domain.Entities
{
    public class Catastrofe
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }

        public ICollection<CatastrofeCartilha> CatastrofeCartilhas { get; set; } 
            = new List<CatastrofeCartilha>();
    }
}
