using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<AssignmentPerKiosk> View_Assignments_Per_Kiosk { get; set; } = null!;
        public DbSet<AssignmentStatus> View_Assignment_Status { get; set; } = null!;
        public DbSet<AssignmentPerService> View_Assignments_Per_Service { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AssignmentPerKiosk>().HasNoKey().ToView("View_Assignments_Per_Kiosk");
            modelBuilder.Entity<AssignmentStatus>().HasNoKey().ToView("View_Assignment_Status");
            modelBuilder.Entity<AssignmentPerService>().HasNoKey().ToView("View_Assignments_Per_Service");
        }

        public async Task RefreshMaterializedViewsAsync()
        {
            await Database.ExecuteSqlRawAsync("REFRESH MATERIALIZED VIEW View_Assignments_Per_Kiosk;");
            await Database.ExecuteSqlRawAsync("REFRESH MATERIALIZED VIEW View_Assignment_Status;");
            await Database.ExecuteSqlRawAsync("REFRESH MATERIALIZED VIEW View_Assignments_Per_Service;");
        }
    }
}
