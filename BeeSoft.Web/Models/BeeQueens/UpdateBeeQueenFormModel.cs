namespace BeeSoft.Web.Models.BeeQueens;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;
using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.BeeQueen;
using static Common.ErrorMessageResourceNameConstants;

public sealed record UpdateBeeQueenFormModel
{
    public UpdateBeeQueenFormModel()
    {
        this.IsAlive = true;
        this.Hives = new HashSet<BaseHiveServiceModel>();
    }

    public int Id { get; init; }

    [Range(
        AgeMinValue,
        AgeMaxValue,
        ErrorMessageResourceName = RangeErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int Age { get; init; }

    [Display(Name = "Is Alive")]
    public bool IsAlive { get; init; }

    [Display(Name = "Hive")]
    [IsValidHiveId(
        ErrorMessageResourceName = NotExistingItemErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int HiveId { get; init; }

    public IEnumerable<BaseHiveServiceModel> Hives { get; init; }
}
