namespace BeeSoft.Services.Harvests.Models;
public sealed record HarvestListingServiceModel : BaseHarvestServiceModel
{
    public int HiveNumber { get; init; }
}
