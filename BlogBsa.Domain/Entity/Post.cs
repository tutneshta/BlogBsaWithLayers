namespace BlogBsa.Domain.Entity;

public class Post
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Body { get; set; } = string.Empty;
    public string AuthorId { get; set; } = string.Empty;
    public DateTime CreatedData { get; set; } = DateTime.Now;
    public List<Tag> Tags { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
    public List<User> Users { get; set; } = new();
}