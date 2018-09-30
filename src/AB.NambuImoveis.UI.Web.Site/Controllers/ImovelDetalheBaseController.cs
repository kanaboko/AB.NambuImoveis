using AB.NambuImoveis.Application.Interfaces;
using AB.NambuImoveis.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AB.NambuImoveis.UI.Web.Site.Controllers
{
    public class ImovelDetalheBaseController : Controller
    {
        private readonly IImovelDetalheBaseAppService _imovelDetalheBaseAppService;
        public ImovelDetalheBaseController(IImovelDetalheBaseAppService imovelDetalheBaseAppService)
        {
            _imovelDetalheBaseAppService = imovelDetalheBaseAppService;
        }
        // GET: ImovelDetalheBase
        public ActionResult Index()
        {
            var objRet = _imovelDetalheBaseAppService.ObterTodos();
            return View(objRet);
        }

        // GET: ImovelDetalheBase/Details/5
        public ActionResult Details(Guid id)
        {
            var objRet = _imovelDetalheBaseAppService.ObterPorId(id);
            return View(objRet);
        }

        // GET: ImovelDetalheBase/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ImovelDetalheBase/Create
        [HttpPost]
        public ActionResult Create(ImovelDetalheBaseViewModel imovelDetalheBaseViewModel)
        {
            if (!ModelState.IsValid)
                return View(imovelDetalheBaseViewModel);
            var objRet = _imovelDetalheBaseAppService.Adicionar(imovelDetalheBaseViewModel);
            return RedirectToAction("Index");
        }

        // GET: ImovelDetalheBase/Edit/5
        public ActionResult Edit(Guid id)
        {
            var imovelDetalheBaseViewModel = _imovelDetalheBaseAppService.ObterPorId(id);
            return View(imovelDetalheBaseViewModel);
        }

        // POST: ImovelDetalheBase/Edit/5
        [HttpPost]
        public ActionResult Edit(ImovelDetalheBaseViewModel imovelDetalheBaseViewModel)
        {
            if (!ModelState.IsValid)
                return View(imovelDetalheBaseViewModel);
            var objRet = _imovelDetalheBaseAppService.Atualizar(imovelDetalheBaseViewModel);
            return RedirectToAction("Index");
        }

        // GET: ImovelDetalheBase/Delete/5
        public ActionResult Delete(Guid id)
        {
            var imovelDetalheBaseViewModel = _imovelDetalheBaseAppService.ObterPorId(id);
            return View(imovelDetalheBaseViewModel);
        }

        // POST: ImovelDetalheBase/Delete/5
        [HttpPost, ActionName("Delete")]        
        public ActionResult DeleteConfirmed(Guid id)
        {
            _imovelDetalheBaseAppService.Remover(id);
            return RedirectToAction("Index");
        }
    }
}
