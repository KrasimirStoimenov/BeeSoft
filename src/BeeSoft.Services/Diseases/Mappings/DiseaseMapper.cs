namespace BeeSoft.Services.Diseases.Mappings;

using BeeSoft.Data.Models;
using BeeSoft.Services.Diseases.Models;

using Riok.Mapperly.Abstractions;

[Mapper]
internal static partial class DiseaseMapper
{
    public static partial IQueryable<BaseDiseaseServiceModel> ProjectToBaseDiseaseServiceModel(this IQueryable<Disease> q);
    public static partial IQueryable<DiseaseListingServiceModel> ProjectToDiseaseListingServiceModel(this IQueryable<Disease> q);

    public static partial DiseaseListingServiceModel MapToDiseaseListingServiceModel(this Disease disease);

    [MapperIgnoreSource(nameof(BeeQueen.Hive))]
    public static partial BaseDiseaseServiceModel MapToBaseDiseaseServiceModel(this Disease disease);

    public static partial Disease MapToDisease(this BaseDiseaseServiceModel baseDiseaseServiceModel);
}
