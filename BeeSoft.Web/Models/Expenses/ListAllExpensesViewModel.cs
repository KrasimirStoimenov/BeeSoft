namespace BeeSoft.Web.Models.Expenses;

using BeeSoft.Services.Expenses.Models;

public sealed record ListAllExpensesViewModel : PagingViewModel
{
    public ListAllExpensesViewModel()
    {
        this.Expenses = new HashSet<ExpenseServiceModel>();
    }

    public IEnumerable<ExpenseServiceModel> Expenses { get; init; }
}
