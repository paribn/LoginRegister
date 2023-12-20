using login.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace login.DAL
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {

        //yuxarida <AppUser> yazmagimdaki sebeb Discriminator kecmesine goredi arashdir
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
    }
}
