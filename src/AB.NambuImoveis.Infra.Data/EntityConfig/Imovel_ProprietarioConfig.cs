using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.EntityConfig
{
    public class Imovel_ProprietarioConfig: EntityTypeConfiguration<Imovel_Proprietario>
    {
        public Imovel_ProprietarioConfig()
        {
            HasKey(ck => new { ck.ImovelId, ck.ProprietarioId });

            HasRequired(p => p.Imovel)
                .WithMany()
                .HasForeignKey(fk => fk.ImovelId);
            HasRequired(p => p.Proprietario)
                .WithMany()
                .HasForeignKey(fk => fk.ProprietarioId);
        }
    }
}
