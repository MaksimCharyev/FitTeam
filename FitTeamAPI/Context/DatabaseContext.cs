using Microsoft.EntityFrameworkCore;
using FitTeamAPI.Models.Comment;
using FitTeamAPI.Models.Course;
using FitTeamAPI.Models.Document;
using FitTeamAPI.Models.Event;
using FitTeamAPI.Models.Norm;
using FitTeamAPI.Models.Permission;
using FitTeamAPI.Models.Role;
using FitTeamAPI.Models.SalePlan;
using FitTeamAPI.Models.Subdivision;
using FitTeamAPI.Models.TestNQuestions;
using FitTeamAPI.Models.Worker;

namespace FitTeamAPI.Context
{
    public class DatabaseContext: DbContext
    {
        public DbSet<Worker> workers { get; set; }
        public DbSet<Worker_complete_course> workers_courses { get; set; }
        public DbSet<Worker_did_test> workers_did_tests { get; set; }
        public DbSet<Worker_does_norm> workers_does_norms { get; set; }
        public DbSet<Worker_has_comment> workers_has_comments { get; set; }
        public DbSet<Worker_has_role> workers_has_Roles { get; set; }
        public DbSet<Worker_know_doc> workers_know_docs { get; set; }
        public DbSet<Worker_on_event> workers_on_events { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Role_has_course> roles_has_courses { get; set; }
        public DbSet<Role_has_doc> roles_has_docs { get; set; }
        public DbSet<Role_has_norm> roles_has_norms { get; set; }
        public DbSet<Role_has_perm> roles_has_perms { get; set; }
        public DbSet<Role_has_test> roles_has_tests { get; set; }
        public DbSet<Role_on_event> roles_on_events { get; set; }
        public DbSet<Permission> permissions { get; set; }
        public DbSet<Subdivision> subdivisions { get; set; }
        public DbSet<Subdivision_has_course> subdivisions_has_courses { get; set; }
        public DbSet<Subdivision_has_doc> subdivisions_has_docs { get; set; }
        public DbSet<Subdivision_has_norm> subdivisions_has_norms { get; set; }
        public DbSet<Subdivision_has_plan> subdivisions_has_plans { get; set; }
        public DbSet<Subdivision_has_test> subdivisions_has_tests { get; set; }
        public DbSet<Subdivision_on_event> subdivisions_on_events { get; set; }
        public DbSet<Document> documents { get; set; }
        public DbSet<Test> tests { get; set; }
        public DbSet<Test_has_question> tests_has_questions { get; set; }
        public DbSet<Question> questions { get; set; }
        public DbSet<Event> events { get; set; }
        public DbSet<SalePlan> salePlans { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Norm> norms { get; set; }
        public DbSet<Course> courses { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureDeleted();
              
        }
    }
}
