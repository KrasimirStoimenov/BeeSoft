namespace BeeSoft.Services.Inspections.Models;
public record BaseInspectionServiceModel
{
    public int Id { get; init; }

    public DateTime InspectionDate { get; init; }

    public string? WeatherConditions { get; init; }

    public required string Observations { get; init; }

    public string? ActionsTaken { get; init; }

    public int HiveId { get; init; }
}
