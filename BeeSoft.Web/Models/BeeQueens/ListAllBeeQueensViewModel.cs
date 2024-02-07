namespace BeeSoft.Web.Models.BeeQueens;

using BeeSoft.Services.BeeQueens.Models;

public sealed record ListAllBeeQueensViewModel : PagingViewModel
{
    public ListAllBeeQueensViewModel()
    {
        this.BeeQueens = new HashSet<BeeQueenListingServiceModel>();
    }

    public IEnumerable<BeeQueenListingServiceModel> BeeQueens { get; init; }
}
