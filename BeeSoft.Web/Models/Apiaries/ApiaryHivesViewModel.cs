namespace BeeSoft.Web.Models.Apiaries;

using BeeSoft.Services.Hives.Models;

public sealed record ApiaryHivesViewModel
{
    public ApiaryHivesViewModel()
    {
        Hives = new HashSet<BaseHiveServiceModel>();
    }

    public required string ApiaryName { get; init; }

    public IEnumerable<BaseHiveServiceModel> Hives { get; init; }
}
