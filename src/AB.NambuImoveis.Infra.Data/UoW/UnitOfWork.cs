using AB.NambuImoveis.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly NambuImoveisContext _context;
        public UnitOfWork(NambuImoveisContext context)
        {
            _context = context;
        }
        public int Commit()
        {
            return _context.SaveChanges();
        }
    }
}
