using weddingPlan.Models;
using Microsoft.EntityFrameworkCore;

namespace weddingPlan.Models
{
    public class weddingContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public weddingContext(DbContextOptions<weddingContext> options) : base(options) { }
        
        public DbSet<User> Users { get; set; }

        public DbSet<Wedding> Weddings {get; set;}

        public DbSet<Guest> Guests {get; set;}
        
    }
}