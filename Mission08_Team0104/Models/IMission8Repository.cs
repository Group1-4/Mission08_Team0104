namespace Mission08_Team0104.Models;

public interface IMission8Repository
{ 
    List<ToDoTask> Tasks { get; }
    List<Category> Categories { get; }
}