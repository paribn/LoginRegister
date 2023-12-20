using Microsoft.AspNetCore.Identity;

namespace login.Entities
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}
