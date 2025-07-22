namespace BeeSoft.Services.Inspections.Mappings;

using BeeSoft.Data.Models;
using BeeSoft.Services.Inspections.Models;

using Riok.Mapperly.Abstractions;

[Mapper]
internal static partial class InspectionsMapper
{
    public static partial IQueryable<BaseInspectionServiceModel> ProjectToBaseInspectionServiceModel(this IQueryable<Inspection> q);
    public static partial IQueryable<InspectionListingServiceModel> ProjectToInspectionListingServiceModel(this IQueryable<Inspection> q);

    public static partial InspectionListingServiceModel MapToInspectionListingServiceModel(this Inspection inspection);

    [MapperIgnoreSource(nameof(Inspection.Hive))]
    public static partial BaseInspectionServiceModel MapToBaseInspectionServiceModel(this Inspection inspection);

    [MapperIgnoreTarget(nameof(Harvest.Hive))]
    public static partial Inspection MapToInspection(this BaseInspectionServiceModel baseInspectionServiceModel);
}
