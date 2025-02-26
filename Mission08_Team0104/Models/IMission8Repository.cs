namespace Mission08_Team0104.Models;

public interface IMission8Repository
{ 
    List<Task> Tasks { get; }
    List<Category> Categories { get; }
}