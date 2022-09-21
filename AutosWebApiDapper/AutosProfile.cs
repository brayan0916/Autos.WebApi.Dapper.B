using AutoMapper;

namespace AutosWebApiDapper
{
    public class AutosProfile: Profile
    {
        public AutosProfile()
        {
            CreateMap<AutosEntity, AutosDto>();
            CreateMap<AutosDto, AutosEntity>();
        }
    }
}
