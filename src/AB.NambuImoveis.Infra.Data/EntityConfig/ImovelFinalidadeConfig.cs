using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.EntityConfig
{
    public class ImovelFinalidadeConfig: EntityTypeConfiguration<ImovelFinalidade>
    {
        public ImovelFinalidadeConfig()
        {
            HasKey(k => k.Id);
            Property(p=>p.Descricao)
                .IsRequired();
                
        }
    }
}
