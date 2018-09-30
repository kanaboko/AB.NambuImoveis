using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Interfaces.Services
{
    public interface IImovelFinalidadeService: IDisposable
    {
        ImovelFinalidade Adicionar(ImovelFinalidade obj);
        ImovelFinalidade Adicionar(ImovelFinalidade obj, ICollection<ImovelFinalidade_ImovelTipo> imovelFinalidade_ImovelTipo);
        ImovelFinalidade Atualizar(ImovelFinalidade obj);
        ImovelFinalidade Atualizar(ImovelFinalidade obj, ICollection<ImovelFinalidade_ImovelTipo> imovelFinalidade_ImovelTipo);

        ImovelFinalidade ObterPorId(Guid id);
        IEnumerable<ImovelFinalidade> ObterTodos();
        void Remover(Guid id);
        void Remover(ImovelFinalidade obj);

        //ImovelFinalidade_ImovelTipo
        ImovelFinalidade_ImovelTipo Adicionar(ImovelFinalidade_ImovelTipo obj);
        void RemoverImovelFinalide_ImovelTipo(Guid id);
    }
}
