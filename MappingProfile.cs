using AutoMapper;
using eyas_Task4.Models;
using eyas_Task4.Tabels;

namespace eyas_Task4
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<emp,empModel>()
                .ForMember(des => des.CityName, src => src.MapFrom(b => b.city.Name)).ReverseMap();


        }
    }

}
