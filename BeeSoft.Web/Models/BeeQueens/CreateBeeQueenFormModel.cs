namespace BeeSoft.Web.Models.BeeQueens;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;
using BeeSoft.Web.Resources;
using BeeSoft.Web.Resources.Models.BeeQueens;

using static Common.DataAttributeConstants.BeeQueen;
using static Common.ResourceNameConstants;

public sealed record CreateBeeQueenFormModel
{
    public CreateBeeQueenFormModel()
    {
        this.Hives = new HashSet<BaseHiveServiceModel>();
    }

    [Display(
        Name = BeeQueenResourceName.Age,
        ResourceType = typeof(BeeQueenResource))]
    [Range(
        AgeMinValue,
        AgeMaxValue,
        ErrorMessageResourceName = ErrorMessage.RangeErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int Age { get; init; }

    [Display(
        Name = CommonResourceName.Hive,
        ResourceType = typeof(SharedResource))]
    [IsValidHiveId(
        ErrorMessageResourceName = ErrorMessage.NotExistingItemErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int HiveId { get; init; }

    public IEnumerable<BaseHiveServiceModel> Hives { get; init; }
}
