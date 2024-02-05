namespace BeeSoft.Web.Models.Apiaries;

using BeeSoft.Services.Hives.Models;

public sealed record ApiaryHivesViewModel
{
    public ApiaryHivesViewModel()
    {
        Hives = new HashSet<HiveListingServiceModel>();
    }

    public required string ApiaryName { get; init; }

    public IEnumerable<HiveListingServiceModel> Hives { get; init; }
}
