﻿namespace BeeSoft.Web.Models.Harvests;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;
using BeeSoft.Web.Resources;
using BeeSoft.Web.Resources.Models.Harvests;

using static Common.DataAttributeConstants.Harvest;
using static Common.ResourceNameConstants;

public sealed record CreateHarvestFormModel
{
    public CreateHarvestFormModel()
    {
        this.HarvestDate = DateTime.Now;
    }

    [Display(
        Name = CommonResourceName.Date,
        ResourceType = typeof(SharedResource))]
    public DateTime HarvestDate { get; init; }

    [Display(
        Name = HarvestResourceName.Amount,
        ResourceType = typeof(HarvestResource))]
    public decimal HarvestedAmount { get; init; }

    [Display(
        Name = HarvestResourceName.Product,
        ResourceType = typeof(HarvestResource))]
    [Required(
       ErrorMessageResourceName = ErrorMessage.RequiredFieldErrorMessageName,
       ErrorMessageResourceType = typeof(SharedResource))]
    [MaxLength(HarvestedProductMaxLength)]
    public string? HarvestedProduct { get; init; }

    [Display(
        Name = CommonResourceName.Hive,
        ResourceType = typeof(SharedResource))]
    [IsValidHiveId(
        ErrorMessageResourceName = ErrorMessage.NotExistingItemErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public int HiveId { get; init; }
}
