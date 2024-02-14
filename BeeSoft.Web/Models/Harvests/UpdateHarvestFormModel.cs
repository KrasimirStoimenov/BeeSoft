namespace BeeSoft.Web.Models.Harvests;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;
using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.Harvest;
using static Common.ResourceNameConstants;

public sealed record UpdateHarvestFormModel
{
    public UpdateHarvestFormModel()
    {
        this.Hives = new HashSet<BaseHiveServiceModel>();
    }

    public int Id { get; init; }

    public DateTime HarvestDate { get; init; }

    public decimal HarvestedAmount { get; init; }

    [Required(
        ErrorMessageResourceName = ErrorMessages.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [MaxLength(HarvestedProductMaxLength)]
    public string? HarvestedProduct { get; init; }

    [Display(Name = "Hive")]
    [IsValidHiveId(
        ErrorMessageResourceName = ErrorMessages.NotExistingItemErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int HiveId { get; init; }

    public IEnumerable<BaseHiveServiceModel> Hives { get; set; }
}
