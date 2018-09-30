using AB.NambuImoveis.Domain.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Models
{
    public class PessoaFisica : Entity
    {
        public PessoaFisica()
        {
            EnderecoList = new List<Endereco>();
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string RG { get; set; }
        public string CPF { get; set; }
        public string Sexo { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public string Naturalidade { get; set; }
        public string Nacionalida { get; set; }
        public string Profissao { get; set; }
        public string Email { get; set; }
        public decimal Renda { get; set; }
        public bool Ativo { get; private set; }
        public bool Excluido { get; private set; }
        public DateTime DataNascimento { get; set; }
        
        public virtual Pessoa Pessoa { get; set; }
        public ICollection<Endereco> EnderecoList { get; set; }


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
