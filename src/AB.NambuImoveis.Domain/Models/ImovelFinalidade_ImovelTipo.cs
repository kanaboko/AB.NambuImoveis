using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Models
{
    public class ImovelFinalidade_ImovelTipo
    {
        public Guid ImovelFinalidadeId { get; set; }
        public Guid ImovelTipoId { get; set; }

        public virtual ImovelFinalidade ImovelFinalidade { get; set; }
        public virtual ImovelTipo ImovelTipo { get; set; }

    }
}
