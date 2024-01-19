namespace BeeSoft.Web.Models.Hives;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Apiaries.Models;

using ConcreteProducts.Web.Infrastructure.ValidationAttributes;

using static Common.DataAttributeConstants.Hive;
public sealed record CreateHiveFormModel
{
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

    [Display(Name = "Bought Date")]
    public DateOnly DateBought { get; init; } = DateOnly.FromDateTime(DateTime.Now);

    [Display(Name = "Times Used")]
    [Range(TimesUsedCountMinValue, TimesUsedCountMaxValue)]
    public int TimesUsedCount { get; init; }

    [IsValidApiaryId]
    [Display(Name = "Apiary")]
    public int ApiaryId { get; init; }

    public IEnumerable<ApiaryServiceModel> Apiaries { get; set; } = new HashSet<ApiaryServiceModel>();
}
