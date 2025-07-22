namespace BeeSoft.Services.Expenses.Mappings;

using BeeSoft.Data.Models;
using BeeSoft.Services.Expenses.Models;

using Riok.Mapperly.Abstractions;

[Mapper]
internal static partial class ExpensesMapper
{
    public static partial IQueryable<ExpenseServiceModel> ProjectToExpenseServiceModel(this IQueryable<Expense> q);

    public static partial ExpenseServiceModel MapToExpenseServiceModel(this Expense expense);

    public static partial Expense MapToExpense(this ExpenseServiceModel baseExpenseServiceModel);
}
