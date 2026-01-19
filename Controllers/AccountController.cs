using Student.Services;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

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
            // If already logged in, go to dashboard
            if (Session["User"] != null)
                return RedirectToAction("Dashboard", "Home");

            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = _authService.ValidateUser(username, password);

            if (user != null)
            {
                // Store username in session
                Session["User"] = user.Username;

                return RedirectToAction("Dashboard", "Home");
            }

            // Display error UI message
            ViewBag.Error = "Invalid username or password!";
            return View();
        }

        public ActionResult Logout()
        {
            // Clear session
            Session.Clear();
            Session.Abandon();

            // Clear authentication cookie (safe for future Identity usage)
            FormsAuthentication.SignOut();

            // Redirect to login with explicit controller name
            return RedirectToAction("Login", "Account");
        }
    }
}



