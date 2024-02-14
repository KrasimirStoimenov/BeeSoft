namespace BeeSoft.Web.Models.Inspections;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;
using BeeSoft.Web.Resources;
using BeeSoft.Web.Resources.Models.Inspections;

using static Common.DataAttributeConstants.Inspection;
using static Common.ResourceNameConstants;

public sealed record CreateInspectionFormModel
{
    public CreateInspectionFormModel()
    {
        this.InspectionDate = DateTime.Now;
        this.Hives = new HashSet<BaseHiveServiceModel>();
    }

    [Display(
        Name = CommonResourceName.Date,
        ResourceType = typeof(SharedResource))]
    public DateTime InspectionDate { get; init; }

    [Display(
        Name = InspectionResourceName.WeatherConditions,
        ResourceType = typeof(InspectionResource))]
    [MaxLength(WeatherConditionsMaxLength)]
    public string? WeatherConditions { get; init; }

    [Display(
        Name = InspectionResourceName.Observations,
        ResourceType = typeof(InspectionResource))]
    [Required(
        ErrorMessageResourceName = ErrorMessage.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [MaxLength(ObservationsMaxLength)]
    public string? Observations { get; init; }

    [Display(
        Name = InspectionResourceName.ActionsTaken,
        ResourceType = typeof(InspectionResource))]
    [MaxLength(ActionsTakenMaxLength)]
    public string? ActionsTaken { get; init; }

    [Display(
        Name = CommonResourceName.Hive,
        ResourceType = typeof(SharedResource))]
    [IsValidHiveId(
        ErrorMessageResourceName = ErrorMessage.NotExistingItemErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int HiveId { get; init; }

    public IEnumerable<BaseHiveServiceModel> Hives { get; init; }
}
