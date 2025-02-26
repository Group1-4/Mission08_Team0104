using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0104.Models;

namespace Mission08_Team0104.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult AddTask()
    {
        return View();
    }
 // testing
 // thingsd
}
