using AB.NambuImoveis.Application.Interfaces;
using AB.NambuImoveis.Application.ViewModels;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AB.NambuImoveis.Domain.Models;
using AB.NambuImoveis.Domain.Interfaces.Services;
using AB.NambuImoveis.Domain.Interfaces;
using AB.NambuImoveis.Infra.Data.UoW;

namespace AB.NambuImoveis.Application.Service
{
    public class ImovelDetalheTipoAppService : AppService, IImovelDetalheTipoAppService
    {
        private readonly IImovelDetalheTipoService _imovelDetalheTipoService;
        private readonly IImovelDetalheTipoRepository _imovelDetalheTipoRepository;
        public ImovelDetalheTipoAppService(IImovelDetalheTipoService imovelDetalheTipoService, IImovelDetalheTipoRepository imovelDetalheTipoRepository, IUnitOfWork uow): base(uow)
        {
            _imovelDetalheTipoRepository = imovelDetalheTipoRepository;
            _imovelDetalheTipoService = imovelDetalheTipoService;
        }
        public ImovelDetalheTipoViewModel Adicionar(ImovelDetalheTipoViewModel obj)
        {
            var imovelDetalheTipo = Mapper.Map<ImovelDetalheTipo>(obj);
            var objRet = _imovelDetalheTipoService.Adicionar(imovelDetalheTipo);
            if (!Commit())
            {
                return null;
            }
            return Mapper.Map<ImovelDetalheTipoViewModel>(objRet);
        }

        public ImovelDetalheTipoViewModel Adicionar(ImovelDetalheTipoViewModel obj, string[] imovelDetalheBaseSelecionado)
        {
            var imovelDetalheTipo = Mapper.Map<ImovelDetalheTipo>(obj);
            var imovelDetalheTipo_BaseLista = new List<ImovelDetalheTipo_DetalheBase>();
            if (imovelDetalheBaseSelecionado!=null)
            {
                foreach (var item in imovelDetalheBaseSelecionado)
                {
                    imovelDetalheTipo_BaseLista.Add(new ImovelDetalheTipo_DetalheBase() { ImovelDetalheTipoId = imovelDetalheTipo.Id, ImovelDetalheBaseId = Guid.Parse(item) });
                }
            }
            var objRet = _imovelDetalheTipoService.Adicionar(imovelDetalheTipo, imovelDetalheTipo_BaseLista);
            if (!Commit())
            {
                return null;
            }
            return Mapper.Map<ImovelDetalheTipoViewModel>(objRet);
        }

        public ImovelDetalheTipoViewModel Atualizar(ImovelDetalheTipoViewModel obj)
        {
            var imovelDetalheTipo = Mapper.Map<ImovelDetalheTipo>(obj);
            var objRet = _imovelDetalheTipoService.Atualizar(imovelDetalheTipo);
            if (!Commit())
            {
                return null;
            }
            return Mapper.Map<ImovelDetalheTipoViewModel>(objRet);
        }

        public ImovelDetalheTipoViewModel Atualizar(ImovelDetalheTipoViewModel obj, string[] imovelDetalheBaseSelecionado)
        {
            var imovelDetalheTipo = Mapper.Map<ImovelDetalheTipo>(obj);
            var imovelDetalheTipo_BaseLista = new List<ImovelDetalheTipo_DetalheBase>();
            if (imovelDetalheBaseSelecionado != null)
            {
                foreach (var item in imovelDetalheBaseSelecionado)
                {
                    imovelDetalheTipo_BaseLista.Add(new ImovelDetalheTipo_DetalheBase() { ImovelDetalheTipoId = imovelDetalheTipo.Id, ImovelDetalheBaseId = Guid.Parse(item) });
                }
            }
            var objRet = _imovelDetalheTipoService.Atualizar(imovelDetalheTipo, imovelDetalheTipo_BaseLista);
            if (!Commit())
            {
                return null;
            }
            return Mapper.Map<ImovelDetalheTipoViewModel>(objRet);
        }

        public ImovelDetalheTipoViewModel ObterPorId(Guid id)
        {
            var imovelDetalheTipo = _imovelDetalheTipoRepository.ObterPorId(id);
            return Mapper.Map<ImovelDetalheTipoViewModel>(imovelDetalheTipo);
        }

        public IEnumerable<ImovelDetalheTipoViewModel> ObterTodos()
        {
            var imovelDetalheTipo = _imovelDetalheTipoRepository.ObterTodos();
            return Mapper.Map<IEnumerable<ImovelDetalheTipoViewModel>>(imovelDetalheTipo);
        }

        public void Remover(Guid id)
        {
            _imovelDetalheTipoService.Remover(id);
            Commit();
        }

        public void Remover(ImovelDetalheTipoViewModel obj)
        {
            var imovelDetalheTipo = Mapper.Map<ImovelDetalheTipo>(obj);
            _imovelDetalheTipoService.Remover(imovelDetalheTipo);
            Commit();
        }

        public void Dispose()
        {
            _imovelDetalheTipoService.Dispose();
            _imovelDetalheTipoRepository.Dispose();
        }
    }
}
