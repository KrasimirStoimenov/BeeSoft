namespace BeeSoft.Web.Models.Apiaries;

using System.ComponentModel.DataAnnotations;

public class CreateApiaryFormModel
{
    [Required]
    //TODO: Add Validation for string length
    [StringLength(maximumLength: 10, MinimumLength = 3)]
    [Display(Name = "Apiary name")]
    public required string Name { get; init; }

    [Required]
    //TODO: AddValidation for string length
    public required string Location { get; init; }
}
