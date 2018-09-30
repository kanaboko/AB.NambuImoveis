using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Interfaces
{
    public interface IImovelFinalidade_ImovelTipoRepository: IRepository<ImovelFinalidade_ImovelTipo>, IRepositoryWrite<ImovelFinalidade_ImovelTipo>
    {
        void RemoverRange(ICollection<ImovelFinalidade_ImovelTipo> obj);
        void AdicionarRange(ICollection<ImovelFinalidade_ImovelTipo> obj);
    }
}
