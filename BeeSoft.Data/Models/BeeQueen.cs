namespace BeeSoft.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.DataAttributeConstants.BeeQueen;

public class BeeQueen
{
    [Key]
    public int Id { get; init; }

    [Range(AgeMinValue, AgeMaxValue)]
    public int Age { get; init; }

    public bool IsAlive { get; init; }

    [ForeignKey(nameof(Hive))]
    public int HiveId { get; init; }

    public required Hive Hive { get; init; }
}
