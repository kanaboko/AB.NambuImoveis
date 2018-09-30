using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.EntityConfig
{
    public class ImovelFinalidade_ImovelTipoConfig: EntityTypeConfiguration<ImovelFinalidade_ImovelTipo>
    {
        public ImovelFinalidade_ImovelTipoConfig()
        {
            HasKey(ck => new { ck.ImovelFinalidadeId, ck.ImovelTipoId });

            HasRequired(p => p.ImovelFinalidade)
                .WithMany()
                .HasForeignKey(fk => fk.ImovelFinalidadeId);
            
            HasRequired(p => p.ImovelTipo)
                .WithMany()
                .HasForeignKey(fk => fk.ImovelTipoId);
        }
    }
}
