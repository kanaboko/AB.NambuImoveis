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
    public class ImovelRepository: Repository<Imovel>, IImovelRepository
    {
        public ImovelRepository(NambuImoveisContext context): base(context)
        {

        }

        public override IEnumerable<Imovel> ObterTodos()
        {
            var con = Db.Database.Connection;
            var imovel = new List<Imovel>();
            var sql = "SELECT * FROM dbo.Imoveis i " +
                "LEFT JOIN dbo.Enderecos e ON e.Id = i.Id " + 
                "LEFT JOIN dbo.Imovel_Proprietarios ip ON ip.ImovelId = i.Id " + 
                "LEFT JOIN dbo.Proprietarios p ON p.Id = ip.ProprietarioId;";
            con.Query<Imovel, Endereco, Proprietario, Imovel>(sql, (i, e, p) =>
            {
                if (i != null && !imovel.Exists(src => src.Id == i.Id))
                {
                    imovel.Add(i);
                }
                if (imovel.Count() > 0)
                {
                    for (int c = 0; c < imovel.Count(); c++)
                    {
                        if (p != null && imovel[c].Id == i.Id && !imovel[c].Proprietarios.ToList().Exists(src => src.Id == p.Id))
                        {
                            imovel[c].Proprietarios.Add(p);
                        }

                        if (e != null && imovel[c].Id == e.Id)
                        {
                            imovel[c].Endereco = e;
                        }
                       
                    }
                }
                return imovel.FirstOrDefault();
            });

            return imovel;
        }

        public override Imovel ObterPorId(Guid id)
        {

            var con = Db.Database.Connection;
            var imovel = new List<Imovel>();
            var sql = "SELECT * FROM dbo.Imoveis i " +
                "LEFT JOIN dbo.Enderecos e ON e.Id = i.Id " +
                "LEFT JOIN dbo.Imovel_Proprietarios ip ON ip.ImovelId = i.Id " +
                "LEFT JOIN dbo.Proprietarios p ON p.Id = ip.ProprietarioId " +
                "WHERE i.Id = @sid; ";
            con.Query<Imovel, Endereco, Proprietario, Imovel>(sql, (i, e, p) =>
            {
                if (i != null && !imovel.Exists(src => src.Id == i.Id))
                {
                    imovel.Add(i);
                }
                if (e != null)
                {
                    imovel[0].Endereco = e;
                }
                if (p != null)
                {
                    imovel[0].Proprietarios.Add(p);

                }
                return imovel.FirstOrDefault();
            }, new { sid = id });

            return imovel.FirstOrDefault();
        }
    }
}
