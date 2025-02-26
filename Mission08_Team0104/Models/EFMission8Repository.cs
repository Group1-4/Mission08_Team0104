namespace Mission08_Team0104.Models;

public class EFMission8Repository : IMission8Repository
{
    private Mission8DatabaseContext _context;

    public EFMission8Repository(Mission8DatabaseContext temp)
    {
        _context = temp;
    }
    public List<Task> Tasks => _context.Tasks.ToList();
    public List<Category> Categories => _context.Categories.ToList();
}