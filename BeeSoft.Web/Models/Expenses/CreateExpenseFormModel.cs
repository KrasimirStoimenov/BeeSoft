namespace BeeSoft.Web.Models.Expenses;

using System.ComponentModel.DataAnnotations;

using static Common.DataAttributeConstants.Expense;

public sealed record CreateExpenseFormModel
{
    public CreateExpenseFormModel()
    {
        this.Date = DateOnly.FromDateTime(DateTime.Now);
    }

    [Required]
    [StringLength(
        maximumLength: NameMaxLength,
        MinimumLength = NameMinLength)]
    public string? Name { get; init; }

    public decimal Price { get; init; }

    public DateOnly Date { get; init; }
}
