namespace BeeSoft.Web.Models.Expenses;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.Expense;
using static Common.ResourceNameConstants;

public sealed record CreateExpenseFormModel
{
    public CreateExpenseFormModel()
    {
        this.Date = DateTime.Now;
    }

    [Required(
        ErrorMessageResourceName = ErrorMessages.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: NameMaxLength,
        MinimumLength = NameMinLength,
        ErrorMessageResourceName = ErrorMessages.StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public string? Name { get; init; }

    public decimal Price { get; init; }

    public DateTime Date { get; init; }
}
