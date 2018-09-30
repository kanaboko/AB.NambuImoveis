using AB.NambuImoveis.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.Interfaces
{
    public interface IImovelFinalidadeAppService: IDisposable
    {
        ImovelFinalidadeViewModel Adicionar(ImovelFinalidadeViewModel obj);
        ImovelFinalidadeViewModel Adicionar(ImovelFinalidadeViewModel obj, string[] imovelTipoSelecionado);
        ImovelFinalidadeViewModel Atualizar(ImovelFinalidadeViewModel obj);
        ImovelFinalidadeViewModel Atualizar(ImovelFinalidadeViewModel obj, string[] imovelTipoSelecionado);

        ImovelFinalidadeViewModel ObterPorId(Guid id);
        IEnumerable<ImovelFinalidadeViewModel> ObterTodos();
        void Remover(Guid id);
        void Remover(ImovelFinalidadeViewModel obj);
    }
}
