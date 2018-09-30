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
    public class ImovelDetalheBaseValorService : IImovelDetalheBaseValorService
    {
        private readonly IImovelDetalheBaseValorRepository _imovelDetalheBaseValorRepository;

        public ImovelDetalheBaseValorService(IImovelDetalheBaseValorRepository imovelDetalheBaseValorRepository)
        {
            _imovelDetalheBaseValorRepository = imovelDetalheBaseValorRepository;
        }

        public ImovelDetalheBaseValor Adicionar(ImovelDetalheBaseValor obj)
        {
            var objRet = _imovelDetalheBaseValorRepository.Adicionar(obj);
            return objRet;
        }

        public ImovelDetalheBaseValor Atualizar(ImovelDetalheBaseValor obj)
        {
            var objRet = _imovelDetalheBaseValorRepository.Atualizar(obj);
            return objRet;
        }

       
        public ImovelDetalheBaseValor ObterPorId(Guid id)
        {
            var objRet = _imovelDetalheBaseValorRepository.ObterPorId(id);
            return objRet;
        }

        public IEnumerable<ImovelDetalheBaseValor> ObterTodos()
        {
            var objRet = _imovelDetalheBaseValorRepository.ObterTodos();
            return objRet;
        }

        public void Remover(Guid id)
        {
            _imovelDetalheBaseValorRepository.Remover(id);
        }

        public void Remover(ImovelDetalheBaseValor obj)
        {
            _imovelDetalheBaseValorRepository.Remover(obj);
        }

        public void Dispose()
        {
            _imovelDetalheBaseValorRepository.Dispose();
        }
    }
}
