using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.EntityConfig
{
    public class ImovelTipo_DetalheTipo_DetalheBaseConfig: EntityTypeConfiguration<ImovelTipo_DetalheTipo_DetalheBase>
    {
        public ImovelTipo_DetalheTipo_DetalheBaseConfig()
        {
            HasKey(ck => new { ck.ImovelTipoId, ck.ImovelDetalheTipoId, ck.ImovelDetalheBaseId });

            HasRequired(p => p.ImovelTipo)
                .WithMany()
                .HasForeignKey(p => p.ImovelTipoId);
            HasRequired(p => p.ImovelDetalheTipo)
                .WithMany()
                .HasForeignKey(p => p.ImovelDetalheTipoId);
            HasRequired(p => p.ImovelDetalheBase)
                .WithMany()
                .HasForeignKey(p => p.ImovelDetalheBaseId);
        }
    }
}
