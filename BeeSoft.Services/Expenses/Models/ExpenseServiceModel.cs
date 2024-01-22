namespace BeeSoft.Services.Expenses.Models;

public sealed record ExpenseServiceModel
{
    public int Id { get; init; }

    public required string Name { get; init; }

    public decimal Price { get; init; }
}
