using Building_Construction_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Building_Construction_Management_System.Data
{
    public class BuildingConstructionDbContext : DbContext
    {
        public BuildingConstructionDbContext(DbContextOptions<BuildingConstructionDbContext> options)
        : base(options) { }

        //Defining the db properties for each table

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Models.Task> Tasks { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Workforce> Workforces { get; set; }
        public DbSet<SafetyInspection> SafetyInspections { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Finance> Finances { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Document> Documents { get; set; }
    }
}
