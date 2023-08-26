using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Task5.Tabels; // Adjust this namespace as needed

namespace Task5.Configuration
{
    public class FriendshipConfiguration : IEntityTypeConfiguration<Friendship>
    {
        public void Configure(EntityTypeBuilder<Friendship> builder)
        {
            builder.HasKey(f => f.FriendshipId);


            builder.HasOne(f => f.User)
                   .WithMany()
                   .HasForeignKey(f => f.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(f => f.Friend)
                   .WithMany() 
                   .HasForeignKey(f => f.FriendId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
