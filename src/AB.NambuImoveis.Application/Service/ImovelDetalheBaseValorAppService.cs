using AB.NambuImoveis.Application.Interfaces;
using AB.NambuImoveis.Application.ViewModels;
using AB.NambuImoveis.Domain.Interfaces;
using AB.NambuImoveis.Domain.Interfaces.Services;
using AB.NambuImoveis.Domain.Models;
using AB.NambuImoveis.Infra.Data.UoW;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.Service
{
    public class ImovelDetalheBaseValorAppService : AppService, IImovelDetalheBaseValorAppService
    {
        private readonly IImovelDetalheBaseValorRepository _imovelDetalheBaseValorRepository;
        private readonly IImovelDetalheBaseValorService _imovelDetalheBaseValorService;

        public ImovelDetalheBaseValorAppService(IImovelDetalheBaseValorRepository imovelDetalheBaseValorRepository, IImovelDetalheBaseValorService imovelDetalheBaseValorService, IUnitOfWork uow): base(uow)
        {
            _imovelDetalheBaseValorRepository = imovelDetalheBaseValorRepository;
            _imovelDetalheBaseValorService = imovelDetalheBaseValorService;
        }

        public ImovelDetalheBaseValorViewModel Adicionar(ImovelDetalheBaseValorViewModel obj)
        {
            var imovelDetalheBaseValor = Mapper.Map<ImovelDetalheBaseValor>(obj);
            var objRet = _imovelDetalheBaseValorService.Adicionar(imovelDetalheBaseValor);
            if (!Commit())
            {
                return null;
            }
            return Mapper.Map<ImovelDetalheBaseValorViewModel>(objRet);
        }

        public ImovelDetalheBaseValorViewModel Atualizar(ImovelDetalheBaseValorViewModel obj)
        {
            var imovelDetalheBaseValor = Mapper.Map<ImovelDetalheBaseValor>(obj);
            var objRet = _imovelDetalheBaseValorService.Atualizar(imovelDetalheBaseValor);
            if (!Commit())
            {
                return null;
            }
            return Mapper.Map<ImovelDetalheBaseValorViewModel>(objRet);
        }        

        public ImovelDetalheBaseValorViewModel ObterPorId(Guid id)
        {
            var imovelDetalheBaseValor = _imovelDetalheBaseValorRepository.ObterPorId(id);
            return Mapper.Map<ImovelDetalheBaseValorViewModel>(imovelDetalheBaseValor);
        }

        public IEnumerable<ImovelDetalheBaseValorViewModel> ObterTodos()
        {
            var imovelDetalheBaseValor = _imovelDetalheBaseValorRepository.ObterTodos();
            return Mapper.Map<ICollection<ImovelDetalheBaseValorViewModel>>(imovelDetalheBaseValor);
        }

        public void Remover(Guid id)
        {
            _imovelDetalheBaseValorService.Remover(id);
            Commit();
        }

        public void Remover(ImovelDetalheBaseValorViewModel obj)
        {
            var imovelDetalheBaseValor = Mapper.Map<ImovelDetalheBaseValor>(obj);
            _imovelDetalheBaseValorService.Remover(imovelDetalheBaseValor);
            Commit();
        }

        public void Dispose()
        {
            _imovelDetalheBaseValorRepository.Dispose();
            _imovelDetalheBaseValorService.Dispose();
        }
    }
}
