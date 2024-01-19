namespace BeeSoft.Services.AutoMappingProfile;

using AutoMapper;

using BeeSoft.Data.Models;
using BeeSoft.Services.Apiaries.Models;
using BeeSoft.Services.BeeQueens.Models;
using BeeSoft.Services.Hives.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreateMap<Apiary, ApiaryServiceModel>().ReverseMap();
        this.CreateMap<Hive, HiveServiceModel>().ReverseMap();
        this.CreateMap<BeeQueen, BeeQueenServiceModel>().ReverseMap();
    }
}
