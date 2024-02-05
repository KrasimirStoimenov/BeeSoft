namespace BeeSoft.Web.Models.Hives;

using BeeSoft.Services.Diseases.Models;

public sealed record HiveDiseasesViewModel : BaseHiveViewModel
{
    public HiveDiseasesViewModel()
    {
        this.Diseases = new HashSet<DiseaseListingServiceModel>();
    }

    public IEnumerable<DiseaseListingServiceModel> Diseases { get; init; }
}
