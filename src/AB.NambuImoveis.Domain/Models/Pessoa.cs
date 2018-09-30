using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Models
{
    public class Pessoa : Entity
    {
        public Pessoa()
        {
            
        }

        public DateTime DataCadastro { get; set; }
        public TipoPessoa TipoPessoa { get; set; }
        public bool Ativo { get; private set; }
        public bool Excluido { get; private set; }

        public virtual PessoaFisica PessoaFisica { get; set; }
        public virtual PessoaJuridica PessoaJuridica { get; set; }
        
        
        public void Excluir()
        {
            Ativo = false;
            Excluido = true;
        }

        public void Ativar()
        {
            Ativo = true;
            Excluido = false;
        }

        public override bool EhValido()
        {
            return true;
        }
    }
}
