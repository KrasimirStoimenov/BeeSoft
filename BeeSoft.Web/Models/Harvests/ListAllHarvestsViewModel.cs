namespace BeeSoft.Web.Models.Harvests;

using BeeSoft.Services.Harvests.Models;

public sealed record ListAllHarvestsViewModel : PagingViewModel
{
    public ListAllHarvestsViewModel()
    {
        this.Harvests = new HashSet<HarvestListingServiceModel>();
    }

    public IEnumerable<HarvestListingServiceModel> Harvests { get; init; }
}
