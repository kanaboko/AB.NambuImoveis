using AB.NambuImoveis.Application.Interfaces;
using AB.NambuImoveis.Application.Service;
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

namespace AB.NambuImoveis.Application.Services
{
    public class ClienteAppService : AppService, IClienteAppService
    {
        private PessoaViewModel pessoa = new PessoaViewModel();

        protected readonly IClienteService _clienteService;
        protected readonly IPessoaRepository _pessoaRepository;
        protected readonly IPessoaJuridicaRepository _pessoaJuridicaRepository;
        protected readonly IPessoaFisicaRepository _pessoaFisicaRepository;
        protected readonly IEnderecoRepository _enderecoRepository;

        public ClienteAppService(IClienteService clienteService, IPessoaRepository pessoaRepository
            ,IPessoaFisicaRepository pessoaFisicaRepository, IPessoaJuridicaRepository pessoaJuridicaRepository
            ,IEnderecoRepository enderecoRepository, IUnitOfWork uow): base(uow)
        {
            _clienteService = clienteService;
            _pessoaRepository = pessoaRepository;
            _pessoaFisicaRepository = pessoaFisicaRepository;
            _pessoaJuridicaRepository = pessoaJuridicaRepository;
            _enderecoRepository = enderecoRepository;
        }

        public ClienteViewModel Adicionar(ClienteViewModel cliente)
        {
            var pessoa = Mapper.Map<Pessoa>(cliente.Pessoa);
            var endereco = Mapper.Map<Endereco>(cliente.Endereco);
            

            switch (pessoa.TipoPessoa)
            {
                case TipoPessoa.PessoaFisica:
                    var pessoaFisica = Mapper.Map<PessoaFisica>(cliente.PessoaFisica);
                    pessoaFisica.AdicionarEndereco(endereco);
                    pessoa.PessoaFisica = pessoaFisica;                    
                    //var clienteReturn = _clienteService.Adicionar(pessoa);
                    //if (SalvarImagemCliente(cliente.Foto2, pessoa.Id))
                    //{
                    //    break;
                    //}
                    break;
                case TipoPessoa.PessoaJuridica:
                    var pessoaJuridica = Mapper.Map<PessoaJuridica>(cliente.PessoaJuridica);
                    pessoaJuridica.AdicionarEndereco(endereco);
                    pessoa.PessoaJuridica = pessoaJuridica;
                    //var _clienteService.Adicionar(pessoa);
                    //SalvarImagemCliente(cliente.Foto2, pessoa.Id);
                    break;
                default:

                    break;
            }

            cliente.Pessoa = Mapper.Map<PessoaViewModel>(_clienteService.Adicionar(pessoa));
            if (!Commit())
            {
                //gravar erro
            }

            return cliente;

        }

        public EnderecoViewModel Adicionar(EnderecoViewModel endereco)
        {
            throw new NotImplementedException();
        }

        public EnderecoViewModel Adicionar(EnderecoViewModel endereco, Guid pessoaId, string tipoPessoa = null)
        {
            
            switch (tipoPessoa)
            {
                case "PessoaFisica":
                    _clienteService.Adicionar(new PessoaFisica_Endereco() { PessoaFisicaId = pessoaId, EnderecoId = endereco.Id });
                    break;
                case "PessoaJuridica":
                    _clienteService.Adicionar(new PessoaJuridica_Endereco() { PessoaJuridicaId = pessoaId, EnderecoId = endereco.Id });
                    break;
                default:
                    break;
            }
            var enderecoReturn = _clienteService.Adicionar(Mapper.Map<Endereco>(endereco));
            if (!Commit())
            {

            }

            return endereco;
        }

        public PessoaViewModel Atualizar(PessoaViewModel pessoa)
        {
            return Mapper.Map<PessoaViewModel>(_clienteService.Atualizar(Mapper.Map<Pessoa>(pessoa)));
        }

        public EnderecoViewModel Atualizar(EnderecoViewModel endereco)
        {
            endereco = Mapper.Map<EnderecoViewModel>(_clienteService.Atualizar(Mapper.Map<Endereco>(endereco)));
            if (!Commit())
            {
                return null;
            }
            return endereco;
        }

