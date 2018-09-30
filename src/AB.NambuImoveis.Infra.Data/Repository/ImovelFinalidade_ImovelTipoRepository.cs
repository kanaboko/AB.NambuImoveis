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
    public class ImovelFinalidade_ImovelTipoRepository : Repository<ImovelFinalidade_ImovelTipo>, IImovelFinalidade_ImovelTipoRepository
    {
        public ImovelFinalidade_ImovelTipoRepository(NambuImoveisContext context) : base(context)
        {
        }

        public override void Remover(Guid id)
        {
            var objRet = DbSet.Where(p => p.ImovelFinalidadeId == id);
            DbSet.RemoveRange(objRet);
            
        }

        public void AdicionarRange(ICollection<ImovelFinalidade_ImovelTipo> obj)
        {
            DbSet.AddRange(obj);
        }

        public void RemoverRange(ICollection<ImovelFinalidade_ImovelTipo> obj)
        {
            DbSet.RemoveRange(obj);
        }
    }
}
