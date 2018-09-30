using AB.NambuImoveis.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Domain.Interfaces.Services
{
    public interface IImovelService: IDisposable
    {
        Imovel Adicionar(Imovel obj);
        Imovel Adicionar(Imovel obj, ICollection<Imovel_Proprietario> imovel_Proprietario, ICollection<Proprietario> proprietarios);
        Imovel Atualizar(Imovel obj);
        Imovel Atualizar(Imovel obj, ICollection<Imovel_Proprietario> imovel_Proprietario, ICollection<Proprietario> proprietarios);

        Imovel ObterPorId(Guid id);
        IEnumerable<Imovel> ObterTodos();
        void Remover(Guid id);
        void Remover(Imovel obj);

        //Imovel_Proprietario
        Imovel_Proprietario Adicionar(Imovel_Proprietario obj);
        void RemoverImovelDetalheTipo_Base(Guid id);
    }
}
