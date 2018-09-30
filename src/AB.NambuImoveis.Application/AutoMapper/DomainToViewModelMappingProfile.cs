using AB.NambuImoveis.Application.ViewModels;
using AB.NambuImoveis.Domain.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Pessoa, PessoaViewModel>();
            CreateMap<PessoaFisica, PessoaFisicaViewModel>();
            CreateMap<PessoaJuridica, PessoaJuridicaViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<ImovelDetalheBase, ImovelDetalheBaseViewModel>();
            CreateMap<ImovelDetalheTipo, ImovelDetalheTipoViewModel>();
            CreateMap<ImovelTipo, ImovelTipoViewModel>();
            CreateMap<ImovelFinalidade, ImovelFinalidadeViewModel>();
            CreateMap<ImovelDetalheBaseValor, ImovelDetalheBaseValorViewModel>();
            CreateMap<Imovel, ImovelViewModel>();
            CreateMap<Proprietario, ProprietarioViewModel>();
        }
    }
}
