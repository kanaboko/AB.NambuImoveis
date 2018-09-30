using AB.NambuImoveis.Infra.CrossCutting.MvcFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AB.NambuImoveis.Application.ViewModels
{
    public class ClienteViewModel
    {
        public PessoaViewModel Pessoa { get; set; }
        public PessoaFisicaViewModel PessoaFisica { get; set; }
        public PessoaJuridicaViewModel PessoaJuridica { get; set; }
        public EnderecoViewModel Endereco { get; set; }

        [FileSize(102400000)]
        [FileTypes("jpg,jpeg,png,pdf,xdoc,rtf")]
        public List<HttpPostedFileBase> Foto { get; set; }
        public List<string> Foto2 { get; set; }
    }
}
