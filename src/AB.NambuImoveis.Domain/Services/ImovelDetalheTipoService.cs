using AB.NambuImoveis.Domain.Interfaces;
using AB.NambuImoveis.Domain.Interfaces.Services;
using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Services
{
    public class ImovelDetalheTipoService : IImovelDetalheTipoService
    {
        private readonly IImovelDetalheTipoRepository _imovelDetalheTipoRepository;
        private readonly IImovelDetalheTipo_DetalheBaseRepository _imovelDetalheTipo_BaseRepository;

        public ImovelDetalheTipoService(IImovelDetalheTipoRepository imovelDetalheTipoRepository, IImovelDetalheTipo_DetalheBaseRepository imovelDetalheTipo_BaseRepository)
        {
            _imovelDetalheTipoRepository = imovelDetalheTipoRepository;
            _imovelDetalheTipo_BaseRepository = imovelDetalheTipo_BaseRepository;
        }
        public ImovelDetalheTipo Adicionar(ImovelDetalheTipo obj)
        {
            if (!obj.EhValido())
            {
                return obj;
            }
            var objRet = _imovelDetalheTipoRepository.Adicionar(obj);
            foreach (var item in objRet.ImovelDetalheBases)
            {
               _imovelDetalheTipo_BaseRepository.Adicionar(new ImovelDetalheTipo_DetalheBase() { ImovelDetalheTipoId = obj.Id, ImovelDetalheBaseId = item.Id });
            }
            return objRet;
        }

        public ImovelDetalheTipo Adicionar(ImovelDetalheTipo obj, ICollection<ImovelDetalheTipo_DetalheBase> imovelDetalheTipo_Bases)
        {
            if (!obj.EhValido())
            {
                return obj;
            }
            var objRet = _imovelDetalheTipoRepository.Adicionar(obj);
            _imovelDetalheTipo_BaseRepository.AdicionarRange(imovelDetalheTipo_Bases);

            return objRet;
        }

        public ImovelDetalheTipo_DetalheBase Adicionar(ImovelDetalheTipo_DetalheBase obj)
        {
            var objRet = _imovelDetalheTipo_BaseRepository.Adicionar(obj);
            return objRet;
        }

        public ImovelDetalheTipo Atualizar(ImovelDetalheTipo obj)
        {
            if (!obj.EhValido())
            {
                return obj;
            }
            var objInicial = _imovelDetalheTipoRepository.ObterPorId(obj.Id);

            var objDetalheBaseRemover = objInicial.ImovelDetalheBases.Except(obj.ImovelDetalheBases);
            var objDetalheBaseAdicionar = obj.ImovelDetalheBases.Except(objInicial.ImovelDetalheBases);

            var objRet = _imovelDetalheTipoRepository.Atualizar(obj);

            var imovelDetalheTipo_BasesAdicionar = new List<ImovelDetalheTipo_DetalheBase>();
            var imovelDetalheTipo_BasesRemover = new List<ImovelDetalheTipo_DetalheBase>();

            foreach (var item in objDetalheBaseAdicionar)
            {               imovelDetalheTipo_BasesAdicionar.Add(new ImovelDetalheTipo_DetalheBase() { ImovelDetalheBaseId = item.Id, ImovelDetalheTipoId = obj.Id });
            };
            foreach (var item in objDetalheBaseRemover)
            {
                imovelDetalheTipo_BasesRemover.Add(new ImovelDetalheTipo_DetalheBase() { ImovelDetalheBaseId = item.Id, ImovelDetalheTipoId = obj.Id });
            };
            _imovelDetalheTipo_BaseRepository.AdicionarRange(imovelDetalheTipo_BasesAdicionar);
            _imovelDetalheTipo_BaseRepository.RemoverRange(imovelDetalheTipo_BasesRemover);

            return objRet;
        }

        public ImovelDetalheTipo Atualizar(ImovelDetalheTipo obj, ICollection<ImovelDetalheTipo_DetalheBase> imovelDetalheTipo_Bases)
        {
            if (!obj.EhValido())
            {
                return obj;
            }
            var objInicial = _imovelDetalheTipo_BaseRepository.Buscar(c=>c.ImovelDetalheTipoId == obj.Id);

            var imovelDetalheTipo_BasesRemover = objInicial.Except(imovelDetalheTipo_Bases).ToList();
            var imovelDetalheTipo_BasesAdicionar = imovelDetalheTipo_Bases.Except(objInicial).ToList();

            var objRet = _imovelDetalheTipoRepository.Atualizar(obj);

            //var imovelDetalheTipo_BasesAdicionar = new List<ImovelDetalheTipo_Base>();
            //var imovelDetalheTipo_BasesRemover = new List<ImovelDetalheTipo_Base>();

            //foreach (var item in objDetalheBaseAdicionar)
            //{
            //    imovelDetalheTipo_BasesAdicionar.Add(new ImovelDetalheTipo_Base() { ImovelDetalheBaseId = item.Id, ImovelDetalheTipoId = obj.Id });
            //};
            //foreach (var item in objDetalheBaseRemover)
            //{
            //    imovelDetalheTipo_BasesRemover.Add(new ImovelDetalheTipo_Base() { ImovelDetalheBaseId = item.Id, ImovelDetalheTipoId = obj.Id });
            //};
            _imovelDetalheTipo_BaseRepository.AdicionarRange(imovelDetalheTipo_BasesAdicionar);
            _imovelDetalheTipo_BaseRepository.RemoverRange(imovelDetalheTipo_BasesRemover);

            return objRet;
        }

        public ImovelDetalheTipo ObterPorId(Guid id)
        {
            var objRet = _imovelDetalheTipoRepository.ObterPorId(id);
            return objRet;
        }

        public IEnumerable<ImovelDetalheTipo> ObterTodos()
        {
            var objRet = _imovelDetalheTipoRepository.ObterTodos();
            return objRet;
        }

        public void Remover(Guid id)
        {
            _imovelDetalheTipo_BaseRepository.Remover(id);
            _imovelDetalheTipoRepository.Remover(id);
        }

        public void Remover(ImovelDetalheTipo obj)
        {
            _imovelDetalheTipo_BaseRepository.Remover(obj.Id);
            _imovelDetalheTipoRepository.Remover(obj);
        }

        public void RemoverImovelDetalheTipo_Base(Guid id)
        {
            _imovelDetalheTipo_BaseRepository.Remover(id);
        }

        public void Dispose()
        {
            _imovelDetalheTipoRepository.Dispose();
            _imovelDetalheTipo_BaseRepository.Dispose();
        }
    }
}
