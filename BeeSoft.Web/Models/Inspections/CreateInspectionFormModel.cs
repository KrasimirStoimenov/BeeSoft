namespace BeeSoft.Web.Models.Inspections;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes;

using static Common.DataAttributeConstants.Inspection;

public sealed record CreateInspectionFormModel
{
    public DateTime InspectionDate { get; init; } = DateTime.Now;

    [MaxLength(WeatherConditionsMaxLength)]
    public string? WeatherConditions { get; init; }

    [Required]
    [MaxLength(ObservationsMaxLength)]
    public string? Observations { get; init; }

    [MaxLength(ActionsTakenMaxLength)]
    public string? ActionsTaken { get; init; }

    [IsValidHiveId]
    [Display(Name = "Hive")]
    public int HiveId { get; init; }

    public IEnumerable<HiveServiceModel> Hives { get; init; } = new HashSet<HiveServiceModel>();
}
