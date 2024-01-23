namespace BeeSoft.Services.BeeQueens.Models;

public record BaseBeeQueenServiceModel
{
    public int Id { get; init; }

    public int Age { get; init; }

    public bool IsAlive { get; init; }

    public int HiveId { get; init; }
}
