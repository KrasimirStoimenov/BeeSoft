namespace BeeSoft.Web.Models.Expenses;

using System.ComponentModel.DataAnnotations;

using static Common.DataAttributeConstants.Expense;

public sealed record UpdateExpenseFormModel
{
    public int Id { get; init; }

    [Required]
    [StringLength(
        maximumLength: NameMaxLength,
        MinimumLength = NameMinLength)]
    public required string Name { get; init; }

    public decimal Price { get; init; }

    public DateOnly Date { get; init; }
}
