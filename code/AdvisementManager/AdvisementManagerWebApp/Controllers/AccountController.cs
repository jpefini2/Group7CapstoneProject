using AdvisementManagerWebApp.DAL;
using AdvisementManagerWebApp.Data;
using AdvisementManagerWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Web;

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
        public RedirectToRouteResult Login([Bind] LoginViewModel model, int? id)
        {
            var username = model.Username;
            var password = model.Password;

            var redirectRoute = RedirectToRoute(new { action = "Login", controller = "Account", id });
            if (id==1 && (Request.Cookies["LoginUser"] != null))
            {
                Response.Cookies.Delete("LoginUser");
                return redirectRoute;
            }

            

            if (!(String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)))
            {
                bool isValid = this.loginDAL.AttemptLogin(username, password);

                if (!isValid) {
                    ViewBag.Message = "Login failed. Check username or password";
                    return redirectRoute;
                }
            }
            redirectRoute = RedirectToRoute(new
            {
                action = "AdvisementSessions",
                controller = "AdvisementSessions"
            });
            Response.Cookies.Append("LoginUser", username);
            return redirectRoute;
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

