using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Interfaces
{
    public interface IProprietarioRepository: IRepository<Proprietario>, IRepositoryWrite<Proprietario>
    {
        void RemoverRange(ICollection<Proprietario> obj);
        void AdicionarRange(ICollection<Proprietario> obj);
    }
}
