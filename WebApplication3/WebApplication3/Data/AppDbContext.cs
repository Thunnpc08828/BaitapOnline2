using Microsoft.EntityFrameworkCore;
using WebApplication3.Models;

public class AppDbContext : DbContext
{
    public DbSet<Device> Devices { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Assignment> Assignments { get; set; }

    public DbSet<AssignmentPerService> View_Assignments_Per_Service { get; set; }
    public DbSet<AssignmentStatus> View_Assignment_Status { get; set; }
    public DbSet<AssignmentPerKiosk> View_Assignments_Per_Kiosk { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=thu2005@");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AssignmentPerService>().HasNoKey().ToView("view_assignments_per_service", "demo1");
        modelBuilder.Entity<AssignmentStatus>().HasNoKey().ToView("view_assignment_status", "demo1");
        modelBuilder.Entity<AssignmentPerKiosk>().HasNoKey().ToView("view_assignments_per_kiosk", "demo1");
    }
}
