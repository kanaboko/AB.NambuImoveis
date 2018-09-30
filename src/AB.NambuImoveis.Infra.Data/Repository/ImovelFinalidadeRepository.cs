using AB.NambuImoveis.Domain.Interfaces;
using AB.NambuImoveis.Domain.Models;
using AB.NambuImoveis.Infra.Data.Context;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.Repository
{
    public class ImovelFinalidadeRepository : Repository<ImovelFinalidade>, IImovelFinalidadeRepository
    {
        public ImovelFinalidadeRepository(NambuImoveisContext context) : base(context)
        {
        }

        public override IEnumerable<ImovelFinalidade> ObterTodos()
        {
            var con = Db.Database.Connection;
            var imovelFinalidade = new List<ImovelFinalidade>();
            var sql = "SELECT * FROM dbo.ImovelFinalidade f " +
                "LEFT JOIN dbo.ImovelFinalidade_ImovelTipo x ON x.ImovelFinalidadeId = f.Id " +
                "LEFT JOIN dbo.ImovelTipo t ON t.Id = x.ImovelTipoId;"; 
            con.Query<ImovelFinalidade, ImovelTipo, ImovelFinalidade>(sql, (f, t) =>
            {
                if (f != null && !imovelFinalidade.Exists(src => src.Id == f.Id))
                {
                    imovelFinalidade.Add(f);
                }
                if (imovelFinalidade.Count() > 0)
                {
                    for (int i = 0; i < imovelFinalidade.Count(); i++)
                    {
                        if (t != null && imovelFinalidade[i].Id == f.Id && !imovelFinalidade[i].ImovelTipos.ToList().Exists(p=>p.Id==t.Id))
                        {
                            imovelFinalidade[i].ImovelTipos.Add(t);
                        }
                    }
                }
                return imovelFinalidade.FirstOrDefault();
            });

            return imovelFinalidade;
        }

        public override ImovelFinalidade ObterPorId(Guid id)
        {
            var con = Db.Database.Connection;
            var imovelFinalidade = new List<ImovelFinalidade>();
            var sql = "SELECT * FROM dbo.ImovelFinalidade f " +
                 "LEFT JOIN dbo.ImovelFinalidade_ImovelTipo ft ON ft.ImovelFinalidadeId = f.Id " +
                 "LEFT JOIN dbo.ImovelTipo t ON t.Id = ft.ImovelTipoId " +
                 "WHERE f.Id = @sid; ";
            con.Query<ImovelFinalidade, ImovelTipo, ImovelFinalidade>(sql, (f, t) =>
            {
                if (f != null && !imovelFinalidade.Exists(src => src.Id == f.Id))
                {
                    imovelFinalidade.Add(f);
                }
                if (imovelFinalidade.Count() > 0)
                {
                    for (int i = 0; i < imovelFinalidade.Count(); i++)
                    {
                        if (t != null && imovelFinalidade[i].Id == f.Id && !imovelFinalidade[i].ImovelTipos.ToList().Exists(p => p.Id == t.Id))
                        {
                            imovelFinalidade[i].ImovelTipos.Add(t);
                        }
                    }
                }
                return imovelFinalidade.FirstOrDefault();
            }, new { sid = id });

            return imovelFinalidade.FirstOrDefault();
        }

        //public IEnumerable<ImovelFinalidade> ObterTodosCompleto()
        //{
        //    var con = Db.Database.Connection;
        //    var imovelFinalidade = new List<ImovelFinalidade>();
        //    var sql = "SELECT * FROM dbo.ImovelFinalidade f" +
        //        "LEFT JOIN dbo.ImovelFinalidade_ImovelTipo ft ON ft.ImovelFinalidadeId = f.Id " +
        //        "LEFT JOIN dbo.ImoveTipo_DetalheTipo_DetalheBase ttb ON ttb.ImovelTipoId = ft.ImovelTipoId " +
        //        "LEFT JOIN dbo.ImovelTipo t ON t.Id = ttb.ImovelTipoId " +
        //        "LEFT JOIN dbo.ImovelDetalheTipo dt ON dt.Id = ttb.ImovelDetalheTipoId " +
        //        "LEFT JOIN dbo.ImovelDetalheBase db ON db.Id = ttb.ImovelDetalheBase";
        //    con.Query<ImovelFinalidade, ImovelTipo, ImovelFinalidade>(sql, (p, f) =>
        //    {
        //        if (p != null && !imovelFinalidade.Exists(src => src.Id == p.Id))
        //        {
        //            imovelFinalidade.Add(p);
        //        }
        //        if (imovelFinalidade.Count() > 0)
        //        {
        //            for (int i = 0; i < imovelFinalidade.Count(); i++)
        //            {
        //                if (f != null && imovelFinalidade[i].Id == p.Id)
        //                {
        //                    imovelFinalidade[i].ImovelTipos.Add(f);
        //                }
        //            }
        //        }
        //        return imovelFinalidade.FirstOrDefault();
        //    });

        //    return imovelFinalidade;
        //}
    }
}
