using AB.NambuImoveis.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AB.NambuImoveis.UI.Web.Site.Controllers
{
    public class ImovelController : Controller
    {
        private readonly IImovelAppService _imovelAppService;
        private readonly IImovelFinalidadeAppService _imovelFinalidadeAppService;

        public ImovelController(IImovelAppService imovelAppService, IImovelFinalidadeAppService imovelFinalidadeAppService)
        {
            _imovelAppService = imovelAppService;
            _imovelFinalidadeAppService = imovelFinalidadeAppService;
        }

        // GET: Imovel
        public ActionResult Index()
        {
            var imovelViewModel = _imovelAppService.ObterTodos();
            return View(imovelViewModel);
        }

        // GET: Imovel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Imovel/Create
        public ActionResult Create()
        {
            PopulateImovelFinalidade();
            return View();
        }

        private void PopulateImovelFinalidade()
        {
            var imovelFinalidadeViewModelList = _imovelFinalidadeAppService.ObterTodos();
            ViewBag.Finalidade = new SelectList(imovelFinalidadeViewModelList);
        }

        // POST: Imovel/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Imovel/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Imovel/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Imovel/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Imovel/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
