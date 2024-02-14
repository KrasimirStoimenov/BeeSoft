namespace BeeSoft.Web.Models.Expenses;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.Expense;
using static Common.ResourceNameConstants;

public sealed record UpdateExpenseFormModel
{
    public int Id { get; init; }

    [Required(
        ErrorMessageResourceName = ErrorMessage.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: NameMaxLength,
        MinimumLength = NameMinLength,
        ErrorMessageResourceName = ErrorMessage.StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public required string Name { get; init; }

    public decimal Price { get; init; }

    public DateTime Date { get; init; }
}
