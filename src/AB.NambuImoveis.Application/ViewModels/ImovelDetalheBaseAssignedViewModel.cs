using AB.NambuImoveis.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.ViewModels
{
    public class ImovelDetalheBaseAssignedViewModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public TipoDadosViewModel TipoDados { get; set; }        
        public bool Selecionado { get; set; }
    }
}
