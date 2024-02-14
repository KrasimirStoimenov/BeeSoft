﻿namespace BeeSoft.Web.Models.Diseases;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;
using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.Disease;
using static Common.ResourceNameConstants;

public sealed record CreateDiseaseFormModel
{
    public CreateDiseaseFormModel()
    {
        this.Hives = new HashSet<BaseHiveServiceModel>();
    }

    [Required(
        ErrorMessageResourceName = ErrorMessages.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [MaxLength(NameMaxLength)]
    public string? Name { get; init; }

    [Required(
        ErrorMessageResourceName = ErrorMessages.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [MaxLength(DescriptionMaxLength)]
    public string? Description { get; init; }

    [Required(
        ErrorMessageResourceName = ErrorMessages.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [MaxLength(TreatmentMaxLength)]
    public string? Treatment { get; init; }

    [Display(Name = "Hive")]
    [IsValidHiveId(
        ErrorMessageResourceName = ErrorMessages.NotExistingItemErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int HiveId { get; init; }

    public IEnumerable<BaseHiveServiceModel> Hives { get; init; }
}
