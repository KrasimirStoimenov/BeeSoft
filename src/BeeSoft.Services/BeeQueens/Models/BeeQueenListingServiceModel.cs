namespace BeeSoft.Services.BeeQueens.Models;
public sealed record BeeQueenListingServiceModel : BaseBeeQueenServiceModel
{
    public int HiveNumber { get; init; }
}
