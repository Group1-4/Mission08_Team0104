using System.ComponentModel.DataAnnotations;

namespace Mission08_Team0104.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    
    public List<ToDoTask> Tasks { get; set; } = new List<ToDoTask>();
}