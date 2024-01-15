namespace BeeSoft.Data.Models;

using System.ComponentModel.DataAnnotations;

public class Apiary
{
    [Key]
    public int Id { get; init; }

    public DateOnly? StartOfHoneyCollectionPeriod { get; init; }

    public DateOnly? ProbableEndOfHoneyCollectionPeriod { get; init; }

    public decimal TotalHoneyHarvested { get; init; }

    public ICollection<Beehive> Beehives { get; init; } = new HashSet<Beehive>();
}
