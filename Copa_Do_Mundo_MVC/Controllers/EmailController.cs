﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Copa_Do_Mundo_MVC.Controllers
{
    public class EmailController : Controller
    {

        public EmailController() 
        { 
            WebMail.SmtpServer = "xxxxxxxxx"; 
            WebMail.EnableSsl = true; 
            WebMail.SmtpPort = 587; 
            WebMail.From = "xxxxxx"; 
            WebMail.UserName = "cxxxxxxxxxxx"; 
            WebMail.Password = "xxxx"; 
        } 
        // 23 // POST: /Email/Envia 
        
        [HttpPost] 
        public ActionResult Envia(string mensagem) 
        { 
            WebMail.Send("EMAIL", "Copa do Mundo - Erro", mensagem); 
            return View(); 
        } 


    }
}