﻿namespace BeeSoft.Web.Models.Expenses;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.Expense;
using static Common.ErrorMessageResourceNameConstants;

public sealed record UpdateExpenseFormModel
{
    public int Id { get; init; }

    [Required(
        ErrorMessageResourceName = RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: NameMaxLength,
        MinimumLength = NameMinLength,
        ErrorMessageResourceName = StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public required string Name { get; init; }

    public decimal Price { get; init; }

    public DateTime Date { get; init; }
}
