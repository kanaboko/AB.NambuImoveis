using AB.NambuImoveis.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.Interfaces
{
    public interface IImovelDetalheBaseValorAppService: IDisposable
    {
        ImovelDetalheBaseValorViewModel Adicionar(ImovelDetalheBaseValorViewModel obj);
        ImovelDetalheBaseValorViewModel Atualizar(ImovelDetalheBaseValorViewModel obj);
        ImovelDetalheBaseValorViewModel ObterPorId(Guid id);
        IEnumerable<ImovelDetalheBaseValorViewModel> ObterTodos();
        void Remover(Guid id);
        void Remover(ImovelDetalheBaseValorViewModel obj);
    }
}
