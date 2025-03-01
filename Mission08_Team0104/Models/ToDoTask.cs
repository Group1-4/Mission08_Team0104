using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0104.Models;

public class ToDoTask
{
    [Key] [Required] 
    public int TaskId { get; set; }

    [Required]
    public string TaskInfo { get; set; }

    [Required]
    public DateTime DueDate { get; set; }

    [Required]
    public string Quandrant { get; set; }

    [Required(ErrorMessage = "Select a category")]
    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
    public bool Completed { get; set; }
    // public List<Category> Categories { get; set; } = new List<Category>();
   
}