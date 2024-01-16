namespace BeeSoft.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Disease
{
    public int Id { get; init; }

    [Required]
    [MaxLength(100)]
    public required string Name { get; init; }

    [Required]
    [MaxLength(100)]
    public required string Description { get; init; }

    [Required]
    [MaxLength(100)]
    public required string Treatment { get; init; }

    [ForeignKey(nameof(Hive))]
    public int HiveId { get; init; }

    public required Hive Hive { get; init; }
}
