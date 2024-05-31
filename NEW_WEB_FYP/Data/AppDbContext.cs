using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NEW_WEB_FYP.Model;

namespace NEW_WEB_FYP.Data
{
    public class AppDbContext: IdentityDbContext 
    {
        internal readonly object NewsArticle;

        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<NewsArticle> NewsArticles { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        



    }
}
