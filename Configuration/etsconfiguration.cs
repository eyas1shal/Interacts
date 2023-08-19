using eyas_Task4.Tabels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace eyas_Task4.Configuration
{
    public class etsconfiguration:IEntityTypeConfiguration<EmpTransSalary>
    {
        public void Configure(EntityTypeBuilder<EmpTransSalary> builder)
        {
            builder.HasKey(c => c.Id);
 
            builder.HasOne(e => e.employee)
            .WithMany(c => c.ets) 
            .HasForeignKey(e => e.EmpId);

        }
    }
}
