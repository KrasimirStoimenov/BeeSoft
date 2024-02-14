namespace BeeSoft.Web.Models.Apiaries;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.Apiary;
using static Common.ResourceNameConstants;

public class CreateApiaryFormModel
{
    [Display(Name = "Apiary name")]
    [Required(
        ErrorMessageResourceName = ErrorMessage.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: NameMaxLength,
        MinimumLength = NameMinLength,
        ErrorMessageResourceName = ErrorMessage.StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public required string Name { get; init; }

    [Required(
        ErrorMessageResourceName = ErrorMessage.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: LocationMaxLength,
        MinimumLength = LocationMinLength,
        ErrorMessageResourceName = ErrorMessage.StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public required string Location { get; init; }
}
