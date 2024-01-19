namespace BeeSoft.Data.Models;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static Common.DataAttributeConstants.Disease;

public class Disease
{
    [Key]
    public int Id { get; init; }

    [Required]
    [MaxLength(NameMaxLength)]
    public required string Name { get; init; }

    [Required]
    [MaxLength(DescriptionMaxLength)]
    public required string Description { get; init; }

    [Required]
    [MaxLength(TreatmentMaxLength)]
    public required string Treatment { get; init; }

    [ForeignKey(nameof(Hive))]
    public int HiveId { get; init; }

    public required Hive Hive { get; init; }
}
