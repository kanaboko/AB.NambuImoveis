using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Models
{
    public class PessoaJuridica_Endereco
    {
        public Guid PessoaJuridicaId { get; set; }
        public Guid EnderecoId { get; set; }

        public virtual PessoaJuridica PessoaJuridica { get; set; }
        public virtual Endereco Endereco { get; set; }
    }
}
