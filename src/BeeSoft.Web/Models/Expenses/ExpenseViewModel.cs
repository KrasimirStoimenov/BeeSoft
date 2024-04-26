namespace BeeSoft.Web.Models.Expenses;

using BeeSoft.Services.Expenses.Models;

public sealed record ExpenseViewModel : PagingViewModel
{
    public ExpenseViewModel()
    {
        this.Expenses = new HashSet<ExpenseServiceModel>();
    }

    public decimal TotalAmount { get; init; }

    public IEnumerable<ExpenseServiceModel> Expenses { get; init; }
}
