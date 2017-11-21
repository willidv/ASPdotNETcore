using Microsoft.EntityFrameworkCore;
 
namespace WeddingPlanner.Models
{
    public class WeddingPlannerContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public WeddingPlannerContext(DbContextOptions<WeddingPlannerContext> options) : base(options) { }
        
        public DbSet<User> User { get; set; }
        public DbSet<Guest> Guest { get; set; }
        public DbSet<Wedding> Wedding { get; set; }
        
    }
}