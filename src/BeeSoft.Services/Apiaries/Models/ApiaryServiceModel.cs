namespace BeeSoft.Services.Apiaries.Models;

public sealed record ApiaryServiceModel
{
    public int Id { get; init; }

    public required string Name { get; init; }

    public required string Location { get; init; }

    public int ApiaryHivesCount { get; init; }
}
