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
    public class ImovelDetalheTipoRepository : Repository<ImovelDetalheTipo>, IImovelDetalheTipoRepository
    {
        public ImovelDetalheTipoRepository(NambuImoveisContext context) : base(context)
        {
        }

        public override IEnumerable<ImovelDetalheTipo> ObterTodos()
        {
            var con = Db.Database.Connection;
            var pessoa = new List<ImovelDetalheTipo>();
            var sql = "SELECT * FROM dbo.ImovelDetalheTipo t " +
                "LEFT JOIN dbo.ImovelDetalheTipo_DetalheBase f ON f.ImovelDetalheTipoId = t.Id " +
                "LEFT JOIN dbo.ImovelDetalheBase j ON j.Id = f.ImovelDetalheBaseId ";
            con.Query<ImovelDetalheTipo, ImovelDetalheBase, ImovelDetalheTipo>(sql, (p, f) =>
            {
                if (p != null && !pessoa.Exists(src => src.Id == p.Id))
                {
                    pessoa.Add(p);
                }
                if (pessoa.Count() > 0)
                {
                    for (int i = 0; i < pessoa.Count(); i++)
                    {
                        if (f != null && pessoa[i].Id == p.Id)
                        {
                            pessoa[i].ImovelDetalheBases.Add(f);
                        }                        
                    }
                }
                return pessoa.FirstOrDefault();
            });

            return pessoa;
        }

        public override ImovelDetalheTipo ObterPorId(Guid id)
        {
            var con = Db.Database.Connection;
            var imovelDetalheTipo = new List<ImovelDetalheTipo>();
            var sql = "SELECT * FROM dbo.ImovelDetalheTipo t " +
                "LEFT JOIN dbo.ImovelDetalheTipo_DetalheBase x ON x.ImovelDetalheTipoId = t.Id " +
                "LEFT JOIN dbo.ImovelDetalheBase b ON b.Id = x.ImovelDetalheBaseId " +
                "WHERE t.Id = @sid; ";
            con.Query<ImovelDetalheTipo, ImovelDetalheBase, ImovelDetalheTipo>(sql, (t, b) =>
            {
                if (t != null && !imovelDetalheTipo.Exists(src => src.Id == t.Id))
                {
                    imovelDetalheTipo.Add(t);
                }
                if (b != null)
                {
                    imovelDetalheTipo[0].ImovelDetalheBases.Add(b);
                }
                return imovelDetalheTipo.FirstOrDefault();
            }, new { sid = id });

            return imovelDetalheTipo.FirstOrDefault();
        }

        
    }
}
