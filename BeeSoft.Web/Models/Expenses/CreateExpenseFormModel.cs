namespace BeeSoft.Web.Models.Expenses;

using System.ComponentModel.DataAnnotations;

using BeeSoft.Web.Resources;
using BeeSoft.Web.Resources.Models.Expenses;

using static Common.DataAttributeConstants.Expense;
using static Common.ResourceNameConstants;

public sealed record CreateExpenseFormModel
{
    public CreateExpenseFormModel()
    {
        this.Date = DateTime.Now;
    }

    [Display(
        Name = CommonResourceName.Name,
        ResourceType = typeof(SharedResource))]
    [Required(
        ErrorMessageResourceName = ErrorMessage.RequiredFieldErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    [StringLength(
        maximumLength: NameMaxLength,
        MinimumLength = NameMinLength,
        ErrorMessageResourceName = ErrorMessage.StringLengthErrorMessageName,
        ErrorMessageResourceType = typeof(SharedResource))]
    public string? Name { get; init; }

    [Display(
        Name = ExpenseResourceName.Price,
        ResourceType = typeof(ExpenseResource))]
    public decimal Price { get; init; }

    [Display(
        Name = CommonResourceName.Date,
        ResourceType = typeof(SharedResource))]
    public DateTime Date { get; init; }
}
