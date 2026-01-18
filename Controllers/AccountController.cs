using Student.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Student.Controllers
{
    public class AccountController : Controller
    {
        private readonly AuthService _authService;

        public AccountController()
        {
            _authService = new AuthService();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = _authService.ValidateUser(username, password);

            if (user != null)
            {
                Session["User"] = user.Username;
                return RedirectToAction("Dashboard", "Home");
            }

            ViewBag.Error = "Invalid username or password!";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}

