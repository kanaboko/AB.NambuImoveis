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
    public class ClienteService : IClienteService
    {
        protected readonly IPessoaRepository _pessoaRepository;
        protected readonly IPessoaFisicaRepository _pessoaFisicaRepository;
        protected readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;
        protected readonly IEnderecoRepository _enderecoRepository;
        protected readonly IPessoaFisica_EnderecoRepository _pessoaFisica_EnderecoRepository;
        protected readonly IPessoaJuridica_EnderecoRepository _pessoaJuridica_EnderecoRepository;

        public ClienteService(IPessoaRepository pessoaRepository, IPessoaFisicaRepository pessoaFisicaRepository, IPessoaJuridicaRepository pessoaJuridicaRepository, IEnderecoRepository enderecoRepository, IPessoaFisica_EnderecoRepository pessoaFisica_EnderecoRepository, IPessoaJuridica_EnderecoRepository pessoaJuridica_EnderecoRepository)
        {
            _pessoaRepository = pessoaRepository;
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
            _enderecoRepository = enderecoRepository;
            _pessoaFisica_EnderecoRepository = pessoaFisica_EnderecoRepository;
            _pessoaJuridica_EnderecoRepository = pessoaJuridica_EnderecoRepository;
        }

        public Pessoa Adicionar(Pessoa pessoa)
        {

            switch (pessoa.TipoPessoa)
            {
                case TipoPessoa.PessoaFisica:
                    if (!pessoa.PessoaFisica.EhValido())
                        return pessoa;
                    _pessoaFisica_EnderecoRepository.Adicionar(new PessoaFisica_Endereco() { PessoaFisicaId = pessoa.PessoaFisica.Id, EnderecoId = pessoa.PessoaFisica.EnderecoList.First().Id });
                    break;
                case TipoPessoa.PessoaJuridica:
                    if (!pessoa.PessoaJuridica.EhValido())
                        return pessoa;
                    _pessoaJuridica_EnderecoRepository.Adicionar(new PessoaJuridica_Endereco() { PessoaJuridicaId = pessoa.PessoaJuridica.Id, EnderecoId = pessoa.PessoaJuridica.EnderecoList.First().Id } );

                    break;
                default:
                    break;
            }
            var pessoaReturn = _pessoaRepository.Adicionar(pessoa);

            return pessoaReturn;
        }

        public Endereco Adicionar(Endereco endereco)
        {
            return _enderecoRepository.Adicionar(endereco);
        }

        public void Adicionar(PessoaFisica_Endereco pessoaFisica_Endereco)
        {
            _pessoaFisica_EnderecoRepository.Adicionar(pessoaFisica_Endereco);
        }

        public void Adicionar(PessoaJuridica_Endereco pessoaJuridica_Endereco)
        {
            _pessoaJuridica_EnderecoRepository.Adicionar(pessoaJuridica_Endereco);
        }

        public Pessoa Atualizar(Pessoa pessoa)
        {
            return _pessoaRepository.Atualizar(pessoa);
        }

        public Endereco Atualizar(Endereco endereco)
        {
            return _enderecoRepository.Atualizar(endereco);
        }

        public PessoaFisica AtualizarPessoaFisica(PessoaFisica pessoa)
        {
            return _pessoaFisicaRepository.Atualizar(pessoa);
        }

        public PessoaJuridica AtualizarPessoaJuridica(PessoaJuridica pessoa)
        {
            return _pessoaJuridicaRepository.Atualizar(pessoa);
        }        

        public void Remover(Guid id)
        {
            _pessoaRepository.Remover(id);
        }

        public void Remover(Pessoa pessoa)
        {
            _pessoaRepository.Remover(pessoa);
        }

        public void RemoverPessoaFisica_Endereco(Guid enderecoId)
        {
            _pessoaFisica_EnderecoRepository.Remover(enderecoId);
        }

        public void RemoverPessoaJuridica_Endereco(Guid enderecoId)
        {
            _pessoaJuridica_EnderecoRepository.Remover(enderecoId);
        }

        public void RemoverEndereco(Guid id)
        {
            _enderecoRepository.Remover(id);
        }

        public void Dispose()
        {
            _pessoaRepository.Dispose();
            _pessoaFisicaRepository.Dispose();
            _pessoaJuridicaRepository.Dispose();
            _enderecoRepository.Dispose();
            _pessoaFisica_EnderecoRepository.Dispose();
            _pessoaJuridica_EnderecoRepository.Dispose();
        }
    }
}
