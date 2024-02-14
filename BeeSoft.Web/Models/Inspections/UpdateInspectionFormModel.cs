namespace BeeSoft.Web.Models.Inspections;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;
using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.Inspection;
using static Common.ResourceNameConstants;

public sealed record UpdateInspectionFormModel
{
    public UpdateInspectionFormModel()
    {
        this.Hives = new HashSet<BaseHiveServiceModel>();
    }
    public int Id { get; init; }

    [Display(
        Name = CommonResourceName.Date,
        ResourceType = typeof(SharedResource))]
    public DateTime InspectionDate { get; init; }

    [MaxLength(WeatherConditionsMaxLength)]
    public string? WeatherConditions { get; init; }

    [Required(
        ErrorMessageResourceName = ErrorMessage.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [MaxLength(ObservationsMaxLength)]
    public string? Observations { get; init; }

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
