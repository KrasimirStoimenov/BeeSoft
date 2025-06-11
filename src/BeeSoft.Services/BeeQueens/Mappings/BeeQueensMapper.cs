namespace BeeSoft.Services.BeeQueens.Mappings;

using BeeSoft.Data.Models;
using BeeSoft.Services.BeeQueens.Models;

using Riok.Mapperly.Abstractions;

[Mapper]
internal static partial class BeeQueensMapper
{
    public static partial IQueryable<BaseBeeQueenServiceModel> ProjectToBaseBeeQueenServiceModel(this IQueryable<BeeQueen> q);
    public static partial IQueryable<BeeQueenListingServiceModel> ProjectToBeeQueenListingServiceModel(this IQueryable<BeeQueen> q);

    [MapperIgnoreSource(nameof(BeeQueen.Hive))]
    public static partial BaseBeeQueenServiceModel MapToBaseBeeQueenServiceModel(this BeeQueen beeQueen);

    public static partial BeeQueenListingServiceModel MapToBeeQueenListingServiceModel(this BeeQueen beeQueen);

    public static partial BeeQueen MapToBeeQueen(this BaseBeeQueenServiceModel beeQueenServiceModel);
}
