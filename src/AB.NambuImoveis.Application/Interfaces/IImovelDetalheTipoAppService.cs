using AB.NambuImoveis.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.Interfaces
{
    public interface IImovelDetalheTipoAppService: IDisposable
    {
        ImovelDetalheTipoViewModel Adicionar(ImovelDetalheTipoViewModel obj);
        ImovelDetalheTipoViewModel Adicionar(ImovelDetalheTipoViewModel obj, string[] imovelDetalheBaseSelecionado);
        ImovelDetalheTipoViewModel Atualizar(ImovelDetalheTipoViewModel obj);
        ImovelDetalheTipoViewModel Atualizar(ImovelDetalheTipoViewModel obj, string[] imovelDetalheBaseSelecionado);

        ImovelDetalheTipoViewModel ObterPorId(Guid id);
        IEnumerable<ImovelDetalheTipoViewModel> ObterTodos();
        void Remover(Guid id);
        void Remover(ImovelDetalheTipoViewModel obj);

    }
}
