namespace BeeSoft.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Hive
{
    [Key]
    public int Id { get; init; }

    [Range(1, 1000)]
    public int Number { get; init; }

    [Required]
    [MaxLength(100)]
    public required string Type { get; init; } //(e.g., Langstroth, Top-bar)

    [Required]
    [MaxLength(100)]
    public required string Status { get; init; } //(e.g., Active, Inactive)

    [MaxLength(100)]
    public string? Color { get; init; }

    public DateOnly DateBought { get; init; }

    [Range(1, 50)]
    public int TimesUsedCount { get; init; }

    [ForeignKey(nameof(Apiary))]
    public int ApiaryId { get; init; }

    public required Apiary Apiary { get; init; }

    [ForeignKey(nameof(BeeQueen))]
    public int? BeeQueenId { get; init; }

    public BeeQueen? BeeQueen { get; init; }

    public ICollection<Inspection> Inspections { get; init; } = new HashSet<Inspection>();

    public ICollection<Disease> Diseases { get; init; } = new HashSet<Disease>();

    public ICollection<Harvest> Harvests { get; init; } = new HashSet<Harvest>();
}
