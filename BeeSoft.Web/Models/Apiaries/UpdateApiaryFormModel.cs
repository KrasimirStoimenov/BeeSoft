namespace BeeSoft.Web.Models.Apiaries;

using System.ComponentModel.DataAnnotations;

using static Common.DataAttributeConstants.Apiary;

public class UpdateApiaryFormModel
{
    public int Id { get; init; }

    [Required]
    [Display(Name = "Apiary name")]
    [StringLength(
        maximumLength: NameMaxLength,
        MinimumLength = NameMinLength)]
    public required string Name { get; init; }

    [Required]
    [StringLength(
        maximumLength: LocationMaxLength,
        MinimumLength = LocationMinLength)]
    public required string Location { get; init; }
}
