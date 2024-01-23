﻿namespace BeeSoft.Web.Models.BeeQueens;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Infrastructure.ValidationAttributes.Hives;

using static Common.DataAttributeConstants.BeeQueen;

public sealed record UpdateBeeQueenFormModel
{
    public int Id { get; init; }

    [Range(AgeMinValue, AgeMaxValue)]
    public int Age { get; init; }

    [Display(Name = "Is Alive")]
    public bool IsAlive { get; init; } = true;

    [IsValidHiveId]
    [Display(Name = "Hive")]
    public int HiveId { get; init; }

    public IEnumerable<HiveServiceModel> Hives { get; init; } = new HashSet<HiveServiceModel>();
}
