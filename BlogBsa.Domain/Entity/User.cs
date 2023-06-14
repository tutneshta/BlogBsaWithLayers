using System.Collections;
using Microsoft.AspNetCore.Identity;

namespace BlogBsa.Domain.Entity;

public class User : IdentityUser
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime CreatedData { get; set; } = DateTime.Now;
    public List<Post> Posts { get; set; } = new();
    public List<Role> Roles { get; set; } = new();

}