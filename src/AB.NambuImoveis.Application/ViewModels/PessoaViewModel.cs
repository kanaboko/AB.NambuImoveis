using AB.NambuImoveis.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.ViewModels
{
    public class PessoaViewModel
    {
        public PessoaViewModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        [Required]
        [EnumDataType(typeof(TipoPessoaViewModel))]
        public TipoPessoaViewModel TipoPessoa { get; set; }
        [ScaffoldColumn(false)]
        public bool Ativo { get; set; }
        [ScaffoldColumn(false)]
        public bool Excluido { get; set; }
        

        public PessoaFisicaViewModel PessoaFisica { get; set; }
        public PessoaJuridicaViewModel PessoaJuridica { get; set; }
    }
}
