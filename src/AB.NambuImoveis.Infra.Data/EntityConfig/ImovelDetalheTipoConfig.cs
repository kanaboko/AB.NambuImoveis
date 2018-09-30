using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.EntityConfig
{
    public class ImovelDetalheTipoConfig: EntityTypeConfiguration<ImovelDetalheTipo>
    {
        public ImovelDetalheTipoConfig()
        {
            HasKey(k => k.Id);
            Property(p => p.Descricao)
                .IsRequired()
                .HasMaxLength(100);
            //HasMany(p => p.ImovelDetalheBases)
            //    .WithMany()
            //    .Map(me =>
            //    {
            //        me.MapLeftKey("ImovelDetalheTipoId");
            //        me.MapRightKey("ImovelDetalheBaseId");
            //        me.ToTable("ImovelDetalheTipo_Base");
            //    });

        }
    }
}
