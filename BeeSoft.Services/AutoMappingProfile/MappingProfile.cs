namespace BeeSoft.Services.AutoMappingProfile;

using AutoMapper;

using BeeSoft.Data.Models;
using BeeSoft.Services.Apiaries.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreateMap<Apiary, ApiaryServiceModel>().ReverseMap();
    }
}
