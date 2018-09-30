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
    public class ImovelTipoService : IImovelTipoService
    {
        private readonly IImovelTipoRepository _imovelTipoRepository;
        private readonly IImovelTipo_DetalheTipo_DetalheBaseRepository _imovelTipo_DetalheTipo_DetalheBaseRepository;
        public ImovelTipoService(IImovelTipoRepository imovelTipoRepository, IImovelTipo_DetalheTipo_DetalheBaseRepository imovelTipo_DetalheTipo_DetalheBaseRepository)
        {
            _imovelTipoRepository = imovelTipoRepository;
            _imovelTipo_DetalheTipo_DetalheBaseRepository = imovelTipo_DetalheTipo_DetalheBaseRepository;
        }

        public ImovelTipo Adicionar(ImovelTipo obj)
        {
            if (!obj.EhValido())
            {
                return obj;
            }
            var objRet = _imovelTipoRepository.Adicionar(obj);

            return objRet;
        }

        public ImovelTipo Adicionar(ImovelTipo obj, ICollection<ImovelTipo_DetalheTipo_DetalheBase> imovelDetalheTipo_Base)
        {
            if (!obj.EhValido())
            {
                return obj;
            }
            var objRet = _imovelTipoRepository.Adicionar(obj);
            _imovelTipo_DetalheTipo_DetalheBaseRepository.AdicionarRange(imovelDetalheTipo_Base);

            return objRet;
        }

        public ImovelTipo_DetalheTipo_DetalheBase Adicionar(ImovelTipo_DetalheTipo_DetalheBase obj)
        {
            throw new NotImplementedException();
        }

        public ImovelTipo Atualizar(ImovelTipo obj)
        {
            if (!obj.EhValido())
            {
                return obj;
            }
            var objRet = _imovelTipoRepository.Atualizar(obj);

            return objRet;
        }

        public ImovelTipo Atualizar(ImovelTipo obj, ICollection<ImovelTipo_DetalheTipo_DetalheBase> imovelTipo_DetalheTipo_Base)
        {
            if (!obj.EhValido())
            {
                return obj;
            }
            var objInicial = _imovelTipo_DetalheTipo_DetalheBaseRepository.Buscar(c => c.ImovelTipoId == obj.Id);

            var imovelTipo_DetalheTipo_BasesRemover = objInicial.Except(imovelTipo_DetalheTipo_Base).ToList();
            var imovelTipo_DetalheTipo_BasesAdicionar = imovelTipo_DetalheTipo_Base.Except(objInicial).ToList();

            var objRet = _imovelTipoRepository.Atualizar(obj);
            
            _imovelTipo_DetalheTipo_DetalheBaseRepository.AdicionarRange(imovelTipo_DetalheTipo_BasesAdicionar);
            _imovelTipo_DetalheTipo_DetalheBaseRepository.RemoverRange(imovelTipo_DetalheTipo_BasesRemover);

            return objRet;
        }        

        public ImovelTipo ObterPorId(Guid id)
        {
            return _imovelTipoRepository.ObterPorId(id);
        }

        public IEnumerable<ImovelTipo> ObterTodos()
        {
            return _imovelTipoRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            _imovelTipo_DetalheTipo_DetalheBaseRepository.Remover(id);
            _imovelTipoRepository.Remover(id);
        }

        public void Remover(ImovelTipo obj)
        {
            _imovelTipo_DetalheTipo_DetalheBaseRepository.Remover(obj.Id);
            _imovelTipoRepository.Remover(obj);
        }

        public void RemoverImovelDetalheTipo_Base(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _imovelTipo_DetalheTipo_DetalheBaseRepository.Dispose();
            _imovelTipoRepository.Dispose();
        }
    }
}
