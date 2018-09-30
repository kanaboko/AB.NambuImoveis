using AB.NambuImoveis.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.Interfaces
{
    public interface IImovelTipoAppService: IDisposable
    {
        ImovelTipoViewModel Adicionar(ImovelTipoViewModel obj);
        ImovelTipoViewModel Adicionar(ImovelTipoViewModel obj, string[] imovelDetalheTipoSelecionado, string[] imovelDetalheBaseSelecionado);
        ImovelTipoViewModel Atualizar(ImovelTipoViewModel obj);
        ImovelTipoViewModel Atualizar(ImovelTipoViewModel obj, string[] imovelDetalheBaseSelecionado);

        ImovelTipoViewModel ObterPorId(Guid id);
        IEnumerable<ImovelTipoViewModel> ObterTodos();
        void Remover(Guid id);
        void Remover(ImovelTipoViewModel obj);
    }
}
