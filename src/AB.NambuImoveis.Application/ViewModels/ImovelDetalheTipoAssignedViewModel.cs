﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.ViewModels
{
    public class ImovelDetalheTipoAssignedViewModel
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool Selecionado { get; set; }

        public virtual ICollection<ImovelDetalheBaseAssignedViewModel> ImovelDetalheBases { get; set; }
    }
}
