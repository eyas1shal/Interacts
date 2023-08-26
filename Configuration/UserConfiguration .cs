using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task5.Tabels; // Adjust this namespace as needed

namespace Task5.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.UserId);

            // Other property configurations

            builder.HasMany(u => u.Friendships)
                   .WithOne(f => f.User)
                   .HasForeignKey(f => f.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
            // Configure other relationships
            /*
            builder.HasMany(u => u.Friendships)
                   .WithOne(f => f.Friend)
                   .HasForeignKey(f => f.FriendId)
                   .OnDelete(DeleteBehavior.Restrict);
            
            builder.Property<int>("NumFriends")
               .HasComputedColumnSql("dbo.[CalculateNumFriends]([UserId])");

            builder.Property<int>("NumFriends")
                  
                  .UsePropertyAccessMode(PropertyAccessMode.Field)
                 
                  .HasComputedColumnSql("SELECT COUNT(*) FROM Friendship WHERE UserId = UserId OR FriendId = UserId");
*/

            builder.Property(v => v.Email).IsRequired().HasMaxLength(500);
            builder.HasIndex(v => v.Email).IsUnique();
            builder.Property(v => v.FullName).IsRequired().HasMaxLength(100);
            builder.Property(v => v.Password).IsRequired().HasMaxLength(2000);

            // Configure other relationships
        }
    }
}
