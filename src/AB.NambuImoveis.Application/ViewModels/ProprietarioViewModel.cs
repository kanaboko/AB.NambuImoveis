using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.ViewModels
{
    public class ProprietarioViewModel
    {
        public ProprietarioViewModel()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        //public string MidiaOrigem { get; set; }
        //public string AtividadesPorEmail { get; set; }

        public virtual PessoaViewModel Pessoa { get; set; }
    }
}
