using AB.NambuImoveis.Domain.Interfaces;
using AB.NambuImoveis.Domain.Models;
using AB.NambuImoveis.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Infra.Data.Repository
{
    public class PessoaJuridica_EnderecoRepository: Repository<PessoaJuridica_Endereco>, IPessoaJuridica_EnderecoRepository
    {
        public PessoaJuridica_EnderecoRepository(NambuImoveisContext context): base(context)
        {

        }

        public override void Remover(Guid id)
        {
            var pessoaJuridica_Endereco = DbSet.Where(src => src.EnderecoId == id).FirstOrDefault();
            DbSet.Remove(pessoaJuridica_Endereco);
        }
    }
}
