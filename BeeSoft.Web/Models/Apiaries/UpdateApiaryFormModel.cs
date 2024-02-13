﻿namespace BeeSoft.Web.Models.Apiaries;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.Apiary;
using static Common.ErrorMessageResourceNameConstants;

public class UpdateApiaryFormModel
{
    public int Id { get; init; }

    [Display(Name = "Apiary name")]
    [Required(
            ErrorMessageResourceName = RequiredFieldErrorMessageName,
            ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: NameMaxLength,
        MinimumLength = NameMinLength,
        ErrorMessageResourceName = DefaultStringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public required string Name { get; init; }

    [Required(
        ErrorMessageResourceName = RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: LocationMaxLength,
        MinimumLength = LocationMinLength,
        ErrorMessageResourceName = DefaultStringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public required string Location { get; init; }
}
