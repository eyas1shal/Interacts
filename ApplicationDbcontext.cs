
using eyas_Task4.Configuration;
using eyas_Task4.Tabels;
using Microsoft.EntityFrameworkCore;

namespace eyas_Task4
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }

        public DbSet<emp> emps{ get; set; }
        public DbSet<city> cities { get; set; }

        public DbSet<EmpTransSalary> empTransSalaries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new empconfiguration());
            modelBuilder.ApplyConfiguration(new etsconfiguration());
        }
    }
}
