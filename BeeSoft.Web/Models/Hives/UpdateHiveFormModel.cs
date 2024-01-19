namespace BeeSoft.Web.Models.Hives;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Apiaries.Models;

using static Common.DataAttributeConstants.Hive;
public sealed record UpdateHiveFormModel
{
    public int Id { get; init; }

    [Range(NumberMinValue, NumberMaxValue)]
    public int Number { get; init; }

    [Required]
    [StringLength(
        maximumLength: TypeMaxLength,
        MinimumLength = TypeMinLength)]
    public string? Type { get; init; }

    [Required]
    [StringLength(
        maximumLength: StatusMaxLength,
        MinimumLength = StatusMinLength)]
    public string? Status { get; init; }

    [MaxLength(ColorMaxLength)]
    public string? Color { get; init; }

    public DateOnly DateBought { get; init; }

    [Range(TimesUsedCountMinValue, TimesUsedCountMaxValue)]
    public int TimesUsedCount { get; init; }

    [Display(Name = "Apiary")]
    //TODO: ValidateId
    public int ApiaryId { get; init; }

    public IEnumerable<ApiaryServiceModel> Apiaries { get; init; } = new HashSet<ApiaryServiceModel>();
}
