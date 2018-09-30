using AB.NambuImoveis.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Models
{
    public class ImovelDetalheBase: Entity
    {
        public string Descricao { get; set; }
        public TipoDados TipoDados { get; set; }

        public ICollection<ImovelDetalheBaseValor> Valores { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}
