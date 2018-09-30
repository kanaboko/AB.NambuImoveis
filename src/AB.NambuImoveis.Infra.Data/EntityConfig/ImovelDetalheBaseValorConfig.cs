using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.EntityConfig
{
    public class ImovelDetalheBaseValorConfig: EntityTypeConfiguration<ImovelDetalheBaseValor>
    {
        public ImovelDetalheBaseValorConfig()
        {
            HasKey(k => k.Id);
            Property(p => p.Valor)
                .IsRequired()
                .HasMaxLength(100);           
            HasRequired(p => p.Imovel)
                .WithMany()
                .HasForeignKey(p => p.ImovelId);                
        }
    }
}
