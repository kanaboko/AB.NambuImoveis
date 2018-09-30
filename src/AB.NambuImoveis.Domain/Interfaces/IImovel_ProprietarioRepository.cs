using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Interfaces
{
    public interface IImovel_ProprietarioRepository: IRepository<Imovel_Proprietario>, IRepositoryWrite<Imovel_Proprietario>
    {
        void RemoverRange(ICollection<Imovel_Proprietario> obj);
        void AdicionarRange(ICollection<Imovel_Proprietario> obj);
    }
}
