using ContactPro.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ContactPro.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        
        /* 
         * Inside ApplicationDBContext, any Model we want to be represented must 
         * be registered here
         */
        public virtual DbSet<Contact> Contacts { get; set; } = default!;
        public virtual DbSet<Category> Categories { get; set; } = default!;
    }
}