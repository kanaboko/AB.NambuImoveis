using AB.NambuImoveis.Application.Interfaces;
using AB.NambuImoveis.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AB.NambuImoveis.UI.Web.Site.Controllers
{
    public class ImovelDetalheTipoController : Controller
    {
        private readonly IImovelDetalheTipoAppService _imovelDetalheTipoAppService;
        private readonly IImovelDetalheBaseAppService _imovelDetalheBaseAppService;
        public ImovelDetalheTipoController(IImovelDetalheTipoAppService imovelDetalheTipoAppService, IImovelDetalheBaseAppService imovelDetalheBaseAppService)
        {
            _imovelDetalheTipoAppService = imovelDetalheTipoAppService;
            _imovelDetalheBaseAppService = imovelDetalheBaseAppService;
        }
        // GET: ImovelDetalheTipo
        public ActionResult Index()
        {
            var imovelDetalheTipoViewModel = _imovelDetalheTipoAppService.ObterTodos();
            return View(imovelDetalheTipoViewModel);
        }

        // GET: ImovelDetalheTipo/Details/5
        public ActionResult Details(Guid id)
        {
            var imovelDetalheTipoViewModel = _imovelDetalheTipoAppService.ObterPorId(id);
            return View(imovelDetalheTipoViewModel);
        }

        // GET: ImovelDetalheTipo/Create
        public ActionResult Create()
        {
            var imovelDetalheTipo = new ImovelDetalheTipoViewModel();
            PopulateImovelDetalheBaseAssigned(imovelDetalheTipo);
            return View(imovelDetalheTipo);
        }

        // POST: ImovelDetalheTipo/Create
        [HttpPost]
        public ActionResult Create(ImovelDetalheTipoViewModel imovelDetalheViewModel, string[] imovelDetalheBaseSelecionado = null)
        {
            if (!ModelState.IsValid)
            {
                return View(imovelDetalheViewModel);
            }
            var objRet = _imovelDetalheTipoAppService.Adicionar(imovelDetalheViewModel, imovelDetalheBaseSelecionado);

            return RedirectToAction("Index");
        }

        private void PopulateImovelDetalheBaseAssigned(ImovelDetalheTipoViewModel imovelDetalheTipoViewModel)
        {
            var allImovelDetalheBase = _imovelDetalheBaseAppService.ObterTodos();
            var imovelDetalhebase = new HashSet<Guid>(imovelDetalheTipoViewModel.ImovelDetalheBases.Select(c => c.Id));
            var viewModel = new List<ImovelDetalheBaseAssignedViewModel>();
            foreach (var Base in allImovelDetalheBase)
            {
                viewModel.Add(new ImovelDetalheBaseAssignedViewModel
                {
                    Id = Base.Id,
                    Descricao = Base.Descricao,
                    TipoDados = Base.TipoDados,
                    Selecionado = imovelDetalhebase.Contains(Base.Id)
                });
            }
            ViewBag.ImovelDetalheBaseLista = viewModel;
        }

        // GET: ImovelDetalheTipo/Edit/5
        public ActionResult Edit(Guid id)
        {
            var imovelDetalheTipo = _imovelDetalheTipoAppService.ObterPorId(id);
            PopulateImovelDetalheBaseAssigned(imovelDetalheTipo);
            return View(imovelDetalheTipo);
        }

        // POST: ImovelDetalheTipo/Edit/5
        [HttpPost]
        public ActionResult Edit(ImovelDetalheTipoViewModel imovelDetalheTipo, string[] imovelDetalheBaseSelecionado)
        {
            if (!ModelState.IsValid)
            {
                return View(imovelDetalheTipo);
            }
            var objRet = _imovelDetalheTipoAppService.Atualizar(imovelDetalheTipo, imovelDetalheBaseSelecionado);

            return RedirectToAction("Index");
        }

        // GET: ImovelDetalheTipo/Delete/5
        public ActionResult Delete(Guid id)
        {
            var imovelDetalheTipo = _imovelDetalheTipoAppService.ObterPorId(id);
            return View(imovelDetalheTipo);
        }

        // POST: ImovelDetalheTipo/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _imovelDetalheTipoAppService.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
