using Microsoft.AspNetCore.Mvc;
using StudentAdvisementManagerWebApp.Data;
using System;
using System.Diagnostics;

namespace AdvisementManagerWebApp.Controllers
{
    /// <summary>
    ///   The account controllers class
    /// </summary>
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext context;

        private LoginViewModel loginViewModel = new();

        private DAL.LoginDAL loginDAL;

        /// <summary>Initializes a new instance of the <see cref="AccountController" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public AccountController(ApplicationDbContext context)
        {
            this.context = context;
            loginDAL = new DAL.LoginDAL(context);
        }

        [HttpPost]
        public ActionResult Login([Bind] LoginViewModel model, int? id)
        {
            var username = model.Username;
            var password = model.Password;

            if (id==1 && (Request.Cookies["LoginUser"] != null))
            {
                Response.Cookies.Delete("LoginUser");
                return RedirectToRoute(new { action = "Login", controller = "Account" });
            }

            if (!(String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)))
            {
                bool isValid = this.loginDAL.AttemptLogin(username, password);

                if (!isValid) {
                    ViewBag.Message = "Login failed. Check username or password.";
                } else
                {
                    Response.Cookies.Append("LoginUser", username);
                    return RedirectToRoute(new { action = "StudentHome", controller = "Home" });
                }
            }
            return View(model);
        }

        public RedirectToRouteResult RedirectToCurrentPage()
        {
            ViewBag.Message = "Login failed. Check input fields";
            return RedirectToRoute(new { action = "Login", controller = "Account"});
        }
        
        public IActionResult Login()
        {
            return View();
        }
    }
}

