using AB.NambuImoveis.Domain.Models;
using AB.NambuImoveis.Infra.Data.EntityConfig;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.Context
{
    public class NambuImoveisContext : DbContext
    {
        public NambuImoveisContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = false;
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaFisica> PessoaFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridicas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<PessoaFisica_Endereco> PessoaFisica_Enderecos { get; set; }
        public DbSet<PessoaJuridica_Endereco> PessoaJuridica_Enderecos { get; set; }
        public DbSet<ImovelDetalheBase> ImovelDetalheBases { get; set; }
        public DbSet<ImovelDetalheTipo> ImovelDetalheTipos { get; set; }
        public DbSet<ImovelTipo> ImovelTipos { get; set; }
        public DbSet<ImovelFinalidade> ImovelFinalidades { get; set; }
        public DbSet<ImovelTipo_DetalheTipo_DetalheBase> ImovelTipo_DetalheTipo_DetalheBases { get; set; }
        public DbSet<ImovelDetalheTipo_DetalheBase> ImovelDetalheTipos_DetalheBases { get; set; }
        public DbSet<ImovelFinalidade_ImovelTipo> ImovelFinalidades_ImovelTipos { get; set; }
        public DbSet<ImovelDetalheBaseValor> ImovelDetalheBaseValores { get; set; }
        public DbSet<Proprietario> Proprietarios { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));
            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            //FLUENT API
            modelBuilder.Configurations.Add(new PessoaConfig());
            modelBuilder.Configurations.Add(new PessoaFisicaConfig());
            modelBuilder.Configurations.Add(new PessoaJuridicaConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new PessoaFisica_EnderecoConfig());
            modelBuilder.Configurations.Add(new PessoaJuridica_EnderecoConfig());
            modelBuilder.Configurations.Add(new ImovelDetalheBaseConfig());
            modelBuilder.Configurations.Add(new ImovelDetalheTipoConfig());
            modelBuilder.Configurations.Add(new ImovelTipo_DetalheTipo_DetalheBaseConfig());
            modelBuilder.Configurations.Add(new ImovelDetalheTipo_DetalheBaseConfig());
            modelBuilder.Configurations.Add(new ImovelTipoConfig());
            modelBuilder.Configurations.Add(new ImovelFinalidadeConfig());
            modelBuilder.Configurations.Add(new ImovelFinalidade_ImovelTipoConfig());
            modelBuilder.Configurations.Add(new ImovelDetalheBaseValorConfig());
            modelBuilder.Configurations.Add(new ProprietarioConfig());


            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }
                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }

            }
            return base.SaveChanges();
        }
    }
}
