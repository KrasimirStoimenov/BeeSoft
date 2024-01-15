namespace BeeSoft.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Beehive
{
    [Key]
    public int Id { get; init; }

    [Range(1, 1000)]
    public int Number { get; init; }

    public string? Color { get; init; }

    public DateOnly DateBought { get; init; }

    public decimal Price { get; init; }

    public int ApiaryId { get; init; }

    public required Apiary Apiary { get; init; }

    [ForeignKey(nameof(BeeQueen))]
    public int? BeeQueenId { get; init; }

    public BeeQueen? BeeQueen { get; init; }

}
