using Copa_Do_Mundo_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Copa_Do_Mundo_MVC.Controllers
{
  //  [Authorize(Roles = "Administrador")]
    public class SelecaoController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();


        public ActionResult Index()
        {
            return View(unitOfWork.SelecaoRepository.Selecoes);
        }

        public ActionResult Delete(int id)
        {
            Selecao selecao = unitOfWork.SelecaoRepository.Busca(id);
            return View(selecao);
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.SelecaoRepository.Remove(id);
            unitOfWork.Salva();
            return RedirectToAction("Index");
        }


        // GET: Selecao
        public ActionResult Create()
        {
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult Create(Selecao selecao)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.SelecaoRepository.Adiciona(selecao);
                unitOfWork.Salva();
                return RedirectToAction("Index");
            }
            return View(selecao);
        }

    }
}