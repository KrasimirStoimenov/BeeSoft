namespace BeeSoft.Web.Models.BeeQueens;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;
using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.BeeQueen;
using static Common.ErrorMessageResourceNameConstants;

public sealed record CreateBeeQueenFormModel
{
    public CreateBeeQueenFormModel()
    {
        this.Hives = new HashSet<BaseHiveServiceModel>();
    }

    [Range(
        AgeMinValue,
        AgeMaxValue,
        ErrorMessageResourceName = RangeErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int Age { get; init; }

    [Display(Name = "Hive")]
    [IsValidHiveId(
        ErrorMessageResourceName = NotExistingItemErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int HiveId { get; init; }

    public IEnumerable<BaseHiveServiceModel> Hives { get; init; }
}
