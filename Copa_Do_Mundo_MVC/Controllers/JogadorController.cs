using Copa_Do_Mundo_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Copa_Do_Mundo_MVC.Controllers
{
    //[Authorize(Roles = "Administrador")]
    public class JogadorController : Controller
    {
        private UnitOfWork unitOfWork = new UnitOfWork();

        public ActionResult Create()
        {
            ViewBag.SelecaoId = new SelectList(unitOfWork.SelecaoRepository.Selecoes, "Id", "Pais");
            return View();
        }
        protected override void Dispose(bool disposing)
        {
            unitOfWork.Dispose();
            base.Dispose(disposing);
        }

        [HttpPost]
        public ActionResult Create(Jogador jogador)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.JogadorRepository.Adiciona(jogador);
                unitOfWork.Salva();
                return RedirectToAction("Index");
            }
            ViewBag.SelecaoId = new SelectList(unitOfWork.SelecaoRepository.Selecoes, "Id", "Pais");
            return View();
        }

        public ActionResult Index()
        {
            return View(unitOfWork.JogadorRepository.Jogadores);
        }

        public ActionResult Delete(int id)
        {
            Jogador jogador = unitOfWork.JogadorRepository.Busca(id); return View(jogador);
        }


        //removeojogadordobancodedados.

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            unitOfWork.JogadorRepository.Remove(id);
            unitOfWork.Salva();
            return RedirectToAction("Index");
        }

    }
}