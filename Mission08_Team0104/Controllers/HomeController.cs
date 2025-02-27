using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0104.Models;
using SQLitePCL;

namespace Mission08_Team0104.Controllers;

public class HomeController : Controller
{

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Quadrant()
    {
        //var tasks = _repo.Tasks.ToList()
        return View();
    }

    public IActionResult AddTask()
    {
        return View();
    }
    // testing
    //ASD
    // thingsd
    // asdff

    //public class HomeController : Controller
    //{
    //    private IMission8Repository _repo;
    //    public HomeController(IMission8Repository temp)
    //    {
    //        _repo = temp;
    //    }
    //    [HttpGet]
    //    public IActionResult Index()
    //    {
    //        return View(new Quadr);
    //    }

    //    [HttpPost]
    //    public IActionResult Index(Manager m)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _repo.AddManager(m);
    //        }
    //        return View(new Manager());
    //    }

    //}


}
