namespace BeeSoft.Services.AutoMappingProfile;

using AutoMapper;

using BeeSoft.Data.Models;
using BeeSoft.Services.Apiary.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreateMap<Apiary, ApiaryServiceModel>();
    }
}
