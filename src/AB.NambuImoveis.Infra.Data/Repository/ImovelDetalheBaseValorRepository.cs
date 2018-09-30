using AB.NambuImoveis.Domain.Interfaces;
using AB.NambuImoveis.Domain.Models;
using AB.NambuImoveis.Infra.Data.Context;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.Repository
{
    public class ImovelDetalheBaseValorRepository : Repository<ImovelDetalheBaseValor>, IImovelDetalheBaseValorRepository
    {
        public ImovelDetalheBaseValorRepository(NambuImoveisContext context): base(context)
        {

        }

        public override ImovelDetalheBaseValor ObterPorId(Guid id)
        {
            var con = Db.Database.Connection;
            var sql = "SELECT * FROM dbo.ImovelDetalheBaseValor i " +
                "WHERE i.Id = @sid";
            var objRet = con.QuerySingle<ImovelDetalheBaseValor>(sql, new { sid = id });
            return objRet;
        }

        public override IEnumerable<ImovelDetalheBaseValor> ObterTodos()
        {
            var con = Db.Database.Connection;
            var sql = "SELECT * FROM dbo.ImovelDetalheBaseValor";
            var objRet = con.Query<ImovelDetalheBaseValor>(sql);
            return objRet;
        }

        
        public void RemoverRange(ICollection<ImovelDetalheBaseValor> obj)
        {
            DbSet.RemoveRange(obj);
        }

        public void AdicionarRange(ICollection<ImovelDetalheBaseValor> obj)
        {
            DbSet.AddRange(obj);
        }
    }
}
