using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Interfaces
{
    public interface IImovelTipo_DetalheTipo_DetalheBaseRepository: IRepository<ImovelTipo_DetalheTipo_DetalheBase>, IRepositoryWrite<ImovelTipo_DetalheTipo_DetalheBase>
    {
        void RemoverRange(ICollection<ImovelTipo_DetalheTipo_DetalheBase> obj);
        void AdicionarRange(ICollection<ImovelTipo_DetalheTipo_DetalheBase> obj);

    }
}
