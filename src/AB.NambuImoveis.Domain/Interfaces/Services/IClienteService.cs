using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Interfaces.Services
{
    public interface IClienteService: IDisposable
    {
        Pessoa Adicionar(Pessoa pessoa);
        Pessoa Atualizar(Pessoa pessoa);
        PessoaFisica AtualizarPessoaFisica(PessoaFisica pessoa);
        PessoaJuridica AtualizarPessoaJuridica(PessoaJuridica pessoa);
        void Remover(Guid id);
        void Remover(Pessoa pessoa);
        Endereco Adicionar(Endereco endereco);
        Endereco Atualizar(Endereco endereco);
        void RemoverEndereco(Guid id);
        void RemoverPessoaFisica_Endereco(Guid enderecoId);
        void RemoverPessoaJuridica_Endereco(Guid enderecoId);
        void Adicionar(PessoaFisica_Endereco pessoaFisica_Endereco);
        void Adicionar(PessoaJuridica_Endereco pessoaJuridica_Endereco);


    }
}
