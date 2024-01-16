namespace BeeSoft.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class BeeQueen
{
    [Key]
    public int Id { get; init; }

    [Range(0, 10)]
    public int Age { get; init; }

    public bool IsAlive { get; init; }

    [ForeignKey(nameof(Hive))]
    public int? HiveId { get; init; }

    public Hive? Hive { get; init; }
}
