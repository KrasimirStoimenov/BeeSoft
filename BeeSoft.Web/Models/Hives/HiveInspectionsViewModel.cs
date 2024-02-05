namespace BeeSoft.Web.Models.Hives;

using BeeSoft.Services.Inspections.Models;

public sealed record HiveInspectionsViewModel : BaseHiveViewModel
{
    public HiveInspectionsViewModel()
    {
        this.Inspections = new HashSet<InspectionListingServiceModel>();
    }

    public IEnumerable<InspectionListingServiceModel> Inspections { get; init; }
}
