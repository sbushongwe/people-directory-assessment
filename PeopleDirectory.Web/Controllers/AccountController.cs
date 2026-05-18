using Microsoft.AspNetCore.Mvc;
using PeopleDirectory.Web.Models;

using Microsoft.Extensions.Options;
using PeopleDirectory.Web.Configuration;

namespace PeopleDirectory.Web.Controllers;

public class AccountController : Controller
{
    private readonly AdminSettings _adminSettings;

    public AccountController(
    IOptions<AdminSettings> adminSettings)
    {
        _adminSettings = adminSettings.Value;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        if (model.Username == _adminSettings.Username
    && model.Password == _adminSettings.Password)
        {
            HttpContext.Session.SetString(
                "AdminUser",
                model.Username);

            return RedirectToAction(
                "Index",
                "Admin");
        }

        ViewBag.Error = "Invalid username or password.";

        return View(model);
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction(
            "Login");
    }
}
