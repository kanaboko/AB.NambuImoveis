using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Models
{
    public class PessoaFisica_Endereco
    {
        public Guid PessoaFisicaId { get; set; }
        public Guid EnderecoId { get; set; }

        public virtual PessoaFisica PessoaFisica { get; set; }
        public virtual Endereco Endereco { get; set; }
        
    }
}
