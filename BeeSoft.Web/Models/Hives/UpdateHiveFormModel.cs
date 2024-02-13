namespace BeeSoft.Web.Models.Hives;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Apiaries.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Apiaries;
using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.Hive;
using static Common.ErrorMessageResourceNameConstants;

public sealed record UpdateHiveFormModel
{
    public UpdateHiveFormModel()
    {
        this.Apiaries = new HashSet<ApiaryServiceModel>();
    }

    public int Id { get; init; }

    [Range(
        NumberMinValue,
        NumberMaxValue,
        ErrorMessageResourceName = RangeErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int Number { get; init; }

    [Required(
        ErrorMessageResourceName = RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: TypeMaxLength,
        MinimumLength = TypeMinLength,
        ErrorMessageResourceName = StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public string? Type { get; init; }

    [Required(
       ErrorMessageResourceName = RequiredFieldErrorMessageName,
       ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: StatusMaxLength,
        MinimumLength = StatusMinLength,
        ErrorMessageResourceName = StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public string? Status { get; init; }

    [MaxLength(ColorMaxLength)]
    public string? Color { get; init; }

    public DateOnly DateBought { get; init; }

    [Range(
        TimesUsedCountMinValue,
        TimesUsedCountMaxValue,
        ErrorMessageResourceName = RangeErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int TimesUsedCount { get; init; }

    [Display(Name = "Apiary")]
    [IsValidApiaryId(
        ErrorMessageResourceName = NotExistingItemErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int ApiaryId { get; init; }

    public IEnumerable<ApiaryServiceModel> Apiaries { get; set; }
}
