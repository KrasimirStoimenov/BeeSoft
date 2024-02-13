namespace BeeSoft.Web.Models.Harvests;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;
using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.Harvest;
using static Common.ErrorMessageResourceNameConstants;

public sealed record CreateHarvestFormModel
{
    public CreateHarvestFormModel()
    {
        this.HarvestDate = DateTime.Now;
        this.Hives = new HashSet<BaseHiveServiceModel>();
    }
    public DateTime HarvestDate { get; init; }

    public decimal HarvestedAmount { get; init; }

    [Required(
       ErrorMessageResourceName = RequiredFieldErrorMessageName,
       ErrorMessageResourceType = typeof(SharedResource))]
    [MaxLength(HarvestedProductMaxLength)]
    public string? HarvestedProduct { get; init; }

    [IsValidHiveId]
    [Display(Name = "Hive")]
    public int HiveId { get; init; }

    public IEnumerable<BaseHiveServiceModel> Hives { get; init; }
}
