using Microsoft.AspNetCore.Identity;

namespace Api.Domain.Entity;

public class Role : IdentityRole
{
    public string? Description { get; set; } = null;
    public bool IsSelected { get; set; }
}