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
    public class EnderecoRepository: Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(NambuImoveisContext context): base(context)
        {

        }

        public override Endereco ObterPorId(Guid id)
        {
            var con = Db.Database.Connection;
            var sql = "SELECT * FROM dbo.Enderecos e " +
                "WHERE e.Id = @sid; ";
            var endereco = con.QuerySingle<Endereco>(sql, new { sid = id });

            return endereco;
        }
    }
}
