using Copa_Do_Mundo_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Copa_Do_Mundo_MVC.Controllers
{
    public class UsuarioController : Controller
    {

        public ActionResult Login()
        {
            return View();
        }

        //POST: /Usuario/Login
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.UserName, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Selecao");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "O usuário e/ou a senha está incorreto.");
                }
            }
            return View(model);
        }

        // 53 // GET: /Usuario/LogOff 
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return Redirect("/");

        }
        // GET: /Usuario/Register 
        public ActionResult Register()
        {
            return View();
        }


        // POST: /Usuario/Register 
        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user 
                MembershipCreateStatus createStatus;
                Membership.CreateUser(model.UserName, model.Password, model.Email, null, null , true, null, out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.UserName, false /* createPersistentCookie */);
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }
            return View(model);
        }

        // GET: /Usuario/ChangePassword 
        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //  // POST: /Usuario/ChangePassword 
        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            if (ModelState.IsValid)
            {
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true);  /* userIsOnline */
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;


                }
                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "A senha atual ou a confirmação está incorreta← .");
                }
            }
            return View(model);
        }


        //  GET: /Usuario/ChangePasswordSuccess 
        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }
        private IEnumerable<string> GetErrorsFromModelState()
        {
            return ModelState.SelectMany(x => x.Value.Errors.Select(error => error.ErrorMessage));
        }


        #region Status Codes 
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for 
            // a full list of status codes. 160 

            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "Este nome de usuário já existe. Defina outro usuário.";
                case MembershipCreateStatus.DuplicateEmail:
                    return "Este email já foi cadastrado. Defina outro email.";
                case MembershipCreateStatus.InvalidPassword:
                    return "Senha incorreta.";
                case MembershipCreateStatus.InvalidEmail:
                    return "Email inválido.";
                case MembershipCreateStatus.InvalidAnswer:
                    return "Resposta inválida para recuperar a senha.";
                case MembershipCreateStatus.InvalidQuestion:
                    return "Questão inválida para recuperar a senha.";
                case MembershipCreateStatus.InvalidUserName:
                    return "Usuário inválido.";
                case MembershipCreateStatus.ProviderError:
                    return "Ocorreu um erro durante a autenticação. Se o problema persistir , contate o administrador.";
                case MembershipCreateStatus.UserRejected:
                    return "O cadastro do usuário foi cancelado. Se o problema persistir ,  contate o administrador.";
                default:
                    return "Um erro inesperado ocorreu. Se o problema persistir , contate o  administrador.";
            }
        }

        #endregion
    }
}
