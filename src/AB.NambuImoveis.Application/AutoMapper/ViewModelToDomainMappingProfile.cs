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
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<PessoaViewModel, Pessoa>();
            CreateMap<PessoaFisicaViewModel, PessoaFisica>();
            CreateMap<PessoaJuridicaViewModel, PessoaJuridica>();
            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<ImovelDetalheBaseViewModel, ImovelDetalheBase>();
            CreateMap<ImovelDetalheTipoViewModel, ImovelDetalheTipo>();
            CreateMap<ImovelTipoViewModel, ImovelTipo>();
            CreateMap<ImovelFinalidadeViewModel, ImovelFinalidade>();
            CreateMap<ImovelDetalheBaseValorViewModel, ImovelDetalheBaseValor>();
            CreateMap<ImovelViewModel, Imovel>();
            CreateMap<ProprietarioViewModel, Proprietario>();
        }
    }
}
