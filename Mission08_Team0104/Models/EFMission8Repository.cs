using Microsoft.EntityFrameworkCore;

namespace Mission08_Team0104.Models;

public class EFMission8Repository : IMission8Repository
{
    private Mission8DatabaseContext _context;

    public EFMission8Repository(Mission8DatabaseContext temp)
    {
        _context = temp;
    }
    public List<ToDoTask> Tasks => _context.Tasks.Include(c => c.Category).ToList();
    public List<Category> Categories => _context.Categories.ToList();
    public void AddTask(ToDoTask toDoTask)
    {
        _context.Tasks.Add(toDoTask);
        _context.SaveChanges();
    }

    public void UpdateTask(ToDoTask toDoTask)
    {
        _context.Tasks.Update(toDoTask);
        _context.SaveChanges();
    }


    public void DeleteTask(ToDoTask toDoTask)
    {
        _context.Tasks.Remove(toDoTask);
        _context.SaveChanges();
        
    }
}