using AB.NambuImoveis.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.ViewModels
{
    public class ImovelViewModel
    {
        public ImovelViewModel()
        {
            Id = Guid.NewGuid();
        }
        //Proprietários

        //Estrutura
        public string Finalidade { get; set; }
        public string Tipo { get; set; }

        //Endereco

        //Dados

        //public Guid UsuarioId { get; set; }
        //public string UsuarioNome { get; set; }
        public Guid Id { get; set; }
        public string ReferenciaAutomatica { get; set; }
        public string ReferenciaAlternativa { get; set; }
        public bool PretencaoVenda { get; set; }
        public bool PretencaoLocacao { get; set; }
        public string NumeroIptu { get; set; }
        public decimal ValorIptu { get; set; }
        public CondicaoIptu CondicaoIptu { get; set; }
        public Permuta Permuta { get; set; }
        public PadraoImovel PadraoImovel { get; set; }
        public PadraoLocalizacao PadraoLocalizacao { get; set; }
        public SituacaoImovel SituacaoImovel { get; set; }
        public TipoLocacao TipoLocacao { get; set; }

        public string Zoneamento { get; set; }
        public bool Exclusividade { get; set; }
        public DateTime AnoConstrucao { get; set; }
        public DateTime AnoReforma { get; set; }
        public bool FgtsUltimos3Anos { get; set; }
        public bool AceitaFinanciamento { get; set; }
        public bool Vender { get; set; }
        public bool Locar { get; set; }
        public decimal ValorVenda { get; set; }
        public decimal ValorVendaAvaliado { get; set; }
        public decimal ValorLocacao { get; set; }
        public decimal ValorLocacaoAvaliado { get; set; }
        public decimal ValorCondominio { get; set; }

        public Enum_ImovelStatus ImovelStatus { get; set; }

        public bool Ativo { get; set; }
        public bool Excluido { get; set; }

        public virtual ICollection<ProprietarioViewModel> Proprietarios { get; set; }
        public virtual ICollection<ImovelDetalheBaseValorViewModel> ImovelDetalheBaseValores { get; set; }
        public virtual EnderecoViewModel Endereco { get; set; }
    }
}
