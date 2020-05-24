using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CheckUser(UserViewModel userViewModel)
        {
            if (ModelState.IsValid && userViewModel.Username != null && userViewModel.Password != null)
            {
                string userName = userViewModel.Username;
                string passWord = userViewModel.Password;

                return View("Start");
            }
            else
            {
                return View("Index");
            }
        }
    }
}