using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.EntityConfig
{
    public class PessoaFisica_EnderecoConfig: EntityTypeConfiguration<PessoaFisica_Endereco>
    {
        public PessoaFisica_EnderecoConfig()
        {
            HasKey(ck => new { ck.PessoaFisicaId, ck.EnderecoId });

            HasRequired(p => p.PessoaFisica)
                .WithMany()
                .HasForeignKey(p => p.PessoaFisicaId);
            HasRequired(p => p.Endereco)
                .WithMany()
                .HasForeignKey(p => p.EnderecoId);

            ToTable("PessoaFisicas_Enderecos");
        }

    }
}
