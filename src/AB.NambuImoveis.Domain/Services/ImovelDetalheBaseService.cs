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
    public class ImovelDetalheBaseService : IImovelDetalheBaseService
    {
        private readonly IImovelDetalheBaseRepository _imovelDetalheBaseRepository;

        public ImovelDetalheBaseService(IImovelDetalheBaseRepository imovelDetalheBaseRepository)
        {
            _imovelDetalheBaseRepository = imovelDetalheBaseRepository;
        }

        public ImovelDetalheBase Adicionar(ImovelDetalheBase obj)
        {
            var objRet = _imovelDetalheBaseRepository.Adicionar(obj);
            return objRet;
        }

        public ImovelDetalheBase Atualizar(ImovelDetalheBase obj)
        {
            var objRet = _imovelDetalheBaseRepository.Atualizar(obj);
            return objRet;
        }

        public IEnumerable<ImovelDetalheBase> ObterTodos()
        {
            var objRet = _imovelDetalheBaseRepository.ObterTodos();
            return objRet;
        }

        public ImovelDetalheBase ObterPorId(Guid id)
        {
            var objRet = _imovelDetalheBaseRepository.ObterPorId(id);
            return objRet;
        }

        public void Remover(Guid id)
        {
            _imovelDetalheBaseRepository.Remover(id);
        }

        public void Remover(ImovelDetalheBase obj)
        {
            _imovelDetalheBaseRepository.Remover(obj);
        }

        public void Dispose()
        {
            _imovelDetalheBaseRepository.Dispose();
        }
        
    }
}
