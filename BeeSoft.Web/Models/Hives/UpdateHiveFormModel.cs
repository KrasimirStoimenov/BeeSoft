namespace BeeSoft.Web.Models.Hives;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Apiaries.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Apiaries;
using BeeSoft.Web.Resources;
using BeeSoft.Web.Resources.Models.Hives;

using static Common.DataAttributeConstants.Hive;
using static Common.ResourceNameConstants;

public sealed record UpdateHiveFormModel
{
    public UpdateHiveFormModel()
    {
        this.Apiaries = new HashSet<ApiaryServiceModel>();
    }

    public int Id { get; init; }

    [Display(
        Name = HiveResourceName.Number,
        ResourceType = typeof(HiveResource))]
    [Range(
        NumberMinValue,
        NumberMaxValue,
        ErrorMessageResourceName = ErrorMessage.RangeErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int Number { get; init; }

    [Display(
        Name = HiveResourceName.Type,
        ResourceType = typeof(HiveResource))]
    [Required(
        ErrorMessageResourceName = ErrorMessage.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: TypeMaxLength,
        MinimumLength = TypeMinLength,
        ErrorMessageResourceName = ErrorMessage.StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public string? Type { get; init; }

    [Display(
        Name = HiveResourceName.Status,
        ResourceType = typeof(HiveResource))]
    [Required(
       ErrorMessageResourceName = ErrorMessage.RequiredFieldErrorMessageName,
       ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: StatusMaxLength,
        MinimumLength = StatusMinLength,
        ErrorMessageResourceName = ErrorMessage.StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public string? Status { get; init; }

    [Display(
        Name = HiveResourceName.Color,
        ResourceType = typeof(HiveResource))]
    [MaxLength(ColorMaxLength)]
    public string? Color { get; init; }

    [Display(
        Name = HiveResourceName.BoughtDate,
        ResourceType = typeof(HiveResource))]
    public DateOnly DateBought { get; init; }

    [Display(
        Name = HiveResourceName.TimesUsed,
        ResourceType = typeof(HiveResource))]
    [Range(
        TimesUsedCountMinValue,
        TimesUsedCountMaxValue,
        ErrorMessageResourceName = ErrorMessage.RangeErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int TimesUsedCount { get; init; }

    [Display(
        Name = CommonResourceName.Apiary,
        ResourceType = typeof(SharedResource))]
    [IsValidApiaryId(
        ErrorMessageResourceName = ErrorMessage.NotExistingItemErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int ApiaryId { get; init; }

    public IEnumerable<ApiaryServiceModel> Apiaries { get; set; }
}
