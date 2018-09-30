using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.EntityConfig
{
    public class ImovelConfig: EntityTypeConfiguration<Imovel>
    {
        public ImovelConfig()
        {
            HasKey(k => k.Id);

            HasRequired(p => p.Endereco)
                .WithRequiredPrincipal();
           
        }
    }
}
