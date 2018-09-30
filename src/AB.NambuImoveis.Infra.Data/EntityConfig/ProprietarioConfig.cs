using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.EntityConfig
{
    public class ProprietarioConfig: EntityTypeConfiguration<Proprietario>
    {
        public ProprietarioConfig()
        {
            HasKey(k => k.Id);
            Property(p => p.DataCadastro)
                .IsRequired();

            HasRequired(p => p.Pessoa)
                .WithRequiredPrincipal();

            ToTable("Proprietarios");
        }
    }
}
