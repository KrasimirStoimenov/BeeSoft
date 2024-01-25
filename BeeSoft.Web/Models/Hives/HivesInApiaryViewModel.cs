namespace BeeSoft.Web.Models.Hives;

using BeeSoft.Services.Hives.Models;

public sealed record HivesInApiaryViewModel
{
    public HivesInApiaryViewModel()
    {
        this.Hives = new HashSet<HiveListingServiceModel>();
    }

    public required string ApiaryName { get; init; }

    public IEnumerable<HiveListingServiceModel> Hives { get; init; }
}
