using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Models
{
    public class ImovelTipo_DetalheTipo_DetalheBase
    {
        public Guid ImovelTipoId { get; set; }
        public Guid ImovelDetalheTipoId { get; set; }
        public Guid ImovelDetalheBaseId { get; set; }

        public virtual ImovelTipo ImovelTipo { get; set; }
        public virtual ImovelDetalheTipo ImovelDetalheTipo { get; set; }
        public virtual ImovelDetalheBase ImovelDetalheBase { get; set; }
    }
}
