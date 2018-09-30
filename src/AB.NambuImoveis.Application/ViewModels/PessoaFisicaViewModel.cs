using AB.NambuImoveis.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.ViewModels
{
    public class PessoaFisicaViewModel
    {
        public PessoaFisicaViewModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage ="Preencha o campo Nome")]
        [MaxLength(150,ErrorMessage ="Máximo permitido 150 caracteres")]
        [MinLength(2,ErrorMessage ="Minimo permitido 2 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Preencha o campo Sobrenome")]
        [MaxLength(150, ErrorMessage = "Máximo permitido 150 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo permitido 2 caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "Preencha o campo RG")]
        [MaxLength(9, ErrorMessage = "Máximo permitido 9 caracteres")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Preencha o campo Nome")]
        [MaxLength(11, ErrorMessage = "Máximo permitido 11 caracteres")]
        public string CPF { get; set; }

        public string Sexo { get; set; }

        [Required(ErrorMessage ="Preencha o campo Estado Civil")]
        [DisplayName("Estado Civil")]
        [EnumDataType(typeof(EstadoCivilViewModel))]
        public EstadoCivilViewModel EstadoCivil { get; set; }
   
        public string Naturalidade { get; set; }

        [Required(ErrorMessage ="Preencha o campo Nacionalidade")]
        public string Nacionalida { get; set; }

        [Required(ErrorMessage = "Preencha o campo Profissão")]
        [MaxLength(50, ErrorMessage = "Máximo permitido 50 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo permitido 2 caracteres")]
        public string Profissao { get; set; }

        [Required(ErrorMessage = "Preencha o campo E-Mail")]
        [MaxLength(150, ErrorMessage = "Máximo permitido 150 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo permitido 2 caracteres")]
        [EmailAddress(ErrorMessage ="Preencha um E-Mail válido")]
        [DisplayName("E-Mail")]
        public string Email { get; set; }

        [DataType(DataType.Currency)]
        public decimal Renda { get; set; }

        [ScaffoldColumn(false)]
        public bool Ativo { get; private set; }

        [ScaffoldColumn(false)]
        public bool Excluido { get; private set; }

        [DisplayName("Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-mm-yyyy}")]
        public DateTime DataNascimento { get; set; }

        public PessoaViewModel Pessoa { get; set; }         
        public IEnumerable<EnderecoViewModel> EnderecoList { get; set; }


    }
}
