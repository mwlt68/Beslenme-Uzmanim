using AutoMapper;
using UserInsertModel = Nutritionist.Core.Models.User.Insert;
using UserDetailModel = Nutritionist.Core.Models.User.Detail;


namespace Nutritionist.Services.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Add as many of these lines as you need to map your objects
            CreateMap<UserInsertModel, Data.Entities.User>();
            CreateMap< Data.Entities.User, UserDetailModel>();
        }
    }
}
