using AB.NambuImoveis.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.Interfaces
{
    public interface IClienteAppService: IDisposable
    {
        ClienteViewModel Adicionar(ClienteViewModel cliente);        
        PessoaViewModel ObterPorId(Guid id);
        PessoaViewModel ObterPorIdCompleto(Guid id);
        IEnumerable<PessoaViewModel> ObterTodos();
        PessoaViewModel Atualizar(PessoaViewModel pessoa);
        void Remover(Guid id);
        void Remover(PessoaViewModel pessoa);
        PessoaFisicaViewModel ObterPorIdPessoaFisica(Guid id);
        PessoaFisicaViewModel ObterPorCpf(string cpf);
        PessoaFisicaViewModel ObterPorEmail(string email);
        PessoaFisicaViewModel AtualizarPessoaFisica(PessoaFisicaViewModel pessoa);
        PessoaJuridicaViewModel ObterPorIdPessoaJuridica(Guid id);
        PessoaJuridicaViewModel ObterPorCnpj(string cnpj);
        PessoaJuridicaViewModel AtualizarPessoaJuridica(PessoaJuridicaViewModel pessoa);
        EnderecoViewModel Adicionar(EnderecoViewModel endereco);
        EnderecoViewModel Adicionar(EnderecoViewModel endereco, Guid id, string tipo);
        EnderecoViewModel ObterPorIdEndereco(Guid id);
        EnderecoViewModel Atualizar(EnderecoViewModel endereco);
        void RemoverEndereco(Guid id);
        void RemoverEndereco(Guid id, Guid pessoaId, string tipoPessoa);

        //Teste
        PessoaViewModel ObterPorIdPessoa(Guid id);
        PessoaViewModel ObterPorIdPessoaFisicaa(Guid id);
        PessoaViewModel ObterPorIdPessoaJuridicaa(Guid id);

    }
}
