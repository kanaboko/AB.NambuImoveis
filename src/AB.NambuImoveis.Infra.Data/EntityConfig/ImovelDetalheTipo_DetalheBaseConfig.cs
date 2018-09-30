using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.EntityConfig
{
    public class ImovelDetalheTipo_DetalheBaseConfig: EntityTypeConfiguration<ImovelDetalheTipo_DetalheBase>
    {
        public ImovelDetalheTipo_DetalheBaseConfig()
        {
            HasKey(ck => new { ck.ImovelDetalheTipoId, ck.ImovelDetalheBaseId });
           
            HasRequired(p => p.ImovelDetalheTipo)
                .WithMany()
                .HasForeignKey(p => p.ImovelDetalheTipoId);
            HasRequired(p => p.ImovelDetalheBase)
                .WithMany()
                .HasForeignKey(p => p.ImovelDetalheBaseId);
        }
    }
}
