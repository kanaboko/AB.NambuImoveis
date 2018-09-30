using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Models
{
    public class Imovel_Proprietario
    {
        public Guid ImovelId { get; set; }
        public Guid ProprietarioId { get; set; }

        public virtual Imovel Imovel { get; set; }
        public virtual Proprietario Proprietario { get; set; }
    }
}
