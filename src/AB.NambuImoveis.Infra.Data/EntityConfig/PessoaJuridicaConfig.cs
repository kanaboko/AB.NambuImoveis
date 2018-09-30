using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.EntityConfig
{
    public class PessoaJuridicaConfig:EntityTypeConfiguration<PessoaJuridica>
    {
        public PessoaJuridicaConfig()
        {
            HasKey(j => j.Id);

            Property(p => p.CNPJ)
                .IsRequired()
                .HasMaxLength(14)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute("IX_CNPJ"){ IsUnique = true}));

            Property(p => p.IE)
                .HasMaxLength(12);

            Property(p => p.RazaoSocial)
                .HasMaxLength(150);

            //Relacionamnetos            

            //HasMany(f => f.EnderecoList)
            //    .WithMany()
            //    .Map(me =>
            //    {
            //        me.MapLeftKey("PessoaJuridicaId");
            //        me.MapRightKey("EnderecoId");
            //        me.ToTable("PessoaJuridicaEndereco");
            //    });

            //Nome da Tabela

            ToTable("Pessoas_Juridicas");

        }
    }
}
