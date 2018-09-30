using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Interfaces
{
    public interface IPessoaJuridica_EnderecoRepository: IRepository<PessoaJuridica_Endereco>, IRepositoryWrite<PessoaJuridica_Endereco>
    {
    }
}
