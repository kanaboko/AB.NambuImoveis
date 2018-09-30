using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.EntityConfig
{
    public class PessoaJuridica_EnderecoConfig: EntityTypeConfiguration<PessoaJuridica_Endereco>
    {
        public PessoaJuridica_EnderecoConfig()
        {
            HasKey(k => new { k.PessoaJuridicaId, k.EnderecoId });

            HasRequired(p => p.PessoaJuridica)
                .WithMany()
                .HasForeignKey(p => p.PessoaJuridicaId);
            HasRequired(p => p.Endereco)
                .WithMany()
                .HasForeignKey(p => p.EnderecoId);

            ToTable("PessoaJuridicas_Enderecos");
        }
    }
}
