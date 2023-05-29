using Microsoft.AspNetCore.Identity;

namespace BlogBsa.Domain.Entity
{
    public class Role : IdentityRole
    {
        public int? SecurityLvl { get; set; } = null;
    }
}
