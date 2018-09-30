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
    public class PessoaFisicaRepository: Repository<PessoaFisica>, IPessoaFisicaRepository
    {
        public PessoaFisicaRepository(NambuImoveisContext context): base(context)
        {

        }

        public override PessoaFisica ObterPorId(Guid id)
        {

            var con = Db.Database.Connection;
            var pessoaFisica = new List<PessoaFisica>();
            var sql = "SELECT * FROM dbo.Pessoas_Fisicas f " +
                "LEFT JOIN dbo.PessoaFisicas_Enderecos x ON x.PessoaFisicaId = f.Id " +
                "LEFT JOIN dbo.Enderecos e ON e.Id = x.EnderecoId " +
                "WHERE f.Id = @sid; ";
            con.Query<PessoaFisica, Endereco, PessoaFisica>(sql, (f, e) =>
            {
                if (f != null && !pessoaFisica.Exists(src => src.Id == f.Id))
                {
                    pessoaFisica.Add(f);
                }
                if (e != null)
                {
                    pessoaFisica[0].AdicionarEndereco(e);
                }
                return pessoaFisica.FirstOrDefault();
            }, new { sid = id });

            return pessoaFisica.FirstOrDefault();
        }

        public PessoaFisica ObterPorCpf(string cpf)
        {
            var con = Db.Database.Connection;
            var pessoaFisica = new List<PessoaFisica>();
            var sql = "SELECT * FROM dbo.Pessoas_Fisicas f " +
                "LEFT JOIN dbo.PessoaFisicas_Enderecos x ON x.PessoaFisicaId = f.Id " +
                "LEFT JOIN dbo.Enderecos e ON e.Id = x.EnderecoId " +
                "WHERE f.Cpf = @scpf; ";
            con.Query<PessoaFisica, Endereco, PessoaFisica>(sql, (f, e) =>
            {
                if (f != null && !pessoaFisica.Exists(src => src.Id == f.Id))
                {
                    pessoaFisica.Add(f);
                }
                if (e != null)
                {
                    pessoaFisica[0].AdicionarEndereco(e);
                }
                return pessoaFisica.FirstOrDefault();
            }, new { scpf = cpf });

            return pessoaFisica.FirstOrDefault();
        }

        public PessoaFisica ObterPorEmail(string email)
        {
            var con = Db.Database.Connection;
            var pessoaFisica = new List<PessoaFisica>();
            var sql = "SELECT * FROM dbo.Pessoas_Fisicas f " +
                "LEFT JOIN dbo.PessoaFisicas_Enderecos x ON x.PessoaFisicaId = f.Id " +
                "LEFT JOIN dbo.Enderecos e ON e.Id = x.EnderecoId " +
                "WHERE f.Email = @semail; ";
            con.Query<PessoaFisica, Endereco, PessoaFisica>(sql, (f, e) =>
            {
                if (f != null && !pessoaFisica.Exists(src => src.Id == f.Id))
                {
                    pessoaFisica.Add(f);
                }
                if (e != null)
                {
                    pessoaFisica[0].AdicionarEndereco(e);
                }
                return pessoaFisica.FirstOrDefault();
            }, new { semail = email });

            return pessoaFisica.FirstOrDefault();
        }
    }
}
