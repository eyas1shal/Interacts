using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using eyas_Task4.Tabels;

namespace eyas_Task4.Configuration
{
    public class empconfiguration : IEntityTypeConfiguration<emp>
    {

        
            public void Configure(EntityTypeBuilder<emp> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(v => v.Name).HasMaxLength(200).IsRequired();

            builder.HasOne(e => e.city).WithMany(c => c.emps).HasForeignKey(e => e.cityId);
        }
    } }
