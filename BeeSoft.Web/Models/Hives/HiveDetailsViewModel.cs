namespace BeeSoft.Web.Models.Hives;

public sealed record HiveDetailsViewModel
{
    public int Number { get; init; }

    public required string Type { get; init; }

    public required string Status { get; init; }

    public string? Color { get; init; }

    public DateOnly DateBought { get; init; }

    public int TimesUsedCount { get; init; }
}
