using AB.NambuImoveis.Application.Interfaces;
using AB.NambuImoveis.Application.Service;
using AB.NambuImoveis.Application.Services;
using AB.NambuImoveis.Domain.Interfaces;
using AB.NambuImoveis.Domain.Interfaces.Services;
using AB.NambuImoveis.Domain.Services;
using AB.NambuImoveis.Infra.Data.Context;
using AB.NambuImoveis.Infra.Data.Repository;
using AB.NambuImoveis.Infra.Data.UoW;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe
            // Lifestyle.Scoped => Uma instancia unica para o request

            //App
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);
            container.Register<IImovelDetalheBaseAppService, ImovelDetalheBaseAppService>(Lifestyle.Scoped);
            container.Register<IImovelDetalheBaseValorAppService, ImovelDetalheBaseValorAppService>(Lifestyle.Scoped);
            container.Register<IImovelDetalheTipoAppService, ImovelDetalheTipoAppService>(Lifestyle.Scoped);
            container.Register<IImovelTipoAppService, ImovelTipoAppService>(Lifestyle.Scoped);
            container.Register<IImovelFinalidadeAppService, ImovelFinalidadeAppService>(Lifestyle.Scoped);
            container.Register<IImovelAppService, ImovelAppService>(Lifestyle.Scoped);

            // Domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);
            container.Register<IImovelDetalheBaseService, ImovelDetalheBaseService>(Lifestyle.Scoped);
            container.Register<IImovelDetalheBaseValorService, ImovelDetalheBaseValorService>(Lifestyle.Scoped);
            container.Register<IImovelDetalheTipoService, ImovelDetalheTipoService>(Lifestyle.Scoped);
            container.Register<IImovelTipoService, ImovelTipoService>(Lifestyle.Scoped);
            container.Register<IImovelFinalidadeService, ImovelFinalidadeService>(Lifestyle.Scoped);
            container.Register<IImovelService, ImovelService>(Lifestyle.Scoped);

            // Data
            container.Register<IPessoaRepository, PessoaRepository>(Lifestyle.Scoped);
            container.Register<IPessoaFisicaRepository, PessoaFisicaRepository>(Lifestyle.Scoped);
            container.Register<IPessoaJuridicaRepository, PessoaJuridicaRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);
            container.Register<IPessoaFisica_EnderecoRepository, PessoaFisica_EnderecoRepository>(Lifestyle.Scoped);
            container.Register<IPessoaJuridica_EnderecoRepository, PessoaJuridica_EnderecoRepository>(Lifestyle.Scoped);
            container.Register<IImovelDetalheBaseRepository, ImovelDetalheBaseRepository>(Lifestyle.Scoped);
            container.Register<IImovelDetalheBaseValorRepository, ImovelDetalheBaseValorRepository>(Lifestyle.Scoped);
            container.Register<IImovelDetalheTipoRepository, ImovelDetalheTipoRepository>(Lifestyle.Scoped);
            container.Register<IImovelTipo_DetalheTipo_DetalheBaseRepository, ImovelTipo_Detalhetipo_DetalheBaseRepository>(Lifestyle.Scoped);
            container.Register<IImovelDetalheTipo_DetalheBaseRepository, ImovelDetalheTipo_DetalheBaseRepository>(Lifestyle.Scoped);
            container.Register<IImovelTipoRepository, ImovelTipoRepository>(Lifestyle.Scoped);
            container.Register<IImovelFinalidadeRepository, ImovelFinalidadeRepository>(Lifestyle.Scoped);
            container.Register<IImovelFinalidade_ImovelTipoRepository, ImovelFinalidade_ImovelTipoRepository>(Lifestyle.Scoped);
            container.Register<IProprietarioRepository, ProprietarioRepository>(Lifestyle.Scoped);
            container.Register<IImovel_ProprietarioRepository, Imovel_ProprietarioRepository>(Lifestyle.Scoped);
            container.Register<IImovelRepository, ImovelRepository>(Lifestyle.Scoped);


            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            container.Register<NambuImoveisContext>(Lifestyle.Scoped);
            //container.Register(typeof(IRepository<>), typeof(Repository<>));

            // Logging
            //container.Register<ILogAuditoria, LogAuditoriaHelper>(Lifestyle.Scoped);
            //container.Register<LogginContext>(Lifestyle.Scoped);
        }
    }
}
