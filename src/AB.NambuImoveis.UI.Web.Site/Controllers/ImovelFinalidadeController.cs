using AB.NambuImoveis.Application.Interfaces;
using AB.NambuImoveis.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AB.NambuImoveis.UI.Web.Site.Controllers
{
    public class ImovelFinalidadeController : Controller
    {
        private readonly IImovelFinalidadeAppService _imovelFinalidadeAppService;
        private readonly IImovelTipoAppService _imovelTipoAppService;
        public ImovelFinalidadeController(IImovelFinalidadeAppService imovelFinalidadeAppService, IImovelTipoAppService imovelTipoAppService)
        {
            _imovelFinalidadeAppService = imovelFinalidadeAppService;
            _imovelTipoAppService = imovelTipoAppService;
        }
        // GET: ImovelFinalidade
        public ActionResult Index()
        {
            var obj = _imovelFinalidadeAppService.ObterTodos();
            return View(obj);
        }

        // GET: ImovelFinalidade/Details/5
        public ActionResult Details(Guid id)
        {
            var obj = _imovelFinalidadeAppService.ObterPorId(id);
            return View(obj);
        }

        // GET: ImovelFinalidade/Create
        public ActionResult Create()
        {
            var imovelFinalidadeViewModel = new ImovelFinalidadeViewModel();
            PopulateImovelTipoAssigned(imovelFinalidadeViewModel);
            return View(imovelFinalidadeViewModel);
        }

        // POST: ImovelFinalidade/Create
        [HttpPost]
        public ActionResult Create(ImovelFinalidadeViewModel imovelFinalidadeViewModel, string[] imovelTipoSelecionado)
        {
            if (!ModelState.IsValid)
            {
                return View(imovelFinalidadeViewModel);
            }

            var objRet = _imovelFinalidadeAppService.Adicionar(imovelFinalidadeViewModel, imovelTipoSelecionado);
            return RedirectToAction("Index");
        }

        private void PopulateImovelTipoAssigned(ImovelFinalidadeViewModel imovelFinalidadeTipoViewModel)
        {
            var allImovelTipo = _imovelTipoAppService.ObterTodos();
            var imovelTipo = new HashSet<Guid>(imovelFinalidadeTipoViewModel.ImovelTipos.Select(c => c.Id));
            var viewModel = new List<ImovelTipoAssignedViewModel>();
            foreach (var Base in allImovelTipo)
            {
                viewModel.Add(new ImovelTipoAssignedViewModel
                {
                    Id = Base.Id,
                    Descricao = Base.Descricao,                    
                    Selecionado = imovelTipo.Contains(Base.Id)
                });
            }
            ViewBag.ImovelTipoLista = viewModel;
        }

        // GET: ImovelFinalidade/Edit/5
        public ActionResult Edit(Guid id)
        {
            var imovelFinalidadeViewModel = _imovelFinalidadeAppService.ObterPorId(id);
            PopulateImovelTipoAssigned(imovelFinalidadeViewModel);
            return View(imovelFinalidadeViewModel);
        }

        // POST: ImovelFinalidade/Edit/5
        [HttpPost]
        public ActionResult Edit(ImovelFinalidadeViewModel imovelFinalidadeViewModel, string[] imovelTipoSelecionado)
        {
            if (!ModelState.IsValid)
            {
                return View(imovelFinalidadeViewModel);
            }
            var objRet = _imovelFinalidadeAppService.Atualizar(imovelFinalidadeViewModel, imovelTipoSelecionado);

            return RedirectToAction("Index");
        }

        // GET: ImovelFinalidade/Delete/5
        public ActionResult Delete(Guid id)
        {
            var imovelFinalidadeViewModel = _imovelFinalidadeAppService.ObterPorId(id);
            return View(imovelFinalidadeViewModel);
        }

        // POST: ImovelFinalidade/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            _imovelFinalidadeAppService.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
