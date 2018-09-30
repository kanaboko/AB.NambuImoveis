using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.ViewModels
{
    public class PessoaJuridicaViewModel
    {
        public PessoaJuridicaViewModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Preencha o campo Razão Social")]
        [MaxLength(150, ErrorMessage = "Máximo permitido 150 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo permitido 2 caracteres")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Preencha o campo CNPJ")]
        [MaxLength(14, ErrorMessage = "Máximo permitido 14 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo permitido 2 caracteres")]
        public string CNPJ { get; set; }

        [MaxLength(9, ErrorMessage = "Máximo permitido 9 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo permitido 2 caracteres")]
        public string IE { get; set; }
        [ScaffoldColumn(false)]
        public bool Ativo { get; private set; }
        [ScaffoldColumn(false)]
        public bool Excluido { get; private set; }
        [ScaffoldColumn(false)]
        public Guid PessoaId { get; set; }

        public PessoaViewModel Pessoa { get; set; }
        public IEnumerable<EnderecoViewModel> EnderecoList { get; set; }
    }
}
