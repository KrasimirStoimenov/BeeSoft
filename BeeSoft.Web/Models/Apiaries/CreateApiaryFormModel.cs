namespace BeeSoft.Web.Models.Apiaries;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.Apiary;
using static Common.ResourceNameConstants;

public class CreateApiaryFormModel
{
    [Display(Name = "Apiary name")]
    [Required(
        ErrorMessageResourceName = ErrorMessages.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: NameMaxLength,
        MinimumLength = NameMinLength,
        ErrorMessageResourceName = ErrorMessages.StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public required string Name { get; init; }

    [Required(
        ErrorMessageResourceName = ErrorMessages.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: LocationMaxLength,
        MinimumLength = LocationMinLength,
        ErrorMessageResourceName = ErrorMessages.StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public required string Location { get; init; }
}
