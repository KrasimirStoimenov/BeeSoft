namespace BeeSoft.Services.Apiary.Models;

using BeeSoft.Data.Models;

public sealed record ApiaryServiceModel
{
    public int Id { get; init; }

    public required string Name { get; init; }

    public required string Location { get; init; }

    public ICollection<Hive> Hives { get; init; } = new HashSet<Hive>();
}
