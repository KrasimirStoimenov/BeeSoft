namespace BeeSoft.Web.Models.BeeQueens;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;
using BeeSoft.Web.Resources;
using BeeSoft.Web.Resources.Models.BeeQueens;

using static Common.DataAttributeConstants.BeeQueen;
using static Common.ResourceNameConstants;

public sealed record UpdateBeeQueenFormModel
{
    public UpdateBeeQueenFormModel()
    {
        this.Hives = new HashSet<BaseHiveServiceModel>();
    }

    public int Id { get; init; }

    [Display(
        Name = BeeQueenResourceName.Year,
        ResourceType = typeof(BeeQueenResource))]
    public int Year { get; init; }

    [Display(
        Name = BeeQueenResourceName.ColorMark,
        ResourceType = typeof(BeeQueenResource))]
    [MaxLength(ColorMarkMaxLength)]
    public string? ColorMark { get; init; }

    [Display(
        Name = BeeQueenResourceName.IsAlive,
        ResourceType = typeof(BeeQueenResource))]
    public bool IsAlive { get; init; }

    [Display(
        Name = CommonResourceName.Hive,
        ResourceType = typeof(SharedResource))]
    [IsValidHiveId(
        ErrorMessageResourceName = ErrorMessage.NotExistingItemErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int HiveId { get; init; }

    public IEnumerable<BaseHiveServiceModel> Hives { get; init; }
}
