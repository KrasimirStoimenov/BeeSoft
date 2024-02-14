namespace BeeSoft.Web.Models.Hives;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Apiaries.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Apiaries;
using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.Hive;
using static Common.ResourceNameConstants;

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
        ErrorMessageResourceName = ErrorMessages.RangeErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int Number { get; init; }

    [Required(
        ErrorMessageResourceName = ErrorMessages.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: TypeMaxLength,
        MinimumLength = TypeMinLength,
        ErrorMessageResourceName = ErrorMessages.StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public string? Type { get; init; }

    [Required(
       ErrorMessageResourceName = ErrorMessages.RequiredFieldErrorMessageName,
       ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: StatusMaxLength,
        MinimumLength = StatusMinLength,
        ErrorMessageResourceName = ErrorMessages.StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public string? Status { get; init; }

    [MaxLength(ColorMaxLength)]
    public string? Color { get; init; }

    public DateOnly DateBought { get; init; }

    [Range(
        TimesUsedCountMinValue,
        TimesUsedCountMaxValue,
        ErrorMessageResourceName = ErrorMessages.RangeErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int TimesUsedCount { get; init; }

    [Display(Name = "Apiary")]
    [IsValidApiaryId(
        ErrorMessageResourceName = ErrorMessages.NotExistingItemErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int ApiaryId { get; init; }

    public IEnumerable<ApiaryServiceModel> Apiaries { get; set; }
}
