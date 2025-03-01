using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0104.Models;

namespace Mission08_Team0104.Controllers;

public class HomeController : Controller
{
    private IMission8Repository _repo;
    public HomeController(IMission8Repository temp)
    {
        _repo = temp;
    }
    public IActionResult Index()
    {
        return View(); // This should render Views/Home/Index.cshtml
    }
    public IActionResult Quadrant()
    {
        var tasks = _repo.Tasks
            .OrderBy(x => x.Category.CategoryName)
            .ToList();

        return View(tasks ?? new List<ToDoTask>());
    }

    [HttpGet]
    public IActionResult AddTask()
    {
        ViewBag.Categories = _repo.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

        return View(new ToDoTask());
    }

    [HttpPost]
    public IActionResult AddTask(ToDoTask x)
    {
        if (ModelState.IsValid)
        {
            _repo.AddTask(x);
        }
        return RedirectToAction("Quadrant");
    }

    [HttpGet]
    public IActionResult Edit(int taskid)
    {
        ViewBag.Categories = _repo.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        var task = _repo.Tasks.ToList();
            //.FirstOrDefault(x => x.TaskId == taskid);
        
        return View("Quadrant", task);
    }

    [HttpPost]
    public IActionResult Edit(ToDoTask x)
    {
        if (ModelState.IsValid)
        {
            _repo.UpdateTask(x);
        }
        return View("Quadrant");
    }

    [HttpGet]
    public IActionResult Delete(int taskid)
    {
        var task = _repo.Tasks
            .FirstOrDefault(x => x.TaskId == taskid);
        if (task != null)
        {
            _repo.DeleteTask(task);
            
        }
        return RedirectToAction("Quadrant");
    }

    [HttpPost]
    public IActionResult Delete(ToDoTask x)
    {
        _repo.DeleteTask(x);
        return View("Quadrant");
    }


}
