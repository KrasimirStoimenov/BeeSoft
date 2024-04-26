namespace BeeSoft.Services.Harvests.Models;
public record BaseHarvestServiceModel
{
    public int Id { get; init; }

    public DateTime HarvestDate { get; init; }

    public decimal HarvestedAmount { get; init; }

    public required string HarvestedProduct { get; init; } //(e.g., Honey, Beeswax)

    public int HiveId { get; init; }
}
