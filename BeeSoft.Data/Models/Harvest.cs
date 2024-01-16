namespace BeeSoft.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Harvest
{
    public int Id { get; init; }

    public DateTime HarvestDate { get; init; }

    public double HarvestedAmount { get; init; }

    [Required]
    [MaxLength(100)]
    public required string HarvestedProduct { get; init; } //(e.g., Honey, Beeswax)

    [ForeignKey(nameof(Hive))]
    public int HiveId { get; init; }

    public required Hive Hive { get; init; }
}
