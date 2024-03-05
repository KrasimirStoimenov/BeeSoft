namespace BeeSoft.Services.Expenses;

using BeeSoft.Services.Expenses.Models;

public interface IExpensesService
{
    Task<ICollection<ExpenseServiceModel>> GetExpensesAsync();

    Task<ExpenseServiceModel?> GetByIdAsync(int id);

    Task<int> CreateAsync(ExpenseServiceModel model);

    Task UpdateAsync(ExpenseServiceModel model);

    Task<bool> DeleteAsync(int id);

    Task<decimal> GetTotalAmountOfExpensesAsync();
}
