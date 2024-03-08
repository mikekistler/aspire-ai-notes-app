namespace WebFrontend;

public class Note
{
    public Note() { }
    public Note(int id, string title, string content)
    {
        Id = id;
        Title = title;
        CreatedAt = DateTime.Now;
        UpdatedAt = CreatedAt;
        Content = content;
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool WasUpdated => UpdatedAt > CreatedAt;
    public string Content { get; set; }
}