        public PessoaFisicaViewModel AtualizarPessoaFisica(PessoaFisicaViewModel pessoa)
        {
            pessoa = Mapper.Map<PessoaFisicaViewModel>(_clienteService.AtualizarPessoaFisica(Mapper.Map<PessoaFisica>(pessoa)));
            if (!Commit())
            {
                return null;
            }
            return pessoa;
        }

        public PessoaJuridicaViewModel AtualizarPessoaJuridica(PessoaJuridicaViewModel pessoa)
        {
            pessoa = Mapper.Map<PessoaJuridicaViewModel>(_clienteService.AtualizarPessoaJuridica(Mapper.Map<PessoaJuridica>(pessoa)));
            if (!Commit())
            {
                return null;
            }
            return pessoa;
        }        

        public PessoaJuridicaViewModel ObterPorCnpj(string cnpj)
        {
            return Mapper.Map<PessoaJuridicaViewModel>(_pessoaJuridicaRepository.ObterPorCnpj(cnpj));
        }

        public PessoaFisicaViewModel ObterPorCpf(string cpf)
        {
            return Mapper.Map<PessoaFisicaViewModel>(_pessoaFisicaRepository.ObterPorCpf(cpf));
        }

        public PessoaFisicaViewModel ObterPorEmail(string email)
        {
            return Mapper.Map<PessoaFisicaViewModel>(_pessoaFisicaRepository.ObterPorEmail(email));
        }

        public PessoaViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<PessoaViewModel>(_pessoaRepository.ObterPorId(id));
        }

        public PessoaViewModel ObterPorIdCompleto(Guid id)
        {
            return Mapper.Map<PessoaViewModel>(_pessoaRepository.ObterPorIdCompleto(id));
        }

        public EnderecoViewModel ObterPorIdEndereco(Guid id)
        {
            return Mapper.Map<EnderecoViewModel>(_enderecoRepository.ObterPorId(id));
        }

        public PessoaFisicaViewModel ObterPorIdPessoaFisica(Guid id)
        {
            return Mapper.Map<PessoaFisicaViewModel>(_pessoaFisicaRepository.ObterPorId(id));
        }

        public PessoaJuridicaViewModel ObterPorIdPessoaJuridica(Guid id)
        {
            return Mapper.Map<PessoaJuridicaViewModel>(_pessoaJuridicaRepository.ObterPorId(id));
        }

        public IEnumerable<PessoaViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<PessoaViewModel>>(_pessoaRepository.ObterTodos());
        }

        public void Remover(Guid id)
        {
            _clienteService.Remover(id);
        }

        public void Remover(PessoaViewModel pessoa)
        {
            _clienteService.Remover(Mapper.Map<Pessoa>(pessoa));
            Commit();
        }

        public void RemoverEndereco(Guid id)
        {
            _clienteService.RemoverEndereco(id);
            Commit();
        }

        public void RemoverEndereco(Guid id, Guid pessoaId, string tipoPessoa)
        {
            switch (tipoPessoa)
            {
                case "PessoaFisica":
                    _clienteService.RemoverPessoaFisica_Endereco(id);
                    break;
                case "PessoaJuridica":
                    _clienteService.RemoverPessoaJuridica_Endereco(id);
                    break;
                default:
                    break;
            }
            _clienteService.RemoverEndereco(id);
            Commit();
        }

        public void Dispose()
        {
            _clienteService.Dispose();
            _pessoaFisicaRepository.Dispose();
            _pessoaJuridicaRepository.Dispose();
            _pessoaRepository.Dispose();
            _enderecoRepository.Dispose();
        }

        public PessoaViewModel ObterPorIdPessoa(Guid id)
        {
            pessoa = Mapper.Map<PessoaViewModel>(_pessoaRepository.ObterPorId(id));
            return pessoa;
        }

        public PessoaViewModel ObterPorIdPessoaFisicaa(Guid id)
        {
            pessoa.PessoaFisica = Mapper.Map<PessoaFisicaViewModel>(_pessoaFisicaRepository.ObterPorId(id));
            return pessoa;
        }

        public PessoaViewModel ObterPorIdPessoaJuridicaa(Guid id)
        {
            pessoa.PessoaJuridica = Mapper.Map<PessoaJuridicaViewModel>(_pessoaJuridicaRepository.ObterPorId(id));
            return pessoa;
        }
    }
}
