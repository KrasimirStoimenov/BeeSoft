namespace BeeSoft.Web.Models.Apiaries;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.Apiary;
using static Common.ErrorMessageResourceNameConstants;

public class CreateApiaryFormModel
{
    [Display(Name = "Apiary name")]
    [Required(
        ErrorMessageResourceName = RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: NameMaxLength,
        MinimumLength = NameMinLength,
        ErrorMessageResourceName = StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public required string Name { get; init; }

    [Required(
        ErrorMessageResourceName = RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: LocationMaxLength,
        MinimumLength = LocationMinLength,
        ErrorMessageResourceName = StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public required string Location { get; init; }
}
