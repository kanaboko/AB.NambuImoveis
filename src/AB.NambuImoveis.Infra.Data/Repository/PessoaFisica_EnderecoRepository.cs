using AB.NambuImoveis.Domain.Interfaces;
using AB.NambuImoveis.Domain.Models;
using AB.NambuImoveis.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.Repository
{
    public class PessoaFisica_EnderecoRepository : Repository<PessoaFisica_Endereco>, IPessoaFisica_EnderecoRepository
    {
        public PessoaFisica_EnderecoRepository(NambuImoveisContext context): base(context)
        {

        }

        public override void Remover(Guid id)
        {
            var pessoaFisica_Endereco = DbSet.Where(src=>src.EnderecoId == id).FirstOrDefault();
            DbSet.Remove(pessoaFisica_Endereco);
        }
    }
}
