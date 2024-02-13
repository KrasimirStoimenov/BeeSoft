namespace BeeSoft.Web.Models.Expenses;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Web.Resources;

using static Common.DataAttributeConstants.Expense;
using static Common.ErrorMessageResourceNameConstants;

public sealed record CreateExpenseFormModel
{
    public CreateExpenseFormModel()
    {
        this.Date = DateTime.Now;
    }

    [Required(
        ErrorMessageResourceName = RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: NameMaxLength,
        MinimumLength = NameMinLength,
        ErrorMessageResourceName = StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public string? Name { get; init; }

    public decimal Price { get; init; }

    public DateTime Date { get; init; }
}
