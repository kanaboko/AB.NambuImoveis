using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.ViewModels
{
    public class EnderecoViewModel
    {
        public EnderecoViewModel()
        {
            Id = Guid.NewGuid();
        }
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Preencha o campo Logradouro")]
        [MaxLength(150, ErrorMessage = "Máximo permitido 150 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo permitido 2 caracteres")]
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "Preencha o campo Endereço")]
        public string Numero { get; set; }
        public string Complemento { get; set; }
        [Required(ErrorMessage = "Preencha o campo Bairro")]
        [MaxLength(50, ErrorMessage = "Máximo permitido 50 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo permitido 2 caracteres")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Preencha o campo Cidade")]
        [MaxLength(50, ErrorMessage = "Máximo permitido 50 caracteres")]
        [MinLength(2, ErrorMessage = "Minimo permitido 2 caracteres")]
        public string Cidade { get; set; }

        public string Estado { get; set; }
        public string CEP { get; set; }

    }
}
