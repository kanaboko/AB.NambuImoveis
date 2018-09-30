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
    public class PessoaJuridicaRepository: Repository<PessoaJuridica>, IPessoaJuridicaRepository
    {
        public PessoaJuridicaRepository(NambuImoveisContext context): base(context)
        {

        }

        public override PessoaJuridica ObterPorId(Guid id)
        {

            var con = Db.Database.Connection;
            var pessoaJuridica = new List<PessoaJuridica>();
            var sql = "SELECT * FROM dbo.Pessoas_Juridicas f " +
                "LEFT JOIN dbo.PessoaJuridicas_Enderecos x ON x.PessoaJuridicaId = f.Id " +
                "LEFT JOIN dbo.Enderecos e ON e.Id = x.EnderecoId " +
                "WHERE f.Id = @sid; ";
            con.Query<PessoaJuridica, Endereco, PessoaJuridica>(sql, (f, e) =>
            {
                if (f != null && !pessoaJuridica.Exists(src => src.Id == f.Id))
                {
                    pessoaJuridica.Add(f);
                }
                if (e != null)
                {
                    pessoaJuridica[0].AdicionarEndereco(e);
                }
                return pessoaJuridica.FirstOrDefault();
            }, new { sid = id });

            return pessoaJuridica.FirstOrDefault();
        }

        public PessoaJuridica ObterPorCnpj(string cnpj)
        {
            var con = Db.Database.Connection;
            var pessoaJuridica = new List<PessoaJuridica>();
            var sql = "SELECT * FROM dbo.Pessoas_Juridicas f " +
                "LEFT JOIN dbo.PessoaJuridicas_Enderecos x ON x.PessoaJuridicaId = f.Id " +
                "LEFT JOIN dbo.Enderecos e ON e.Id = x.EnderecoId " +
                "WHERE f.Cnpj = @scnpj; ";
            con.Query<PessoaJuridica, Endereco, PessoaJuridica>(sql, (f, e) =>
            {
                if (f != null && !pessoaJuridica.Exists(src => src.Id == f.Id))
                {
                    pessoaJuridica.Add(f);
                }
                if (e != null)
                {
                    pessoaJuridica[0].AdicionarEndereco(e);
                }
                return pessoaJuridica.FirstOrDefault();
            }, new { scnpj = cnpj });

            return pessoaJuridica.FirstOrDefault();
        }
    }
}
