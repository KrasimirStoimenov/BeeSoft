namespace BeeSoft.Web.Models.Hives;

using BeeSoft.Services.Hives.Models;

public sealed record ListAllHivesViewModel : PagingViewModel
{
    public ListAllHivesViewModel()
    {
        this.Hives = new HashSet<HiveListingServiceModel>();
    }

    public IEnumerable<HiveListingServiceModel> Hives { get; init; }
}
