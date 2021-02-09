using AdvisementManagerWebApp.DAL;
using AdvisementManagerWebApp.Data;
using AdvisementManagerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
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

        private LoginDAL loginDAL;

        /// <summary>Initializes a new instance of the <see cref="AccountController" /> class.</summary>
        /// <param name="logger">The logger.</param>
        public AccountController(ApplicationDbContext context)
        {
            this.context = context;
            loginDAL = new LoginDAL(context);
        }

        [HttpPost]
        public ActionResult Login([Bind] LoginViewModel model, int? id)
        {
            var username = model.Username;
            var password = model.Password;

            if (id==1 && (Request.Cookies["LoginUser"] != null))
            {
                Response.Cookies.Delete("LoginUser");
                return View(model);
            }

            if (!(String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)))
            {
                bool isValid = this.loginDAL.AttemptLogin(username, password);

                if (!isValid) {
                    ViewBag.Message = "Login failed. Check username or password.";
                } else
                {
                    Response.Cookies.Append("LoginUser", username);
                    return RedirectToRoute(new { action = "AdvisementSessions", controller = "AdvisementSessions" });
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

        /// <summary>Errors this instance.</summary>
        /// <returns>
        ///   The errors views model
        /// </returns>
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

