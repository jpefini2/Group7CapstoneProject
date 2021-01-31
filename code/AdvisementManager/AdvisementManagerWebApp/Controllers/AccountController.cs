using AdvisementManagerWebApp.DAL;
using AdvisementManagerWebApp.Models;
using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    IAuthService _authService;
    public AccountController(IAuthService authservice)
    {
        _authService = authservice;
    }
    public IActionResult index()
    {
        LoginUserModel model = new LoginUserModel();

        return View(model);
    }

    [HttpPost]
    public IActionResult index(LoginUserModel model)
    {
        User u = _authService.GetUser(model.Username, model.Password);
        if (u != null)
        {
            //SessionHelper.SetObjectAsJson(HttpContext.Session, "userObject", u);
            return RedirectToAction("controlpanel");
        }
        else
        {
            return RedirectToAction("auth-failed");
        }
        return View(model);
    }
}