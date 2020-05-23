using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Copa_Do_Mundo_MVC.Controllers
{
    public class ErroController : Controller
    {
        // GET: /Erro/Desconhecido 
        public ActionResult Desconhecido() 
        { 
            return View(); 
        } 

        // 20 // GET: /Erro/PaginaNaoEncontrada 
        public ActionResult PaginaNaoEncontrada() 
        { 
            return View(); 
        } 
    }
}