namespace BeeSoft.Web.Models.Diseases;

using BeeSoft.Services.Diseases.Models;

public sealed record ListAllDiseasesViewModel : PagingViewModel
{
    public ListAllDiseasesViewModel()
    {
        this.Diseases = new HashSet<DiseaseListingServiceModel>();
    }

    public IEnumerable<DiseaseListingServiceModel> Diseases { get; init; }
}
