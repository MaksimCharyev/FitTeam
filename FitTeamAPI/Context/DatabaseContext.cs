using Microsoft.EntityFrameworkCore;
using FitTeamAPI.Models;
namespace FitTeamAPI.Context
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Worker> workers { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Permission> permissions { get; set; }
        public DbSet<Subdivision> subdivisions { get; set; }
        public DbSet<Document> documents { get; set; }
        public DbSet<Test> tests { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<SalePlan> salePlans { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Norm> norms { get; set; }
        public DbSet<Course> courses { get; set; }
        public DatabaseContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();   
        }

    }
}
