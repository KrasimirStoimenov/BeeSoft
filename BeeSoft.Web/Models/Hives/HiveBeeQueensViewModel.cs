namespace BeeSoft.Web.Models.Hives;

using BeeSoft.Services.BeeQueens.Models;

public sealed record HiveBeeQueensViewModel : BaseHiveViewModel
{
    public HiveBeeQueensViewModel()
    {
        this.BeeQueens = new HashSet<BeeQueenListingServiceModel>();
    }

    public IEnumerable<BeeQueenListingServiceModel> BeeQueens { get; init; }
}
