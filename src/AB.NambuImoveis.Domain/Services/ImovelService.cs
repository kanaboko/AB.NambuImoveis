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
    public class ImovelService : IImovelService
    {
        private readonly IImovelRepository _imovelRepository;
        private readonly IImovel_ProprietarioRepository _imovel_ProprietarioRepository;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IImovelDetalheBaseValorRepository _imovelDetalheBaseValorRepository;
        private readonly IProprietarioRepository _proprietarioRepository;

        public ImovelService(IImovelRepository imovelRepository, IImovel_ProprietarioRepository imovel_ProprietarioRepository, IEnderecoRepository enderecoRepository, IImovelDetalheBaseValorRepository imovelDetalheBaseValorRepository, IProprietarioRepository proprietarioRepository)
        {
            _imovelRepository = imovelRepository;
            _imovel_ProprietarioRepository = imovel_ProprietarioRepository;
            _enderecoRepository = enderecoRepository;
            _imovelDetalheBaseValorRepository = imovelDetalheBaseValorRepository;
            _proprietarioRepository = proprietarioRepository;
        }

        public Imovel Adicionar(Imovel obj)
        {
            if (!obj.EhValido())
            {
                return obj;
            }
            var objRet = _imovelRepository.Adicionar(obj);

            return objRet;
        }

        public Imovel Adicionar(Imovel obj, ICollection<Imovel_Proprietario> imovel_Proprietario, ICollection<Proprietario> proprietarios)
        {
            if (!obj.EhValido())
            {
                return obj;
            }
            var objRet = _imovelRepository.Adicionar(obj);
            _imovel_ProprietarioRepository.AdicionarRange(imovel_Proprietario);
            _proprietarioRepository.AdicionarRange(proprietarios);

            return objRet;
        }

        public Imovel_Proprietario Adicionar(Imovel_Proprietario obj)
        {
            throw new NotImplementedException();
        }

        public Imovel Atualizar(Imovel obj)
        {
            throw new NotImplementedException();
        }

        public Imovel Atualizar(Imovel obj, ICollection<Imovel_Proprietario> imovel_Proprietario, ICollection<Proprietario> proprietarios)
        {
            throw new NotImplementedException();
        }

        
        public Imovel ObterPorId(Guid id)
        {
            return _imovelRepository.ObterPorId(id);
        }

        public IEnumerable<Imovel> ObterTodos()
        {
            return _imovelRepository.ObterTodos();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remover(Imovel obj)
        {
            throw new NotImplementedException();
        }

        public void RemoverImovelDetalheTipo_Base(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _imovelRepository.Dispose();
            _imovel_ProprietarioRepository.Dispose();
            _enderecoRepository.Dispose();
            _imovelDetalheBaseValorRepository.Dispose();
            _proprietarioRepository.Dispose();
        }
    }
}
