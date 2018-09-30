using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Models
{
    public class Proprietario : Entity
    {
        public DateTime DataCadastro { get; set; }
        //public string MidiaOrigem { get; set; }
        //public string AtividadesPorEmail { get; set; }

        public virtual Pessoa Pessoa { get; set; }

        public override bool EhValido()
        {            
            return true;
        }
    }
}
