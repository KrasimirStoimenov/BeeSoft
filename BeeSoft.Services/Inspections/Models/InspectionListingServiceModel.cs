namespace BeeSoft.Services.Inspections.Models;
public sealed record InspectionListingServiceModel : BaseInspectionServiceModel
{
    public int HiveNumber { get; init; }
}
