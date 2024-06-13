namespace BeeSoft.Services.Apiaries.Models;

using BeeSoft.Services.Hives.Models;

public sealed record ApiaryServiceModel
{
    public int Id { get; init; }

    public required string Name { get; init; }

    public required string Location { get; init; }

    public ICollection<BaseHiveServiceModel> Hives { get; init; } = new HashSet<BaseHiveServiceModel>();
}
