using AB.NambuImoveis.Domain.Interfaces;
using AB.NambuImoveis.Domain.Models;
using AB.NambuImoveis.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.Repository
{
    public class PessoaRepository : Repository<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(NambuImoveisContext context) : base(context)
        {

        }

        public override IEnumerable<Pessoa> ObterTodos()
        {
            var con = Db.Database.Connection;
            var pessoa = new List<Pessoa>();
            var sql = "SELECT * FROM dbo.Pessoas p " +
                "LEFT JOIN dbo.Pessoas_Fisicas f ON f.Id = p.Id " +
                "LEFT JOIN dbo.Pessoas_Juridicas j ON j.Id = p.Id ";
            con.Query<Pessoa, PessoaFisica, PessoaJuridica, Pessoa>(sql, (p, f, j) =>
            {
                if (p != null && !pessoa.Exists(src => src.Id == p.Id))
                {
                    pessoa.Add(p);
                }
                if (pessoa.Count() > 0)
                {
                    for (int i = 0; i < pessoa.Count(); i++)
                    {
                        if (f != null && pessoa[i].Id == f.Id)
                        {
                            pessoa[i].PessoaFisica = f;
                        }
                        if (j != null && pessoa[i].Id == j.Id)
                        {
                            pessoa[i].PessoaJuridica = j;
                        }
                    }
                }
                return pessoa.FirstOrDefault();
            });

            return pessoa;
        }

        public override Pessoa ObterPorId(Guid id)
        {
            var con = Db.Database.Connection;

            var sql = "SELECT * FROM dbo.Pessoas p " +
                "WHERE p.Id = @sid;";
            var pessoa = con.QuerySingle<Pessoa>(sql, new { sid = id });

            return pessoa;
        }

        public Pessoa ObterPorIdCompleto(Guid id)
        {

            var con = Db.Database.Connection;
            var pessoa = new List<Pessoa>();
            var sql = "SELECT * FROM dbo.Pessoas p " +
                "LEFT JOIN dbo.Pessoas_Juridicas j ON j.Id = p.Id " +
                "LEFT JOIN dbo.PessoaJuridicas_Enderecos x ON x.PessoaJuridicaId = p.Id " +
                "LEFT JOIN dbo.Enderecos e ON e.Id = x.EnderecoId " +
                "WHERE p.Id = @sid;" +
                "SELECT * FROM dbo.Pessoas p " +
                "LEFT JOIN dbo.Pessoas_Fisicas j ON j.Id = p.Id " +
                "LEFT JOIN dbo.PessoaFisicas_Enderecos x ON x.PessoaFisicaId = p.Id " +
                "LEFT JOIN dbo.Enderecos e ON e.Id = x.EnderecoId " +
                "WHERE p.Id = @sid;";
            using (var mult = con.QueryMultiple(sql, new { sid = id }))
            {
                var juridicoReturn = mult.Read<Pessoa, PessoaJuridica, Endereco, Pessoa>( (p, j, e) =>
                {
                    if (p != null && !pessoa.Exists(src => src.Id == p.Id))
                    {
                        pessoa.Add(p);
                    }
                    if (j != null && !pessoa.Exists(src => src.PessoaJuridica != null))
                    {
                        pessoa[0].PessoaJuridica = j;
                    }
                    if (e != null)
                    {
                        pessoa[0].PessoaJuridica.AdicionarEndereco(e);
                    }
                    return pessoa.FirstOrDefault();
                });
                var fisicoReturn = mult.Read<Pessoa, PessoaFisica, Endereco, Pessoa>( (p, f, e) =>
                {
                    if (p != null && !pessoa.Exists(src => src.Id == p.Id))
                    {
                        pessoa.Add(p);
                    }
                    if (f != null && !pessoa.Exists(src => src.PessoaFisica != null))
                    {
                        pessoa[0].PessoaFisica = f;
                    }
                    if (e != null)
                    {
                        pessoa[0].PessoaFisica.AdicionarEndereco(e);
                    }
                    return pessoa.FirstOrDefault();
                });


            }
            return pessoa.FirstOrDefault();

        }


    }
}
