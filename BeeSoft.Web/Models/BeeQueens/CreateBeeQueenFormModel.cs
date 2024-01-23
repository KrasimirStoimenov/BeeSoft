namespace BeeSoft.Web.Models.BeeQueens;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;

using static Common.DataAttributeConstants.BeeQueen;

public sealed record CreateBeeQueenFormModel
{
    public CreateBeeQueenFormModel()
    {
        this.Hives = new HashSet<HiveServiceModel>();
    }

    [Range(AgeMinValue, AgeMaxValue)]
    public int Age { get; init; }

    [IsValidHiveId]
    [Display(Name = "Hive")]
    public int HiveId { get; init; }

    public IEnumerable<HiveServiceModel> Hives { get; init; }
}
