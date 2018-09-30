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
    public class ImovelFinalidadeService : IImovelFinalidadeService
    {
        private readonly IImovelFinalidadeRepository _imovelFinalidadeRepository;
        private readonly IImovelFinalidade_ImovelTipoRepository _imovelFinalidade_ImovelTipoRepository;

        public ImovelFinalidadeService(IImovelFinalidadeRepository imovelFinalidadeRepository, IImovelFinalidade_ImovelTipoRepository imovelFinalidade_ImovelTipoRepository)
        {
            _imovelFinalidadeRepository = imovelFinalidadeRepository;
            _imovelFinalidade_ImovelTipoRepository = imovelFinalidade_ImovelTipoRepository;
        }
        public ImovelFinalidade Adicionar(ImovelFinalidade obj)
        {
            if (!obj.EhValido())
            {
                return obj;
            }
            var objRet = _imovelFinalidadeRepository.Adicionar(obj);

            return objRet;

        }

        public ImovelFinalidade Adicionar(ImovelFinalidade obj, ICollection<ImovelFinalidade_ImovelTipo> imovelFinalidade_ImovelTipo)
        {
            if (!obj.EhValido())
            {
                return obj;
            }
            var objRet = _imovelFinalidadeRepository.Adicionar(obj);
            _imovelFinalidade_ImovelTipoRepository.AdicionarRange(imovelFinalidade_ImovelTipo);

            return objRet;
        }

        public ImovelFinalidade_ImovelTipo Adicionar(ImovelFinalidade_ImovelTipo obj)
        {
            throw new NotImplementedException();
        }

        public ImovelFinalidade Atualizar(ImovelFinalidade obj)
        {
            if (!obj.EhValido())
            {
                return obj;
            }
            var objRet = _imovelFinalidadeRepository.Atualizar(obj);

            return objRet;
        }

        public ImovelFinalidade Atualizar(ImovelFinalidade obj, ICollection<ImovelFinalidade_ImovelTipo> imovelFinalidade_ImovelTipo)
        {
            if (!obj.EhValido())
            {
                return obj;
            }
            var objInicial = _imovelFinalidade_ImovelTipoRepository.Buscar(c => c.ImovelFinalidadeId == obj.Id);

            var imovelFinalida_ImovelTipoRemover = objInicial.Except(imovelFinalidade_ImovelTipo).ToList();
            var imovelFinalidade_ImovelTipoAdicionar = imovelFinalidade_ImovelTipo.Except(objInicial).ToList();

            var objRet = _imovelFinalidadeRepository.Atualizar(obj);

            _imovelFinalidade_ImovelTipoRepository.RemoverRange(imovelFinalida_ImovelTipoRemover);
            _imovelFinalidade_ImovelTipoRepository.AdicionarRange(imovelFinalidade_ImovelTipoAdicionar);

            return objRet;
        }
                

        public ImovelFinalidade ObterPorId(Guid id)
        {
            var obj = _imovelFinalidadeRepository.ObterPorId(id);
            return obj;
        }

        public IEnumerable<ImovelFinalidade> ObterTodos()
        {
            var obj = _imovelFinalidadeRepository.ObterTodos();
            return obj;
        }

        public void Remover(Guid id)
        {
            _imovelFinalidade_ImovelTipoRepository.Remover(id);
            _imovelFinalidadeRepository.Remover(id);
        }

        public void Remover(ImovelFinalidade obj)
        {
            _imovelFinalidade_ImovelTipoRepository.Remover(obj.Id);
            _imovelFinalidadeRepository.Remover(obj);
        }

        public void RemoverImovelFinalide_ImovelTipo(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _imovelFinalidadeRepository.Dispose();
            _imovelFinalidade_ImovelTipoRepository.Dispose();
        }
    }
}
