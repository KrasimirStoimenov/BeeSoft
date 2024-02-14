﻿namespace BeeSoft.Web.Models.Hives;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Apiaries.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Apiaries;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;
using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.Hive;
using static Common.ResourceNameConstants;

public sealed record CreateHiveFormModel
{
    public CreateHiveFormModel()
    {
        this.DateBought = DateOnly.FromDateTime(DateTime.Now);
        this.TimesUsedCount = 1;
        this.Apiaries = new HashSet<ApiaryServiceModel>();
    }

    [IsValidHiveNumber(
        ErrorMessageResourceName = ErrorMessages.AlreadyExistingHiveNumberErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [Range(
        NumberMinValue,
        NumberMaxValue,
        ErrorMessageResourceName = ErrorMessages.RangeErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int Number { get; init; }

    [Required(
        ErrorMessageResourceName = ErrorMessages.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: TypeMaxLength,
        MinimumLength = TypeMinLength,
        ErrorMessageResourceName = ErrorMessages.StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public string? Type { get; init; }

    [Required(
        ErrorMessageResourceName = ErrorMessages.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: StatusMaxLength,
        MinimumLength = StatusMinLength,
        ErrorMessageResourceName = ErrorMessages.StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public string? Status { get; init; }

    [MaxLength(ColorMaxLength)]
    public string? Color { get; init; }

    [Display(Name = "Bought Date")]
    public DateOnly DateBought { get; init; }

    [Display(Name = "Times Used")]
    [Range(
        TimesUsedCountMinValue,
        TimesUsedCountMaxValue,
        ErrorMessageResourceName = ErrorMessages.RangeErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int TimesUsedCount { get; init; }

    [Display(Name = "Apiary")]
    [IsValidApiaryId(
        ErrorMessageResourceName = ErrorMessages.NotExistingItemErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int ApiaryId { get; init; }

    public IEnumerable<ApiaryServiceModel> Apiaries { get; set; }
}
