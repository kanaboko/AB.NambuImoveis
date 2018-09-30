using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Models
{
    public class PessoaJuridica: Entity
    {
        public PessoaJuridica()
        {
            EnderecoList = new List<Endereco>();
        }

        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string IE { get; set; }
        public bool Ativo { get; private set; }
        public bool Excluido { get; private set; }       

        public virtual Pessoa Pessoa { get; set; }
        public virtual ICollection<Endereco> EnderecoList { get; set; }
        

        public void AdicionarEndereco(Endereco endereco)
        {
            if (!endereco.EhValido())
            {
                return;
            }
            EnderecoList.Add(endereco);
        }

        //public void Excluir()
        //{
        //    Ativo = false;
        //    Excluido = true;
        //}

        //public void Ativar()
        //{
        //    Ativo = true;
        //    Excluido = false;
        //}


        public override bool EhValido()
        {
            return true;
        }
    }
}
