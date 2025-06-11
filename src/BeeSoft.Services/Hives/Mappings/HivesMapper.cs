namespace BeeSoft.Services.Hives.Mappings;

using BeeSoft.Data.Models;
using BeeSoft.Services.Hives.Models;

using Riok.Mapperly.Abstractions;

[Mapper]
internal static partial class HivesMapper
{
    public static partial IQueryable<BaseHiveServiceModel> ProjectToBaseHiveServiceModel(this IQueryable<Hive> q);
    public static partial IQueryable<HiveListingServiceModel> ProjectToHiveListingServiceModel(this IQueryable<Hive> q);
    public static partial IQueryable<HiveDetailsServiceModel> ProjectToHiveDetailsServiceModel(this IQueryable<Hive> q);

    [MapperIgnoreSource(nameof(Hive.BeeQueens))]
    [MapperIgnoreSource(nameof(Hive.Inspections))]
    [MapperIgnoreSource(nameof(Hive.Diseases))]
    [MapperIgnoreSource(nameof(Hive.Harvests))]
    [MapperIgnoreSource(nameof(Hive.Apiary))]
    public static partial BaseHiveServiceModel MapToBaseHiveServiceModel(this Hive hive);

    [MapperIgnoreSource(nameof(Hive.BeeQueens))]
    [MapperIgnoreSource(nameof(Hive.Inspections))]
    [MapperIgnoreSource(nameof(Hive.Diseases))]
    [MapperIgnoreSource(nameof(Hive.Harvests))]
    public static partial HiveListingServiceModel MapToHiveListingServiceModel(this Hive hive);

    [MapProperty(nameof(Hive.Apiary.Name), nameof(HiveDetailsServiceModel.ApiaryName))]
    public static partial HiveDetailsServiceModel MapToHiveDetailsServiceModel(this Hive hive);

    public static partial Hive MapToHive(this BaseHiveServiceModel baseHiveServiceModel);

}
