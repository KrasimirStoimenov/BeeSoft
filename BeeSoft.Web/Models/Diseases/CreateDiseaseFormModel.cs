namespace BeeSoft.Web.Models.Diseases;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes;

using static Common.DataAttributeConstants.Disease;

public sealed record CreateDiseaseFormModel
{
    [Required]
    [MaxLength(NameMaxLength)]
    public string? Name { get; init; }

    [Required]
    [MaxLength(DescriptionMaxLength)]
    public string? Description { get; init; }

    [Required]
    [MaxLength(TreatmentMaxLength)]
    public string? Treatment { get; init; }

    [IsValidHiveId]
    [Display(Name = "Hive")]
    public int HiveId { get; init; }

    public IEnumerable<HiveServiceModel> Hives { get; init; } = new HashSet<HiveServiceModel>();
}
