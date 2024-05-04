using AutoMapper;
using AutoMapperApı.DTO;
using AutoMapperApı.Entities;

namespace AutoMapperApı.Mapping
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
           CreateMap<Customer, CustomerDTO>().ForMember (dest =>dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)).ReverseMap();
        }
    }
}
