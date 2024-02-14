namespace BeeSoft.Web.Models.Diseases;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;
using BeeSoft.Web.Resources;
using BeeSoft.Web.Resources.Models.Diseases;

using static Common.DataAttributeConstants.Disease;
using static Common.ResourceNameConstants;

public sealed record CreateDiseaseFormModel
{
    public CreateDiseaseFormModel()
    {
        this.Hives = new HashSet<BaseHiveServiceModel>();
    }

    [Display(
        Name = CommonResourceName.Name,
        ResourceType = typeof(SharedResource))]
    [Required(
        ErrorMessageResourceName = ErrorMessage.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [MaxLength(NameMaxLength)]
    public string? Name { get; init; }

    [Display(
        Name = DiseaseResourceName.Description,
        ResourceType = typeof(DiseaseResource))]
    [Required(
        ErrorMessageResourceName = ErrorMessage.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [MaxLength(DescriptionMaxLength)]
    public string? Description { get; init; }

    [Display(
        Name = DiseaseResourceName.Treatment,
        ResourceType = typeof(DiseaseResource))]
    [Required(
        ErrorMessageResourceName = ErrorMessage.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [MaxLength(TreatmentMaxLength)]
    public string? Treatment { get; init; }

    [Display(
        Name = CommonResourceName.Hive,
        ResourceType = typeof(SharedResource))]
    [IsValidHiveId(
        ErrorMessageResourceName = ErrorMessage.NotExistingItemErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int HiveId { get; init; }

    public IEnumerable<BaseHiveServiceModel> Hives { get; init; }
}
