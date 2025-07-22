namespace BeeSoft.Services.Expenses;

using BeeSoft.Data;
using BeeSoft.Services.Expenses.Mappings;
using BeeSoft.Services.Expenses.Models;

using Microsoft.EntityFrameworkCore;

public sealed class ExpensesService(BeeSoftDbContext dbContext) : IExpensesService
{
    public async Task<ICollection<ExpenseServiceModel>> GetExpensesAsync()
        => await dbContext.Expenses
            .OrderByDescending(x => x.Date)
            .ProjectToExpenseServiceModel()
            .ToListAsync();

    public async Task<ExpenseServiceModel?> GetByIdAsync(int id)
        => await dbContext.Expenses
            .Where(p => p.Id == id)
            .ProjectToExpenseServiceModel()
            .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(ExpenseServiceModel model)
    {
        var expense = model.MapToExpense();

        await dbContext.Expenses.AddAsync(expense);
        await dbContext.SaveChangesAsync();

        return expense.Id;
    }

    public async Task UpdateAsync(ExpenseServiceModel model)
    {
        var expense = model.MapToExpense();

        dbContext.Update(expense);
        await dbContext.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try
        {
            var expense = await dbContext.Expenses.FirstOrDefaultAsync(a => a.Id == id);

            if (expense == null)
            {
                return false;
            }


            dbContext.Expenses.Remove(expense);
            await dbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}
