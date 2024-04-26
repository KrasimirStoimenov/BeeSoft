namespace BeeSoft.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.DataAttributeConstants.Harvest;

public class Harvest
{
    [Key]
    public int Id { get; init; }

    public DateTime HarvestDate { get; init; }

    public decimal HarvestedAmount { get; init; }

    [Required]
    [MaxLength(HarvestedProductMaxLength)]
    public required string HarvestedProduct { get; init; } //(e.g., Honey, Beeswax)

    [ForeignKey(nameof(Hive))]
    public int HiveId { get; init; }

    public required Hive Hive { get; init; }
}
