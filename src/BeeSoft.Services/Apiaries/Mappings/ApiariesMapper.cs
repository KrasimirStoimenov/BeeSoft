namespace BeeSoft.Services.Apiaries.Mappings;

using BeeSoft.Data.Models;
using BeeSoft.Services.Apiaries.Models;

using Riok.Mapperly.Abstractions;

[Mapper]
internal static partial class ApiariesMapper
{
    public static partial IQueryable<ApiaryServiceModel> ProjectToApiaryServiceModel(this IQueryable<Apiary> q);

    [MapPropertyFromSource(nameof(ApiaryServiceModel.ApiaryHivesCount), Use = nameof(HivesCount))]
    public static partial ApiaryServiceModel MapToApiaryServiceModel(this Apiary apiary);

    [MapperIgnoreSource(nameof(ApiaryServiceModel.ApiaryHivesCount))]
    [MapperIgnoreTarget(nameof(Apiary.Hives))]
    public static partial Apiary MapToApiary(this ApiaryServiceModel baseApiaryServiceModel);

    private static int HivesCount(Apiary apiary)
        => apiary.Hives.Count;
}
