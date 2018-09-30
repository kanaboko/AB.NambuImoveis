using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Models
{
    public class ImovelDetalheTipo : Entity
    {
        public ImovelDetalheTipo()
        {
            ImovelDetalheBases = new List<ImovelDetalheBase>();
        }
        public string Descricao { get; set; }

        public virtual ICollection<ImovelDetalheBase> ImovelDetalheBases { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}
