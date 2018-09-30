using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Interfaces.Services
{
    public interface IImovelDetalheBaseValorService: IDisposable
    {
        ImovelDetalheBaseValor Adicionar(ImovelDetalheBaseValor obj);
        ImovelDetalheBaseValor Atualizar(ImovelDetalheBaseValor obj);
        ImovelDetalheBaseValor ObterPorId(Guid id);
        IEnumerable<ImovelDetalheBaseValor> ObterTodos();
        void Remover(Guid id);
        void Remover(ImovelDetalheBaseValor obj);
    }
}
