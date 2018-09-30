using AB.NambuImoveis.Application.Interfaces;
using AB.NambuImoveis.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AB.NambuImoveis.UI.Web.Site.Controllers
{
    public class ImovelTipoController : Controller
    {
        private readonly IImovelTipoAppService _imovelTipoAppService;
        private readonly IImovelDetalheTipoAppService _imovelDetalheTipoAppService;
        private readonly IImovelDetalheBaseAppService _imovelDetalheBaseAppService;

        public ImovelTipoController(IImovelTipoAppService imovelTipoAppService, IImovelDetalheTipoAppService imovelDetalheTipoAppService, IImovelDetalheBaseAppService imovelDetalheBaseAppService)
        {
            _imovelTipoAppService = imovelTipoAppService;
            _imovelDetalheTipoAppService = imovelDetalheTipoAppService;
            _imovelDetalheBaseAppService = imovelDetalheBaseAppService;
        }
        // GET: ImovelTipo
        public ActionResult Index()
        {
            var imovelTipo = _imovelTipoAppService.ObterTodos();
            return View(imovelTipo);
        }

        // GET: ImovelTipo/Details/5
        public ActionResult Details(Guid id)
        {
            var imovelTipo = _imovelTipoAppService.ObterPorId(id);
            return View(imovelTipo);
        }

        // GET: ImovelTipo/Create
        public ActionResult Create()
        {
            var imovelTipoViewModel = new ImovelTipoViewModel();
            PopulateImovelDetalheBaseAssigned(imovelTipoViewModel);
            return View(imovelTipoViewModel);
        }

        // POST: ImovelTipo/Create
        [HttpPost]
        public ActionResult Create(ImovelTipoViewModel imovelTipoViewModel, string[] imovelDetalheTipoSelecionado, string[] imovelDetalheBaseSelecionado)
        {
            if (!ModelState.IsValid)
            {
                return View(imovelTipoViewModel);
            }
            var objRet = _imovelTipoAppService.Adicionar(imovelTipoViewModel, imovelDetalheTipoSelecionado, imovelDetalheBaseSelecionado);
            return RedirectToAction("Index");
        }

        private void PopulateImovelDetalheBaseAssigned(ImovelTipoViewModel imovelTipoViewModel)
        {
            var allImovelDetalheTipo = _imovelDetalheTipoAppService.ObterTodos();
            var imovelDetalheTipo = new HashSet<Guid>(imovelTipoViewModel.ImovelDetalheTipos.Select(c => c.Id));
            var imovelDetalheBase = new HashSet<Guid>(imovelTipoViewModel.ImovelDetalheTipos.ToList().SelectMany(src=>src.ImovelDetalheBases.Select(k=>k.Id)));

            var viewModel = new List<ImovelDetalheTipoAssignedViewModel>();
            foreach (var tipo in allImovelDetalheTipo)
            {
                var detalheBaseViewModel = new List<ImovelDetalheBaseAssignedViewModel>();

                foreach (var item in tipo.ImovelDetalheBases)
                {
                    detalheBaseViewModel.Add(new ImovelDetalheBaseAssignedViewModel
                    {
                        Id = item.Id,
                        Descricao = item.Descricao,
                        Selecionado = imovelDetalheBase.Contains(item.Id),
                        TipoDados = item.TipoDados
                    });
                }
                viewModel.Add(new ImovelDetalheTipoAssignedViewModel
                {
                    Id = tipo.Id,
                    Descricao = tipo.Descricao,
                    Selecionado = imovelDetalheTipo.Contains(tipo.Id),
                    ImovelDetalheBases = detalheBaseViewModel

                });
            }
            ViewBag.ImovelDetalheTipoLista = viewModel;
        }

        // GET: ImovelTipo/Edit/5
        public ActionResult Edit(Guid id)
        {
            var imovelTipoViewModel = _imovelTipoAppService.ObterPorId(id);
            PopulateImovelDetalheBaseAssigned(imovelTipoViewModel);
            return View(imovelTipoViewModel);
        }

        // POST: ImovelTipo/Edit/5
        [HttpPost]
        public ActionResult Edit(ImovelTipoViewModel imovelTipoViewModel, string[] imovelTipoSelecionado, string[] imovelDetalheBaseSelecionado)
        {
            if (!ModelState.IsValid)
            {
                return View(imovelTipoViewModel);
            }
            var imovelTipoViewModelReturn = _imovelTipoAppService.Atualizar(imovelTipoViewModel, imovelDetalheBaseSelecionado);
            return RedirectToAction("Index");
        }

        // GET: ImovelTipo/Delete/5
        public ActionResult Delete(Guid id)
        {
            var imovelTipoViewModel = _imovelTipoAppService.ObterPorId(id);
            return View(imovelTipoViewModel);
        }

        // POST: ImovelTipo/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _imovelTipoAppService.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
