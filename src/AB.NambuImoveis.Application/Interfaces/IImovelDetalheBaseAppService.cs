using AB.NambuImoveis.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.Interfaces
{
    public interface IImovelDetalheBaseAppService: IDisposable
    {
        ImovelDetalheBaseViewModel Adicionar(ImovelDetalheBaseViewModel obj);
        ImovelDetalheBaseViewModel Atualizar(ImovelDetalheBaseViewModel obj);
        ImovelDetalheBaseViewModel ObterPorId(Guid id);
        IEnumerable<ImovelDetalheBaseViewModel> ObterTodos();
        void Remover(Guid id);
        void Remover(ImovelDetalheBaseViewModel obj);



    }
}
