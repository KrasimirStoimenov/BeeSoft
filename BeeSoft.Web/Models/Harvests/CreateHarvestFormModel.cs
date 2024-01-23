namespace BeeSoft.Web.Models.Harvests;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;

using static Common.DataAttributeConstants.Harvest;

public sealed record CreateHarvestFormModel
{
    public CreateHarvestFormModel()
    {
        this.HarvestDate = DateTime.Now;
        this.Hives = new HashSet<HiveServiceModel>();
    }
    public DateTime HarvestDate { get; init; }

    public decimal HarvestedAmount { get; init; }

    [Required]
    [MaxLength(HarvestedProductMaxLength)]
    public string? HarvestedProduct { get; init; }

    [IsValidHiveId]
    [Display(Name = "Hive")]
    public int HiveId { get; init; }

    public IEnumerable<HiveServiceModel> Hives { get; init; }
}
