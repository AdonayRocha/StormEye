using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace StormEye.Domain.Entities
{
    public class Cartilha
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }

        public ICollection<CatastrofeCartilha> CatastrofeCartilhas { get; set; }
            = new List<CatastrofeCartilha>();
    }
}

