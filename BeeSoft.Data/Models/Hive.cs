namespace BeeSoft.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.DataAttributeConstants.Hive;

public class Hive
{
    [Key]
    public int Id { get; init; }

    [Range(NumberMinValue, NumberMaxValue)]
    public int Number { get; init; }

    [Required]
    [MaxLength(TypeMaxLength)]
    public required string Type { get; init; } //(e.g., Langstroth, Top-bar)

    [Required]
    [MaxLength(StatusMaxLength)]
    public required string Status { get; init; } //(e.g., Active, Inactive)

    [MaxLength(ColorMaxLength)]
    public string? Color { get; init; }

    public DateOnly DateBought { get; init; }

    [Range(TimesUsedCountMinValue, TimesUsedCountMaxValue)]
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
