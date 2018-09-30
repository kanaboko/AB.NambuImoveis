using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.EntityConfig
{
    public class PessoaConfig:EntityTypeConfiguration<Pessoa>
    {
        public PessoaConfig()
        {
            HasKey(p => p.Id);

            Property(p => p.DataCadastro)
                .IsRequired();

            //Relacionamento
            HasOptional(p => p.PessoaFisica)
               .WithRequired(p => p.Pessoa);
            HasOptional(p => p.PessoaJuridica)
                .WithRequired(p => p.Pessoa);


            ToTable("Pessoas");
               
        }
    }
}
