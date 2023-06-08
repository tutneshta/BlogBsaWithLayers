using Microsoft.AspNetCore.Identity;

namespace BlogBsa.Domain.Entity;

public class Role : IdentityRole
{
    public string? Description { get; set; } = null;
    public bool IsSelected { get; set; }
}