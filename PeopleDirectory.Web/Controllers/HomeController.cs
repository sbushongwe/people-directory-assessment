using Microsoft.AspNetCore.Mvc;
using PeopleDirectory.Web.Models;
using System.Diagnostics;

namespace PeopleDirectory.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
