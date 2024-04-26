namespace BeeSoft.Services.BeeQueens.Models;

public record BaseBeeQueenServiceModel
{
    public int Id { get; init; }

    public int Year { get; init; }

    public string? ColorMark { get; init; }

    public bool IsAlive { get; init; }

    public int HiveId { get; init; }
}
