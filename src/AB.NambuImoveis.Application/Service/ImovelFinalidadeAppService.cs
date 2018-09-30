using AB.NambuImoveis.Application.Interfaces;
using AB.NambuImoveis.Application.ViewModels;
using AB.NambuImoveis.Domain.Interfaces;
using AB.NambuImoveis.Domain.Interfaces.Services;
using AB.NambuImoveis.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AB.NambuImoveis.Domain.Models;

namespace AB.NambuImoveis.Application.Service
{
    public class ImovelFinalidadeAppService : AppService, IImovelFinalidadeAppService
    {
        private readonly IImovelFinalidadeService _imovelFinalidadeService;
        private readonly IImovelFinalidadeRepository _imovelFinalidadeRepository;

        public ImovelFinalidadeAppService(IImovelFinalidadeService imovelFinalidadeService, IImovelFinalidadeRepository imovelFinalidadeRepository, IUnitOfWork uow) : base(uow)
        {
            _imovelFinalidadeService = imovelFinalidadeService;
            _imovelFinalidadeRepository = imovelFinalidadeRepository;
        }

        public ImovelFinalidadeViewModel Adicionar(ImovelFinalidadeViewModel obj)
        {
            var imovelFinalidade = Mapper.Map<ImovelFinalidade>(obj);
            var objRet = _imovelFinalidadeService.Adicionar(imovelFinalidade);
            if (!Commit())
            {
                return null;
            }
            return Mapper.Map<ImovelFinalidadeViewModel>(objRet);

        }

        public ImovelFinalidadeViewModel Adicionar(ImovelFinalidadeViewModel obj, string[] imovelTipoSelecionado)
        {
            var imovelFinalidade = Mapper.Map<ImovelFinalidade>(obj);
            var imovelFinalidade_ImovelTipo = new List<ImovelFinalidade_ImovelTipo>();
            if (imovelTipoSelecionado != null)
            {
                foreach (var item in imovelTipoSelecionado)
                {
                    imovelFinalidade_ImovelTipo.Add(new ImovelFinalidade_ImovelTipo() { ImovelFinalidadeId = obj.Id, ImovelTipoId = Guid.Parse(item) });

                }
            }

            var objRet = _imovelFinalidadeService.Adicionar(imovelFinalidade, imovelFinalidade_ImovelTipo);

            if (!Commit())
            {
                return null;
            }

            return Mapper.Map<ImovelFinalidadeViewModel>(objRet);
        }

        public ImovelFinalidadeViewModel Atualizar(ImovelFinalidadeViewModel obj)
        {
            var imovelFinalidade = Mapper.Map<ImovelFinalidade>(obj);
            var objRet = _imovelFinalidadeService.Atualizar(imovelFinalidade);
            if (!Commit())
            {
                return null;
            }
            return Mapper.Map<ImovelFinalidadeViewModel>(objRet);
        }

        public ImovelFinalidadeViewModel Atualizar(ImovelFinalidadeViewModel obj, string[] imovelTipoSelecionado)
        {
            var imovelFinalidade = Mapper.Map<ImovelFinalidade>(obj);
            var imovelFinalidade_ImovelTipo = new List<ImovelFinalidade_ImovelTipo>();
            if (imovelTipoSelecionado != null)
            {
                foreach (var item in imovelTipoSelecionado)
                {
                    imovelFinalidade_ImovelTipo.Add(new ImovelFinalidade_ImovelTipo() { ImovelFinalidadeId = obj.Id, ImovelTipoId = Guid.Parse(item) });

                }
            }

            var objRet = _imovelFinalidadeService.Atualizar(imovelFinalidade, imovelFinalidade_ImovelTipo);

            if (!Commit())
            {
                return null;
            }

            return Mapper.Map<ImovelFinalidadeViewModel>(objRet);
        }        

        public ImovelFinalidadeViewModel ObterPorId(Guid id)
        {
            var obj = _imovelFinalidadeRepository.ObterPorId(id);
            return Mapper.Map<ImovelFinalidadeViewModel>(obj);
        }

        public IEnumerable<ImovelFinalidadeViewModel> ObterTodos()
        {
            var obj = _imovelFinalidadeRepository.ObterTodos();
            return Mapper.Map<IEnumerable<ImovelFinalidadeViewModel>>(obj);
        }

        public void Remover(Guid id)
        {
            _imovelFinalidadeService.Remover(id);
            Commit();
        }

        public void Remover(ImovelFinalidadeViewModel obj)
        {
            var imovelFinalidade = Mapper.Map<ImovelFinalidade>(obj);
            _imovelFinalidadeService.Remover(imovelFinalidade);
            Commit();
        }
        
        public void Dispose()
        {
            _imovelFinalidadeService.Dispose();
            _imovelFinalidadeRepository.Dispose();
        }
    }
}
