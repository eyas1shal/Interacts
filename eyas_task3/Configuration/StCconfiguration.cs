using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using eyas_task3.Tables;

namespace eyas_task3.Configuration
{
    public class StCconfiguration: IEntityTypeConfiguration<StC>
        {
            public void Configure(EntityTypeBuilder<StC> builder)
            {

            builder.HasKey(d=>new {d.StId,d.CId});

            builder.HasOne(c => c.Student).WithMany(c => c.StCs).HasForeignKey(h => h.StId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(c => c.Courses).WithMany(c => c.StCs).HasForeignKey(h => h.CId)
                .OnDelete(DeleteBehavior.Restrict);



        }
        
    }
}
