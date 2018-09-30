using AB.NambuImoveis.Domain.Interfaces;
using AB.NambuImoveis.Domain.Models;
using AB.NambuImoveis.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.Repository
{
    public class ImovelTipoRepository : Repository<ImovelTipo>, IImovelTipoRepository
    {
        public ImovelTipoRepository(NambuImoveisContext context) : base(context)
        {
        }
        public override IEnumerable<ImovelTipo> ObterTodos()
        {
            var con = Db.Database.Connection;
            var imovelTipo = new List<ImovelTipo>();
            var sql = "SELECT * FROM dbo.ImovelTipo t " +
                "LEFT JOIN dbo.ImovelTipo_DetalheTipo_DetalheBase f ON f.ImovelTipoId = t.Id " +
                "LEFT JOIN dbo.ImovelDetalheTipo d ON d.Id = f.ImovelDetalheTipoId " +
                "LEFT JOIN dbo.ImovelDetalheBase b ON b.Id = f.ImovelDetalheBaseId ";
            con.Query<ImovelTipo, ImovelDetalheTipo, ImovelDetalheBase, ImovelTipo>(sql, (t, d, b) =>
            {
                if (t != null && !imovelTipo.Exists(src => src.Id == t.Id))
                {
                    imovelTipo.Add(t);
                }
                if (imovelTipo.Count() > 0)
                {
                    for (int i = 0; i < imovelTipo.Count(); i++)
                    {
                        if (d != null && imovelTipo[i].Id == t.Id && !imovelTipo[i].ImovelDetalheTipos.ToList().Exists(src=>src.Id == d.Id) )
                        {
                            imovelTipo[i].ImovelDetalheTipos.Add(d);
                        }
                        if (imovelTipo[i].ImovelDetalheTipos.Count > 0)
                        {
                            for (int j = 0; j < imovelTipo[i].ImovelDetalheTipos.Count(); j++)
                            {                             

                                    if (b != null && imovelTipo[i].Id == t.Id && imovelTipo[i].ImovelDetalheTipos.ToList()[j].Id == d.Id)// Erro, não reconhece porque não é List, é um ICollection
                                    {
                                        imovelTipo[i].ImovelDetalheTipos.ToList()[j].ImovelDetalheBases.Add(b);
                                    }

                            } 
                        }
                    }
                }
                
                return imovelTipo.FirstOrDefault();
            });

            return imovelTipo;
        }

        public override ImovelTipo ObterPorId(Guid id)
        {
            var con = Db.Database.Connection;
            var imovelTipo = new List<ImovelTipo>();
            var sql = "SELECT * FROM dbo.ImovelTipo t " +
                "LEFT JOIN dbo.ImovelTipo_DetalheTipo_DetalheBase f ON f.ImovelTipoId = t.Id " +
                "LEFT JOIN dbo.ImovelDetalheTipo d ON d.Id = f.ImovelDetalheTipoId " +
                "LEFT JOIN dbo.ImovelDetalheBase b ON b.Id = f.ImovelDetalheBaseId " +
                "WHERE t.Id = @sid; ";
            con.Query<ImovelTipo, ImovelDetalheTipo, ImovelDetalheBase, ImovelTipo>(sql, (t, dt, b) =>
            {
                if (t != null && !imovelTipo.Exists(src => src.Id == t.Id))
                {
                    imovelTipo.Add(t);
                }
                if (dt != null && !imovelTipo[0].ImovelDetalheTipos.Contains(dt))
                {
                    imovelTipo[0].ImovelDetalheTipos.Add(dt);
                }
                if (imovelTipo[0].ImovelDetalheTipos.Count() > 0)
                {
                    for (int i = 0; i < imovelTipo[0].ImovelDetalheTipos.Count(); i++)
                    {
                        if (b != null && imovelTipo[0].ImovelDetalheTipos.ToList()[i].Id == dt.Id)
                        {
                            imovelTipo[0].ImovelDetalheTipos.ToList()[i].ImovelDetalheBases.Add(b);
                        }
                    }
                }
                return imovelTipo.FirstOrDefault();
            }, new { sid = id });

            return imovelTipo.FirstOrDefault();
        }
    }
}
