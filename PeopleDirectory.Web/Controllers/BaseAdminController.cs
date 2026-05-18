using Microsoft.AspNetCore.Mvc;

namespace PeopleDirectory.Web.Controllers;

public class BaseAdminController : Controller
{
    protected bool IsLoggedIn()
    {
        return !string.IsNullOrEmpty(
            HttpContext.Session.GetString("AdminUser"));
    }

    protected IActionResult RedirectToLogin()
    {
        return RedirectToAction(
            "Login",
            "Account");
    }
}
