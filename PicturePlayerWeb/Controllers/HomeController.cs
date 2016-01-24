using PicturePlayerWeb.Infrastructure.Interfaces;
using PicturePlayerWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PicturePlayerWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAuthProvider authProvider;
        public HomeController(IAuthProvider provider)
        {
            authProvider = provider;
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (authProvider.Authenticate(model.UserName, model.Password))
                    return Redirect(returnUrl ?? Url.Action("Index", "Admin"));
                else
                    ModelState.AddModelError("Неверное имя пользователя или пароль", new Exception());
                return View();
            }
            else
                return View();

        }
    }
}