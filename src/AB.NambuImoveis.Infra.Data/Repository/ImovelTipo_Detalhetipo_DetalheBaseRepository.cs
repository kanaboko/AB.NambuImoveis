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
    public class ImovelTipo_Detalhetipo_DetalheBaseRepository : Repository<ImovelTipo_DetalheTipo_DetalheBase>, IImovelTipo_DetalheTipo_DetalheBaseRepository
    {
        public ImovelTipo_Detalhetipo_DetalheBaseRepository(NambuImoveisContext context) : base(context)
        {
        }

        public override void Remover(Guid id)
        {
            var imovelTipo_DetalheTipo_DetalheBase = DbSet.Where(p => p.ImovelDetalheTipoId == id);
            DbSet.RemoveRange(imovelTipo_DetalheTipo_DetalheBase);
        }

        public void RemoverRange(ICollection<ImovelTipo_DetalheTipo_DetalheBase> obj)
        {
            DbSet.RemoveRange(obj);
        }

        public void AdicionarRange(ICollection<ImovelTipo_DetalheTipo_DetalheBase> obj)
        {
            DbSet.AddRange(obj);
        }
    }
}
