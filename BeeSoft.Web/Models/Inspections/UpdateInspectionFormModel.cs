﻿namespace BeeSoft.Web.Models.Inspections;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;

using static Common.DataAttributeConstants.Inspection;

public sealed record UpdateInspectionFormModel
{
    public UpdateInspectionFormModel()
    {
        this.Hives = new HashSet<BaseHiveServiceModel>();
    }
    public int Id { get; init; }

    public DateTime InspectionDate { get; init; }

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

    public IEnumerable<BaseHiveServiceModel> Hives { get; init; }
}
