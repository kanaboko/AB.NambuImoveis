using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Models
{
    public class ImovelDetalheTipo_DetalheBase
    {
        public Guid ImovelDetalheTipoId { get; set; }
        public Guid ImovelDetalheBaseId { get; set; }

        public virtual ImovelDetalheTipo ImovelDetalheTipo { get; set; }
        public virtual ImovelDetalheBase ImovelDetalheBase { get; set; }
    }
}
