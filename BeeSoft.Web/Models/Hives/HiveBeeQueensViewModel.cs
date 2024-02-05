namespace BeeSoft.Web.Models.Hives;

using BeeSoft.Services.BeeQueens.Models;

public sealed record HiveBeeQueensViewModel
{
    public HiveBeeQueensViewModel()
    {
        this.BeeQueens = new HashSet<BeeQueenListingServiceModel>();
    }

    public int HiveNumber { get; init; }

    public IEnumerable<BeeQueenListingServiceModel> BeeQueens { get; init; }
}
