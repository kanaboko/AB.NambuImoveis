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
    public class ImovelTipoAppService : AppService, IImovelTipoAppService
    {
        private readonly IImovelTipoService _imovelTipoService;
        private readonly IImovelTipoRepository _imovelTipoRepository;
        public ImovelTipoAppService(IImovelTipoService imovelTipoService, IImovelTipoRepository imovelTipoRepository, IImovelTipo_DetalheTipo_DetalheBaseRepository imovelTipo_DetalheTipo_DetalheBaseRepository, IUnitOfWork uow): base(uow)
        {
            _imovelTipoRepository = imovelTipoRepository;
            _imovelTipoService = imovelTipoService;

        }
        public ImovelTipoViewModel Adicionar(ImovelTipoViewModel obj)
        {
            var imovelTipo = Mapper.Map<ImovelTipo>(obj);
            var objRet = _imovelTipoService.Adicionar(imovelTipo);
            if (!Commit())
            {

            }
            return Mapper.Map<ImovelTipoViewModel>(objRet);

        }

        public ImovelTipoViewModel Adicionar(ImovelTipoViewModel obj, string[] imovelDetalheTipoSelecionado, string[] imovelDetalheBaseSelecionado)
        {
            var imovelTipo = Mapper.Map<ImovelTipo>(obj);
            var imovelTipo_DetalheTipo_DetalheBase = new List<ImovelTipo_DetalheTipo_DetalheBase>();

            foreach (var item in imovelDetalheBaseSelecionado)
            {
                var imovelDetalheTipo_DetalheBase = item.Split(',');
                imovelTipo_DetalheTipo_DetalheBase.Add(new ImovelTipo_DetalheTipo_DetalheBase { ImovelTipoId = obj.Id, ImovelDetalheTipoId = Guid.Parse(imovelDetalheTipo_DetalheBase[0]), ImovelDetalheBaseId = Guid.Parse(imovelDetalheTipo_DetalheBase[1]) });
            }
            var imovelTipoRet = _imovelTipoService.Adicionar(imovelTipo, imovelTipo_DetalheTipo_DetalheBase);
            if (!Commit())
            {

            }
            return Mapper.Map<ImovelTipoViewModel>(imovelTipoRet);
        }

        public ImovelTipoViewModel Atualizar(ImovelTipoViewModel obj)
        {
            var imovelTipo = Mapper.Map<ImovelTipo>(obj);
            var objRet = _imovelTipoService.Atualizar(imovelTipo);
            if (!Commit())
            {

            }
            return Mapper.Map<ImovelTipoViewModel>(objRet);
        }

        public ImovelTipoViewModel Atualizar(ImovelTipoViewModel obj, string[] imovelDetalheBaseSelecionado)
        {
            var imovelTipo = Mapper.Map<ImovelTipo>(obj);
            var imovelTipo_DetalheTipo_DetalheBase = new List<ImovelTipo_DetalheTipo_DetalheBase>();

            foreach (var item in imovelDetalheBaseSelecionado)
            {
                var imovelDetalheTipo_DetalheBase = item.Split(',');
                imovelTipo_DetalheTipo_DetalheBase.Add(new ImovelTipo_DetalheTipo_DetalheBase { ImovelTipoId = obj.Id, ImovelDetalheTipoId = Guid.Parse(imovelDetalheTipo_DetalheBase[0]), ImovelDetalheBaseId = Guid.Parse(imovelDetalheTipo_DetalheBase[1]) });
            }
            var imovelTipoRet = _imovelTipoService.Atualizar(imovelTipo, imovelTipo_DetalheTipo_DetalheBase);
            if (!Commit())
            {

            }
            return Mapper.Map<ImovelTipoViewModel>(imovelTipoRet);
        }        

        public ImovelTipoViewModel ObterPorId(Guid id)
        {
            var objRet = _imovelTipoRepository.ObterPorId(id);
            return Mapper.Map<ImovelTipoViewModel>(objRet);
        }

        public IEnumerable<ImovelTipoViewModel> ObterTodos()
        {
            var objRet = _imovelTipoRepository.ObterTodos();
            return Mapper.Map<IEnumerable<ImovelTipoViewModel>>(objRet);
        }

        public void Remover(Guid id)
        {
            _imovelTipoService.Remover(id);
            Commit();
        }

        public void Remover(ImovelTipoViewModel obj)
        {
            var imovelTipo = Mapper.Map<ImovelTipo>(obj);
            _imovelTipoService.Remover(imovelTipo);
            Commit();
        }

        public void Dispose()
        {
            _imovelTipoService.Dispose();
            _imovelTipoRepository.Dispose();
        }
    }
}
