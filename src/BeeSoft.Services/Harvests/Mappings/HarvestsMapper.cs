namespace BeeSoft.Services.Harvests.Mappings;

using BeeSoft.Data.Models;
using BeeSoft.Services.Harvests.Models;

using Riok.Mapperly.Abstractions;

[Mapper]
internal static partial class HarvestsMapper
{
    public static partial IQueryable<BaseHarvestServiceModel> ProjectToBaseHarvestServiceModel(this IQueryable<Harvest> q);
    public static partial IQueryable<HarvestListingServiceModel> ProjectToHarvestListingServiceModel(this IQueryable<Harvest> q);

    public static partial HarvestListingServiceModel MapToHarvestListingServiceModel(this Harvest harvest);

    [MapperIgnoreSource(nameof(Harvest.Hive))]
    public static partial BaseHarvestServiceModel MapToBaseHarvestServiceModel(this Harvest harvest);

    [MapperIgnoreTarget(nameof(Harvest.Hive))]
    public static partial Harvest MapToHarvest(this BaseHarvestServiceModel baseHarvestServiceModel);
}
