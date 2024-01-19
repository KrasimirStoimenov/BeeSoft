namespace BeeSoft.Services.Hives.Models;
using BeeSoft.Data.Models;

public sealed record HiveServiceModel
{
    public int Id { get; init; }

    public int Number { get; init; }

    public required string Type { get; init; }

    public required string Status { get; init; }

    public string? Color { get; init; }

    public DateOnly DateBought { get; init; }

    public int TimesUsedCount { get; init; }

    public int ApiaryId { get; init; }

    public ICollection<Inspection> Inspections { get; init; } = new HashSet<Inspection>();

    public ICollection<Disease> Diseases { get; init; } = new HashSet<Disease>();

    public ICollection<Harvest> Harvests { get; init; } = new HashSet<Harvest>();
}
