using AB.NambuImoveis.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.Interfaces
{
    public interface IImovelAppService: IDisposable
    {
        ImovelViewModel Adicionar(ImovelViewModel obj);
        ImovelViewModel Adicionar(ImovelViewModel obj, string[] imovelDetalheBaseSelecionado);
        ImovelViewModel Atualizar(ImovelViewModel obj);
        ImovelViewModel Atualizar(ImovelViewModel obj, string[] imovelDetalheBaseSelecionado);

        ImovelViewModel ObterPorId(Guid id);
        IEnumerable<ImovelViewModel> ObterTodos();
        void Remover(Guid id);
        void Remover(ImovelViewModel obj);
    }
}
