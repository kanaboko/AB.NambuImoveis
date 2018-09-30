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
    public class ProprietarioRepository: Repository<Proprietario>, IProprietarioRepository
    {
        public ProprietarioRepository(NambuImoveisContext context) : base(context)
        {

        }

        public void AdicionarRange(ICollection<Proprietario> obj)
        {
            DbSet.AddRange(obj);
        }

        public void RemoverRange(ICollection<Proprietario> obj)
        {
            DbSet.RemoveRange(obj);
        }
    }
}
