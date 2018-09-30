using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.EntityConfig
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(e => e.Id);

            Property(e => e.Logradouro)
                .IsRequired()
                .HasMaxLength(150);

            Property(e => e.Numero)
                .IsRequired()
                .HasMaxLength(10);

            Property(e => e.Complemento)
                .HasMaxLength(50);

            Property(e => e.Bairro)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Cidade)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.Estado)
                .IsRequired()
                .HasMaxLength(50);

            Property(e => e.CEP)
               .HasMaxLength(8)
               .IsFixedLength();

            //Relacionamentos
            //One to One or Zero
            //One to One
            //One to Many or Zero
            //One to Many
            //Many to Many
            
            

            ToTable("Enderecos");


        }
    }
}
