using LogicLayer;
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
        public UserLogic UserLogic { get; set; } = new UserLogic();

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

                string getUser = UserLogic.DoLogin(userName, passWord);

                if(getUser == "User found in database")
                {
                    return View("Start");

                }
                else
                {
                    return View("Index");
                }
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public  ActionResult SafeUser(string username, string password, string password2)
        {
            UserLogic.RegisterUser(username, password, password2);
            return Redirect("Index");
        }
    }
}