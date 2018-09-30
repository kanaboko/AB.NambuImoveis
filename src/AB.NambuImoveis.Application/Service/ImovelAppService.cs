using AB.NambuImoveis.Application.Interfaces;
using AB.NambuImoveis.Application.ViewModels;
using AB.NambuImoveis.Domain.Interfaces.Services;
using AB.NambuImoveis.Domain.Models;
using AB.NambuImoveis.Infra.Data.UoW;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB.NambuImoveis.Application.Service
{
    public class ImovelAppService : AppService, IImovelAppService
    {
        private readonly IImovelService _imovelService;

        public ImovelAppService(IImovelService imovelService, IUnitOfWork uow): base(uow)
        {

        }
        public ImovelViewModel Adicionar(ImovelViewModel obj)
        {
            var imovel = Mapper.Map<Imovel>(obj);
            var proprietarios = Mapper.Map<Proprietario>(obj.Proprietarios);
            var endereco = Mapper.Map<Endereco>(obj.Endereco);

            return obj;

        }

        public ImovelViewModel Adicionar(ImovelViewModel obj, string[] imovelDetalheBaseSelecionado)
        {
            var imovel = Mapper.Map<Imovel>(obj);
            var proprietarios = Mapper.Map<ICollection<Proprietario>>(obj.Proprietarios);
            var endereco = Mapper.Map<Endereco>(obj.Endereco);
            var imovel_Proprietario = new List<Imovel_Proprietario>();

            foreach (var item in proprietarios)
            {
                imovel_Proprietario.Add(new Imovel_Proprietario { ImovelId = obj.Id, ProprietarioId = item.Id });
            }

            foreach (var item in imovelDetalheBaseSelecionado)
            {
                var imovelDetalheBase = item.Split(',');
                imovel.ImovelDetalheBaseValores.Add(new ImovelDetalheBaseValor { ImovelDetalheBaseId = Guid.Parse(imovelDetalheBase[0]), Valor = imovelDetalheBase[1], ImovelId = obj.Id });
            }

            var objRet = _imovelService.Adicionar(imovel, imovel_Proprietario, proprietarios);
            if (!Commit())
            {
                return null;
            }

            return Mapper.Map<ImovelViewModel>(objRet);
        }

        public ImovelViewModel Atualizar(ImovelViewModel obj)
        {
            throw new NotImplementedException();
        }

        public ImovelViewModel Atualizar(ImovelViewModel obj, string[] imovelDetalheBaseSelecionado)
        {
            throw new NotImplementedException();
        }       

        public ImovelViewModel ObterPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ImovelViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public void Remover(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remover(ImovelViewModel obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _imovelService.Dispose();
        }
    }
}
