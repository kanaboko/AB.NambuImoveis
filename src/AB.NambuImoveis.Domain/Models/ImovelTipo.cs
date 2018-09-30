using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Models
{
    public class ImovelTipo : Entity
    {
        public ImovelTipo()
        {
            ImovelDetalheTipos = new List<ImovelDetalheTipo>();
        }
        public string Descricao { get; set; }

        public virtual ICollection<ImovelDetalheTipo> ImovelDetalheTipos { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}
