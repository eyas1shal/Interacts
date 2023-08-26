using AutoMapper;
using Task5.Tabels;
using Task5.Models; // Replace with your actual model namespace

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserModel>()
            .ForMember(dest => dest.NumFriends, opt => opt.MapFrom(src => CalculateNumFriends(src.Friendships)));
    }

    private static int CalculateNumFriends(ICollection<Friendship> friendships)
    {
        // Implement the logic to calculate the number of friends
        return friendships.Count;
    }
}
