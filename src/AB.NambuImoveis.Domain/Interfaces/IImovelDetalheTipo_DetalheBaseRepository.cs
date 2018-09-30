using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Interfaces
{
    public interface IImovelDetalheTipo_DetalheBaseRepository: IRepository<ImovelDetalheTipo_DetalheBase>, IRepositoryWrite<ImovelDetalheTipo_DetalheBase>
    {
        void RemoverRange(ICollection<ImovelDetalheTipo_DetalheBase> obj);
        void AdicionarRange(ICollection<ImovelDetalheTipo_DetalheBase> obj);
    }
}
