using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Interfaces.Services
{
    public interface IImovelTipoService: IDisposable
    {
        ImovelTipo Adicionar(ImovelTipo obj);
        ImovelTipo Adicionar(ImovelTipo obj, ICollection<ImovelTipo_DetalheTipo_DetalheBase> imovelDetalheTipo_Base);
        ImovelTipo Atualizar(ImovelTipo obj);
        ImovelTipo Atualizar(ImovelTipo obj, ICollection<ImovelTipo_DetalheTipo_DetalheBase> imovelDetalheTipo_Base);

        ImovelTipo ObterPorId(Guid id);
        IEnumerable<ImovelTipo> ObterTodos();
        void Remover(Guid id);
        void Remover(ImovelTipo obj);

        //ImovelDetalheTipo_Base
        ImovelTipo_DetalheTipo_DetalheBase Adicionar(ImovelTipo_DetalheTipo_DetalheBase obj);
        void RemoverImovelDetalheTipo_Base(Guid id);
    }
}
