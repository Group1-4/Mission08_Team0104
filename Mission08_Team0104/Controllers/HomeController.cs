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
    public IActionResult Quadrant()
    {
        var tasks = _repo.Tasks
            .OrderBy(x => x.Category.CategoryName)
            .ToList();

        return View();
    }

    [HttpGet]
    public IActionResult AddTask()
    {
        ViewBag.Categories = _repo.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

        return View("AddTask", new ToDoTask());
    }

    [HttpPost]
    public IActionResult AddTask(ToDoTask t)
    {
        if (ModelState.IsValid)
        {
            _repo.AddTask(t);
        }
        return View("Quadrant");
    }

    [HttpGet]
    public IActionResult Edit(int taskid)
    {
        ViewBag.Categories = _repo.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        var task = _repo.Tasks
            .FirstOrDefault(x => x.TaskId == taskid);
        return View("Quadrant", task);
    }

    [HttpPost]
    public IActionResult Edit(ToDoTask t)
    {
        if (ModelState.IsValid)
        {
            _repo.UpdateTask(t);
        }
        return View("Quadrant");
    }

    [HttpGet]
    public IActionResult Delete(int taskid)
    {
        var task = _repo.Tasks
            .FirstOrDefault(x => x.TaskId == taskid);
        return View("Quadrant", task);
    }

    [HttpPost]
    public IActionResult Delete(ToDoTask t)
    {
        _repo.DeleteTask(t);
        return View("Quadrant");
    }


}
