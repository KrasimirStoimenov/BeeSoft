namespace BeeSoft.Services.AutoMappingProfile;

using AutoMapper;

using BeeSoft.Data.Models;
using BeeSoft.Services.Apiaries.Models;
using BeeSoft.Services.BeeQueens.Models;
using BeeSoft.Services.Diseases.Models;
using BeeSoft.Services.Expenses.Models;
using BeeSoft.Services.Harvests.Models;
using BeeSoft.Services.Hives.Models;
using BeeSoft.Services.Inspections.Models;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        this.CreateMap<Apiary, ApiaryServiceModel>().ReverseMap();

        this.CreateMap<Hive, BaseHiveServiceModel>().ReverseMap();
        this.CreateMap<Hive, HiveListingServiceModel>()
            .ForMember(x => x.ApiaryName, opts => opts.MapFrom(a => a.Apiary.Name));
        this.CreateMap<Hive, HiveDetailsServiceModel>()
            .ForMember(x => x.ApiaryName, opts => opts.MapFrom(a => a.Apiary.Name));

        this.CreateMap<BeeQueen, BaseBeeQueenServiceModel>().ReverseMap();
        this.CreateMap<BeeQueen, BeeQueenListingServiceModel>()
            .ForMember(x => x.HiveNumber, opts => opts.MapFrom(h => h.Hive.Number));

        this.CreateMap<Disease, BaseDiseaseServiceModel>().ReverseMap();
        this.CreateMap<Disease, DiseaseListingServiceModel>()
            .ForMember(x => x.HiveNumber, opts => opts.MapFrom(h => h.Hive.Number));

        this.CreateMap<Harvest, BaseHarvestServiceModel>().ReverseMap();
        this.CreateMap<Harvest, HarvestListingServiceModel>()
            .ForMember(x => x.HiveNumber, opts => opts.MapFrom(h => h.Hive.Number));

        this.CreateMap<Inspection, BaseInspectionServiceModel>().ReverseMap();
        this.CreateMap<Inspection, InspectionListingServiceModel>()
            .ForMember(x => x.HiveNumber, opts => opts.MapFrom(h => h.Hive.Number));

        this.CreateMap<Expense, ExpenseServiceModel>().ReverseMap();

    }
}
