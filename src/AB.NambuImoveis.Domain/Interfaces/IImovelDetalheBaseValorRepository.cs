using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Interfaces
{
    public interface IImovelDetalheBaseValorRepository: IRepository<ImovelDetalheBaseValor>, IRepositoryWrite<ImovelDetalheBaseValor>
    {
        void RemoverRange(ICollection<ImovelDetalheBaseValor> obj);
        void AdicionarRange(ICollection<ImovelDetalheBaseValor> obj);
    }
}
