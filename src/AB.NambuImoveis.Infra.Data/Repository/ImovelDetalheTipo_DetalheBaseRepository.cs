using AB.NambuImoveis.Domain.Interfaces;
using AB.NambuImoveis.Domain.Models;
using AB.NambuImoveis.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.Repository
{
    public class ImovelDetalheTipo_DetalheBaseRepository : Repository<ImovelDetalheTipo_DetalheBase>, IImovelDetalheTipo_DetalheBaseRepository
    {
        public ImovelDetalheTipo_DetalheBaseRepository(NambuImoveisContext context) : base(context)
        {
        }

        public override void Remover(Guid id)
        {
            var imovelDetalheTipo_DetalheBase = DbSet.Where(p => p.ImovelDetalheTipoId == id);
            DbSet.RemoveRange(imovelDetalheTipo_DetalheBase);
        }

        public void RemoverRange(ICollection<ImovelDetalheTipo_DetalheBase> obj)
        {
            DbSet.RemoveRange(obj);
        }

        public void AdicionarRange(ICollection<ImovelDetalheTipo_DetalheBase> obj)
        {
            DbSet.AddRange(obj);
        }
    }
}
