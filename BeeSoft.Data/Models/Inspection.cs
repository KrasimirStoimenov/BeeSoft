namespace BeeSoft.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Inspection
{
    [Key]
    public int Id { get; init; }

    public DateTime InspectionDate { get; init; }

    [MaxLength(100)]
    public string? WeatherConditions { get; init; }

    [MaxLength(500)]
    public required string Observations { get; init; }

    [MaxLength(500)]
    public string? ActionsTaken { get; init; }

    [ForeignKey(nameof(Hive))]
    public int HiveId { get; init; }

    public required Hive Hive { get; init; }
}
