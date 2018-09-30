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
    public class Imovel_ProprietarioRepository: Repository<Imovel_Proprietario>, IImovel_ProprietarioRepository
    {
        public Imovel_ProprietarioRepository(NambuImoveisContext context): base(context)
        {

        }

        public override void Remover(Guid id)
        {
            var imovel_Proprietario = DbSet.Where(p => p.ImovelId == id);
            DbSet.RemoveRange(imovel_Proprietario);
        }

        public void RemoverRange(ICollection<Imovel_Proprietario> obj)
        {
            DbSet.RemoveRange(obj);
        }

        public void AdicionarRange(ICollection<Imovel_Proprietario> obj)
        {
            DbSet.AddRange(obj);
        }
    }
}
