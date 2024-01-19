namespace BeeSoft.Services.BeeQueens.Models;

public sealed record BeeQueenServiceModel
{
    public int Id { get; init; }

    public int Age { get; init; }

    public bool IsAlive { get; init; }

    public int? HiveId { get; init; }
}
