using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission08_Team0104.Models;

namespace Mission08_Team0104.Controllers;

public class HomeController : Controller
{
    private IMission8Repository _repo; // This is the repository that will be used to access the database
    public HomeController(IMission8Repository temp) // This is the constructor that will be used to inject the repository
    {
        _repo = temp;
    }
    public IActionResult Index() 
    {
        return View(); // This should render Views/Home/Index.cshtml
    }
    public IActionResult Quadrant() 
    {
        var tasks = _repo.Tasks // This should get all tasks from the repository
            .OrderBy(x => x.Category.CategoryName) 
            .ToList();

        return View(tasks); // This should render Views/Home/Quadrant.cshtml
    }

    [HttpGet]
    public IActionResult AddTask() // This should render Views/Home/AddTask.cshtml
    {
        ViewBag.Categories = _repo.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();

        return View(new ToDoTask()); 
    }

    [HttpPost]
    public IActionResult AddTask(ToDoTask x) // pulls in the ToDoTask object from the form
    {
        if (ModelState.IsValid) 
        {
            _repo.AddTask(x);
            return RedirectToAction("Quadrant");
        }
        else
        {
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View(x); // returns the form with the data that was entered
        }
        
    }

    [HttpGet]
    public IActionResult Edit(int taskid) // grabs the taskid from the URL
    {
        ViewBag.Categories = _repo.Categories
            .OrderBy(x => x.CategoryName)
            .ToList();
        
        var task = _repo.Tasks.Single(x => x.TaskId == taskid);
            
        
        return View("AddTask", task); //shows the AddTask view with the task data
    }

    [HttpPost]
    public IActionResult Edit(ToDoTask x) // commits the changes to the database
    {
        if (ModelState.IsValid)
        {
            _repo.UpdateTask(x);
            return RedirectToAction("Quadrant"); //redirects to the Quadrant view if successful
        }
        else
        {
            ViewBag.Categories = _repo.Categories
                .OrderBy(x => x.CategoryName)
                .ToList();
            return View(x); // directs to the AddTask view with the task data
        }
    }

    [HttpGet]
    public IActionResult Delete(int taskid) //gets the taskid from the URL
    {
        var task = _repo.Tasks
            .FirstOrDefault(x => x.TaskId == taskid);
        if (task != null)
        {
            _repo.DeleteTask(task); //deletes the task from the database

        }
        return RedirectToAction("Quadrant"); //redirects to the Quadrant view
    }

    [HttpPost]
    public IActionResult Delete(ToDoTask x) 
    {
        _repo.DeleteTask(x); //deletes the task from the database
        return View("Quadrant");
    }


}
