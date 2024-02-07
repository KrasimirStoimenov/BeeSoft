namespace BeeSoft.Web.Models.Inspections;

using BeeSoft.Services.Inspections.Models;

public sealed record ListAllInspectionsViewModel : PagingViewModel
{
    public ListAllInspectionsViewModel()
    {
        this.Inspections = new HashSet<InspectionListingServiceModel>();
    }

    public IEnumerable<InspectionListingServiceModel> Inspections { get; init; }
}
