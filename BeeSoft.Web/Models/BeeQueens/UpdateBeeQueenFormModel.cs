namespace BeeSoft.Web.Models.BeeQueens;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;

using static Common.DataAttributeConstants.BeeQueen;

public sealed record UpdateBeeQueenFormModel
{
    public UpdateBeeQueenFormModel()
    {
        this.IsAlive = true;
        this.Hives = new HashSet<BaseHiveServiceModel>();
    }

    public int Id { get; init; }

    [Range(AgeMinValue, AgeMaxValue)]
    public int Age { get; init; }

    [Display(Name = "Is Alive")]
    public bool IsAlive { get; init; }

    [IsValidHiveId]
    [Display(Name = "Hive")]
    public int HiveId { get; init; }

    public IEnumerable<BaseHiveServiceModel> Hives { get; init; }
}
