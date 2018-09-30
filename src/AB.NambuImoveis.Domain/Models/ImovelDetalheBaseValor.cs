using System;

namespace AB.NambuImoveis.Domain.Models
{
    public class ImovelDetalheBaseValor: Entity
    {
        public Guid ImovelId { get; set; }
        public Guid ImovelDetalheBaseId { get; set; }
        public string Valor { get; set; }

        public virtual Imovel Imovel { get; set; }

        public override bool EhValido()
        {
            return true;
        }
    }
}