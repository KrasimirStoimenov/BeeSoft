namespace BeeSoft.Services.Hives.Models;
public record BaseHiveServiceModel
{
    public int Id { get; init; }

    public int Number { get; init; }

    public required string Type { get; init; }

    public required string Status { get; init; }

    public string? Color { get; init; }

    public DateOnly DateBought { get; init; }

    public int TimesUsedCount { get; init; }

    public int ApiaryId { get; init; }
}
