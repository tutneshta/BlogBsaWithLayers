using Api.Domain.ViewModels.Tags;

namespace Api.Domain.ViewModels.Posts;

public class ShowPostViewModel
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string AuthorId { get; set; }

    public List<TagViewModel> Tags { get; set; }

    public string Title { get; set; }

    public string Body { get; set; }
}