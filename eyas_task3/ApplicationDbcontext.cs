using eyas_task3.Configuration;
using eyas_task3.Tables;
using Microsoft.EntityFrameworkCore;

namespace eyas_task3
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

        public DbSet<Courses> Courses { get; set; }
        public DbSet<Student> Students { get; set; }

        public DbSet<StC> StCs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         //   modelBuilder.Entity<Student>().HasData(new Student { Id=1,Name="asem" });
            modelBuilder.ApplyConfiguration(new StCconfiguration());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

    }
}
