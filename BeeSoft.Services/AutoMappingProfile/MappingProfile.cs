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
        this.CreateMap<Hive, HiveServiceModel>().ReverseMap();
        this.CreateMap<BeeQueen, BeeQueenServiceModel>().ReverseMap();
        this.CreateMap<Disease, DiseaseServiceModel>().ReverseMap();
        this.CreateMap<Harvest, HarvestServiceModel>().ReverseMap();
        this.CreateMap<Inspection, InspectionServiceModel>().ReverseMap();
        this.CreateMap<Expense, ExpenseServiceModel>().ReverseMap();
    }
}
