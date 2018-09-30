using AB.NambuImoveis.Domain.Interfaces;
using AB.NambuImoveis.Domain.Models;
using AB.NambuImoveis.Infra.Data.Context;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.Repository
{
    public class ImovelDetalheBaseRepository : Repository<ImovelDetalheBase>, IImovelDetalheBaseRepository
    {
        public ImovelDetalheBaseRepository(NambuImoveisContext context) : base(context)
        {
        }

        public override ImovelDetalheBase ObterPorId(Guid id)
        {
            var con = Db.Database.Connection;
            var sql = "SELECT * FROM dbo.ImovelDetalheBase b " +
                "WHERE b.Id = @sid; ";
            var objRet = con.QuerySingle<ImovelDetalheBase>(sql, new { sid = id });
            return objRet;
        }

        public override IEnumerable<ImovelDetalheBase> ObterTodos()
        {
            var con = Db.Database.Connection;
            var sql = "SELECT * FROM dbo.ImovelDetalheBase;";
            var objRet = con.Query<ImovelDetalheBase>(sql);
            return objRet;
        }
    }
}
