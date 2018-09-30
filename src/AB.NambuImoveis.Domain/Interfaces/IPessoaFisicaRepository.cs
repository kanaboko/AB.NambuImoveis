using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Interfaces
{
    public interface IPessoaFisicaRepository: IRepository<PessoaFisica>, IRepositoryWrite<PessoaFisica>
    {
        PessoaFisica ObterPorCpf(string cpf);
        PessoaFisica ObterPorEmail(string email);

    }
}
