using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission08_Team0104.Models;

public class Task
{
    [Key]
    public int TaskId { get; set; }
    
    public string TaskInfo { get; set; }
    
    public DateTime DueDate { get; set; }
    
    public string Quadrant { get; set; }

    [ForeignKey("CategoryId")]
    public int CategoryId { get; set; }
    public Category Category { get; set; }
    
    public bool Completed { get; set; }

}