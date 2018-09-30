using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Models
{
    public class Arquivo: Entity
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public TipoArquivo TipoArquivo { get; set; }

        public override bool EhValido()
        {
            throw new NotImplementedException();
        }
    }
}
