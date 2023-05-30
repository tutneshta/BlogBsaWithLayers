using BlogBsa.API.Data.Models.Response.Posts;
using BlogBsa.API.Data.Models.Response.Roles;
using Microsoft.AspNetCore.Identity;

namespace BlogBsa.API.Data.Models.Response.Users
{
    public class User : IdentityUser
    {
        //Id, FirstName, LastName, UserName, Email -> распологаются в классе родителя

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime CreatedData { get; set; } = DateTime.Now;

        public List<Post> Posts { get; set; } = new List<Post>();
        public List<Role> Roles { get; set; } = new List<Role>();
    }
}
