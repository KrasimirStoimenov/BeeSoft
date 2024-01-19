namespace BeeSoft.Data.Models;

using System.ComponentModel.DataAnnotations;

using static Common.DataAttributeConstants.Apiary;

public class Apiary
{
    [Key]
    public int Id { get; init; }

    [Required]
    [MaxLength(NameMaxLength)]
    public required string Name { get; init; }

    [Required]
    [MaxLength(LocationMaxLength)]
    public required string Location { get; init; }

    public ICollection<Hive> Hives { get; init; } = new HashSet<Hive>();
}
