using AB.NambuImoveis.Infra.Data.UoW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.Service
{
    public abstract class AppService
    {
        private readonly IUnitOfWork _uow;
        public AppService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public bool Commit()
        {
            return _uow.Commit() > 0;
        }
    }
}
