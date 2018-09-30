using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Interfaces.Services
{
    public interface IImovelDetalheBaseService: IDisposable
    {
        ImovelDetalheBase Adicionar(ImovelDetalheBase obj);
        ImovelDetalheBase Atualizar(ImovelDetalheBase obj);
        ImovelDetalheBase ObterPorId(Guid id);
        IEnumerable<ImovelDetalheBase> ObterTodos();
        void Remover(Guid id);
        void Remover(ImovelDetalheBase obj);
    }
}
