namespace BeeSoft.Web.Models.Hives;

using BeeSoft.Services.Harvests.Models;

public sealed record HiveHarvestsViewModel : BaseHiveViewModel
{
    public HiveHarvestsViewModel()
    {
        this.Harvests = new HashSet<HarvestListingServiceModel>();
    }

    public IEnumerable<HarvestListingServiceModel> Harvests { get; init; }
}
