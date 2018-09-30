using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Interfaces
{
    public interface IPessoaRepository : IRepository<Pessoa>, IRepositoryWrite<Pessoa>
    {
        Pessoa ObterPorIdCompleto(Guid id);
    }
}
