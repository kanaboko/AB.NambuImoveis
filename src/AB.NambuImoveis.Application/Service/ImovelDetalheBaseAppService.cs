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
    public class ImovelDetalheBaseAppService : AppService, IImovelDetalheBaseAppService
    {
        private readonly IImovelDetalheBaseService _imovelDetalheBaseService;
        private readonly IImovelDetalheBaseRepository _imovelDetalheBaseRepository;
        public ImovelDetalheBaseAppService(IImovelDetalheBaseService imovelDetalheBaseService, IImovelDetalheBaseRepository imovelDetalheBaseRepository, IUnitOfWork uow): base(uow)
        {
            _imovelDetalheBaseService = imovelDetalheBaseService;
            _imovelDetalheBaseRepository = imovelDetalheBaseRepository;
        }
        public ImovelDetalheBaseViewModel Adicionar(ImovelDetalheBaseViewModel obj)
        {
            var imovelDetalheBase = Mapper.Map<ImovelDetalheBase>(obj);
            var objRet = _imovelDetalheBaseService.Adicionar(imovelDetalheBase);
            if (!Commit())
            {
                return null;
            }
            return Mapper.Map<ImovelDetalheBaseViewModel>(objRet);
        }

        public ImovelDetalheBaseViewModel Atualizar(ImovelDetalheBaseViewModel obj)
        {
            var imovelDetalheBase = Mapper.Map<ImovelDetalheBase>(obj);
            var objRet = _imovelDetalheBaseService.Atualizar(imovelDetalheBase);
            if (!Commit())
            {
                return null;
            }
            return Mapper.Map<ImovelDetalheBaseViewModel>(objRet);
        }

        public IEnumerable<ImovelDetalheBaseViewModel> ObterTodos()
        {
            var objRet = Mapper.Map<IEnumerable<ImovelDetalheBaseViewModel>>(_imovelDetalheBaseRepository.ObterTodos());
            return objRet;
        }

        public ImovelDetalheBaseViewModel ObterPorId(Guid id)
        {
            var imovelDetalheBase = _imovelDetalheBaseService.ObterPorId(id);
            return Mapper.Map<ImovelDetalheBaseViewModel>(imovelDetalheBase);
        }

        public void Remover(Guid id)
        {
            _imovelDetalheBaseService.Remover(id);
            Commit();
        }

        public void Remover(ImovelDetalheBaseViewModel obj)
        {
            var imovelDetalheBase = Mapper.Map<ImovelDetalheBase>(obj);
            _imovelDetalheBaseService.Remover(imovelDetalheBase);
            Commit();
        }

        public void Dispose()
        {
            _imovelDetalheBaseService.Dispose();
        }
        
    }
}
