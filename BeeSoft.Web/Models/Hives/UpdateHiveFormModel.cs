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

    [Range(NumberMinValue, NumberMaxValue)]
    public int Number { get; init; }

    [Required(
        ErrorMessageResourceName = RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: TypeMaxLength,
        MinimumLength = TypeMinLength,
        ErrorMessageResourceName = DefaultStringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public string? Type { get; init; }

    [Required(
       ErrorMessageResourceName = RequiredFieldErrorMessageName,
       ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: StatusMaxLength,
        MinimumLength = StatusMinLength,
        ErrorMessageResourceName = DefaultStringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public string? Status { get; init; }

    [MaxLength(ColorMaxLength)]
    public string? Color { get; init; }

    public DateOnly DateBought { get; init; }

    [Range(TimesUsedCountMinValue, TimesUsedCountMaxValue)]
    public int TimesUsedCount { get; init; }

    [IsValidApiaryId]
    [Display(Name = "Apiary")]
    public int ApiaryId { get; init; }

    public IEnumerable<ApiaryServiceModel> Apiaries { get; set; }
}
