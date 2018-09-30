using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.EntityConfig
{
    public class PessoaFisicaConfig: EntityTypeConfiguration<PessoaFisica>
    {
        public PessoaFisicaConfig()
        {
            HasKey(c => c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.Sobrenome)
                .IsRequired()
                .HasMaxLength(150);

            Property(c => c.RG)
                .HasMaxLength(9);

            Property(c => c.CPF)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength()
                .HasColumnAnnotation("Index", new IndexAnnotation(
                    new System.ComponentModel.DataAnnotations.Schema.IndexAttribute("IX_CPF") { IsUnique = true }));

            Property(c => c.Sexo)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.EstadoCivil)
                .IsRequired();

            Property(c => c.Naturalidade)
                .HasMaxLength(50);

            Property(c => c.Nacionalida)
                .HasMaxLength(50);

            Property(c => c.Profissao)
                .HasMaxLength(50);

            Property(c => c.Email)
                .HasMaxLength(100);

            //Relacionamneto
            //HasMany(p => p.PessoaFisica_Endereco)
            //    .WithRequired(c => c.PessoaFisica)
            //    .HasForeignKey(f => f.PessoaFisicaId);

            //HasMany(c => c.EnderecoList)
            //    .WithMany()
            //    .Map(me =>
            //    {
            //        me.MapLeftKey("PessoaFisicaId");
            //        me.MapRightKey("EnderecoId");
            //        me.ToTable("PessoaFisicaEndereco");
            //    });

            //Nome da tabela

            ToTable("Pessoas_Fisicas");
        }
    }
}
