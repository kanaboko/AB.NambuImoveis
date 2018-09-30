using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Interfaces.Services
{
    public interface IImovelDetalheTipoService: IDisposable
    {
        ImovelDetalheTipo Adicionar(ImovelDetalheTipo obj);
        ImovelDetalheTipo Adicionar(ImovelDetalheTipo obj, ICollection<ImovelDetalheTipo_DetalheBase> imovelDetalheTipo_Base);
        ImovelDetalheTipo Atualizar(ImovelDetalheTipo obj);
        ImovelDetalheTipo Atualizar(ImovelDetalheTipo obj, ICollection<ImovelDetalheTipo_DetalheBase> imovelDetalheTipo_Base);

        ImovelDetalheTipo ObterPorId(Guid id);
        IEnumerable<ImovelDetalheTipo> ObterTodos();
        void Remover(Guid id);
        void Remover(ImovelDetalheTipo obj);

        //ImovelDetalheTipo_Base
        ImovelDetalheTipo_DetalheBase Adicionar(ImovelDetalheTipo_DetalheBase obj);
        void RemoverImovelDetalheTipo_Base(Guid id);
    }
}
