using AB.NambuImoveis.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Models
{
    public class ImovelFinalidade: Entity
    {
        public ImovelFinalidade()
        {
            ImovelTipos = new List<ImovelTipo>();
        }
        public Enum_ImovelFinalidade Descricao { get; set; }

        public virtual ICollection<ImovelTipo> ImovelTipos { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}
