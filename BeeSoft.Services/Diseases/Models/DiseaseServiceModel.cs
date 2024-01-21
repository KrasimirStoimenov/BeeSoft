namespace BeeSoft.Services.Diseases.Models;

public sealed record DiseaseServiceModel
{
    public int Id { get; init; }

    public required string Name { get; init; }

    public required string Description { get; init; }

    public required string Treatment { get; init; }

    public int HiveId { get; init; }
}
