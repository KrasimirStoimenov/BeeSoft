namespace BeeSoft.Web.Models.Hives;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Apiaries.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Apiaries;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;
using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.Hive;
using static Common.ErrorMessageResourceNameConstants;
public sealed record CreateHiveFormModel
{
    public CreateHiveFormModel()
    {
        this.DateBought = DateOnly.FromDateTime(DateTime.Now);
        this.TimesUsedCount = 1;
        this.Apiaries = new HashSet<ApiaryServiceModel>();
    }

    [IsValidHiveNumber(
        ErrorMessageResourceName = AlreadyExistingHiveNumberErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
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

    [Display(Name = "Bought Date")]
    public DateOnly DateBought { get; init; }

    [Display(Name = "Times Used")]
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
