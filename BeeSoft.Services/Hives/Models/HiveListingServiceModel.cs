namespace BeeSoft.Services.Hives.Models;
using System.Collections.Generic;

using BeeSoft.Data.Models;

public sealed record HiveListingServiceModel : BaseHiveServiceModel
{
    public HiveListingServiceModel()
    {
        this.Inspections = new HashSet<Inspection>();
        this.Diseases = new HashSet<Disease>();
        this.Harvests = new HashSet<Harvest>();
        this.BeeQueens = new HashSet<BeeQueen>();
    }
    public required string ApiaryName { get; init; }

    public ICollection<Inspection> Inspections { get; init; }

    public ICollection<Disease> Diseases { get; init; }

    public ICollection<Harvest> Harvests { get; init; }

    public ICollection<BeeQueen> BeeQueens { get; init; }
}
