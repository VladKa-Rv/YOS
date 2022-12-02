using AutoMapper;
using YOS.Domain.Domain;

namespace YOS.Application.AutoMapper.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserProfile>();
        }
    }
}
