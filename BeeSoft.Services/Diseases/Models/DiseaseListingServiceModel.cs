namespace BeeSoft.Services.Diseases.Models;
public sealed record DiseaseListingServiceModel : BaseDiseaseServiceModel
{
    public int HiveNumber { get; init; }
}
