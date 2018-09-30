using AB.NambuImoveis.Application.Interfaces;
using AB.NambuImoveis.Application.ViewModels;
using AB.NambuImoveis.Application.ViewModels.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AB.NambuImoveis.UI.Web.Site.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clienteAppService;
        public ClienteController(IClienteAppService clienteAppService)
        {
            _clienteAppService = clienteAppService;
        }
        // GET: Cliente
        public ActionResult Index()
        {
            var clientes = _clienteAppService.ObterTodos();
            return View(clientes);
        }

        // GET: Cliente/Details/5
        public ActionResult Details(Guid id)
        {
            var pessoa = _clienteAppService.ObterPorIdCompleto(id);
            return View(pessoa);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        public PartialViewResult CreatePessoaFisica_PartialView()
        {
            return PartialView("_partialPessoaFisica");
        }

        public PartialViewResult CreatePessoaJuridica_PartialView()
        {
            return PartialView("_partialPessoaJuridica");
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(ClienteViewModel clienteViewModel)
        {
            if (!ModelState.IsValid)
                return View(clienteViewModel);
            clienteViewModel = _clienteAppService.Adicionar(clienteViewModel);
            return RedirectToAction("index");
        }

        public ActionResult CreateEndereco(Guid pessoaId, string tipoPessoa)
        {
            ViewBag.PessoaId = pessoaId;
            ViewBag.TipoPessoa = tipoPessoa;
            return PartialView("_partialEndereco");
        }

        [HttpPost]
        public ActionResult CreateEndereco(EnderecoViewModel enderecoViewModel, Guid pessoaId, string tipoPessoa)
        {
            if (!ModelState.IsValid)
                return View(enderecoViewModel);
           
            enderecoViewModel = _clienteAppService.Adicionar(enderecoViewModel, pessoaId, tipoPessoa);
            string url = Url.Action("ListarEnderecos", "Cliente", new { id = pessoaId, tipoPessoa = tipoPessoa });
            return Json(new { success = true, url = url });
           
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(Guid id, string tipoPessoa)
        {           
            ViewBag.PessoaId = id;
            ViewBag.TipoPessoa = tipoPessoa;
            var pessoa = _clienteAppService.ObterPorIdCompleto(id);
            return View(pessoa);
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(PessoaViewModel pessoaViewModel)
        {
            if (!ModelState.IsValid)
                return View(pessoaViewModel);
            switch (pessoaViewModel.TipoPessoa)
            {
                case TipoPessoaViewModel.PessoaFisica:
                    var pessoaFisicaViewModel = _clienteAppService.AtualizarPessoaFisica(pessoaViewModel.PessoaFisica);
                    break;
                case TipoPessoaViewModel.PessoaJuridica:
                    var pessoaJuridicaViewModel = _clienteAppService.AtualizarPessoaJuridica(pessoaViewModel.PessoaJuridica);
                    break;
                default:
                    break;
            }
            return RedirectToAction("Index");
        }

        // GET: Cliente/EditEndereco/5
        public ActionResult EditEndereco(Guid id, Guid pessoaId, string tipoPessoa)
        {
            ViewBag.PessoaId = pessoaId;
            ViewBag.TipoPessoa = tipoPessoa;
            ViewBag.EnderecoId = id;
            var Endereco = _clienteAppService.ObterPorIdEndereco(id);
            return PartialView("_partialEndereco", Endereco);
        }

        // POST: Cliente/EditEndereco/5
        [HttpPost]
        public ActionResult EditEndereco(EnderecoViewModel enderecoViewModel, Guid pessoaId, string tipoPessoa)
        {
            if (!ModelState.IsValid)
                return View(enderecoViewModel);

            enderecoViewModel = _clienteAppService.Atualizar(enderecoViewModel);
            string url = Url.Action("ListarEnderecos", "Cliente", new { id = pessoaId, tipoPessoa = tipoPessoa });
            return Json(new { success = true, url = url });
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(Guid id)
        {
            var pessoaViewModel = _clienteAppService.ObterPorIdCompleto(id); 
            return View(pessoaViewModel);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id)
        {
            var pessoaViewModel = _clienteAppService.ObterPorId(id);
            _clienteAppService.Remover(pessoaViewModel);
            return RedirectToAction("Index");
        }

        // GET: Cliente/DeleteEndereco/5
        public ActionResult DeleteEndereco(Guid id, Guid pessoaId, string tipoPessoa)
        {
            ViewBag.PessoaId = pessoaId;
            ViewBag.TipoPessoa = tipoPessoa;
            var enderecoViewModel = _clienteAppService.ObterPorIdEndereco(id);
            return View("_deleteEndereco",enderecoViewModel);
        }

        // POST: Cliente/DeleteEndereco/5
        [HttpPost, ActionName("DeleteEndereco")]
        public ActionResult DeleteEnderecoConfirmed(Guid id, Guid pessoaId, string tipoPessoa)
        {
            _clienteAppService.RemoverEndereco(id, pessoaId, tipoPessoa);
            string url = Url.Action("ListarEnderecos", "Cliente", new { id = pessoaId, tipoPessoa = tipoPessoa });
            return Json(new { success = true, url = url });
        }

        public ActionResult ListarEnderecos(Guid id, string tipoPessoa = null)
        {
            ViewBag.PessoaId = id;
            ViewBag.TipoPessoa = tipoPessoa;
            switch (tipoPessoa)
            {
                case "PessoaFisica":
                    var pessoaFisica = _clienteAppService.ObterPorIdPessoaFisica(id);
                    return PartialView("_listEndereco", pessoaFisica.EnderecoList);
                case "PessoaJuridica":
                    var pessoaJuridica = _clienteAppService.ObterPorIdPessoaJuridica(id);
                    return PartialView("_listEndereco", pessoaJuridica.EnderecoList);
                default:
                    break;
            }
            return null;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _clienteAppService.Dispose();
            }
            base.Dispose(disposing);
        }


    }
}
