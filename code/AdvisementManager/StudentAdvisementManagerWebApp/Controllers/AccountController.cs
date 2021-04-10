using AdvisementManagerSharedLibrary.DAL;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace StudentAdvisementManagerWebApp.Controllers
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

        /// <summary>
        /// Attempts to log the user in with the provided credentials.
        /// If successful, creates a session cookie and sends the user
        /// to the advisement sessions page. If id == 1, logs the
        /// current user out and deletes their session cookie.
        /// </summary>
        /// <param name="model">The LoginViewModel</param>
        /// <param name="id?">The id indicator.</param>
        /// <returns>The current page.</returns>
        /// <returns>The advisement sessions page.</returns>
        [HttpPost]
        public ActionResult Login([Bind] LoginViewModel model, int? id)
        {
            var username = model.Username;
            var password = model.Password;

            if (Request.Cookies["StudentAdvisementManager.LoginUser"] != null)
            {
                if (id == 1)
                {
                    ClearSessionData();
                    return RedirectToRoute(new { action = "Login", controller = "Account" });
                }
                else
                {
                    return RedirectToExistingSession();
                }
            }

            if (!(String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password)))
            {
                String sessionKey = this.loginDAL.AttemptLogin(username, password, LoginType.STUDENT);

                if (String.IsNullOrEmpty(sessionKey)) {
                    ViewBag.Message = "Login failed. Check username or password.";
                } else
                {
                    if (loginDAL.createNewLoginSession(username, sessionKey))
                    {
                        Response.Cookies.Append("StudentAdvisementManager.LoginUser", username);
                        Response.Cookies.Append("AdvisementManager.LoginSession", sessionKey);
                    }
                    else
                    {
                        ViewBag.Message = "Something went wrong trying to create a new login session.";
                        return View(model);
                    }
                    return RedirectToRoute(new { action = "StudentHome", controller = "Home" });
                }
            }
            return View(model);
        }

        /// <summary>
        /// Redirects the user to the current page.
        /// </summary>
        /// <returns></returns>
        public RedirectToRouteResult RedirectToCurrentPage()
        {
            ViewBag.Message = "Login failed. Check input fields";
            return RedirectToRoute(new { action = "Login", controller = "Account"});
        }

        private ActionResult RedirectToExistingSession()
        {
            var username = Request.Cookies["StudentAdvisementManager.LoginUser"];
            if(loginDAL.GetUserType(username) == LoginType.STUDENT)
            {
                return RedirectToRoute(new { action = "StudentHome", controller = "Home" });
            } else
            {
                ClearSessionData();
                return View();
            }
        }

        /// <summary>
        /// Redirects the user to Login()
        /// </summary>
        /// <returns></returns>
        public IActionResult Login()
        {
            if (Request.Cookies["StudentAdvisementManager.LoginUser"] != null)
            {
                return RedirectToExistingSession();
            }
            else
            {
                return View();
            }
        }

        private void ClearSessionData()
        {
            Response.Cookies.Delete("StudentAdvisementManager.LoginUser");
            Response.Cookies.Delete("AdvisementManager.LoginSession");
            TempData.Clear();
        }
    }
}

