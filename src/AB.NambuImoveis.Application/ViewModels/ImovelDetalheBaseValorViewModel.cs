using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.ViewModels
{
    public class ImovelDetalheBaseValorViewModel
    {
        public ImovelDetalheBaseValorViewModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid ImovelId { get; set; }
        public Guid ImovelDetalheBaseId { get; set; }
        public string Valor { get; set; }

        public virtual ImovelViewModel Imovel { get; set; }
    }
}
