namespace BeeSoft.Services.Expenses;

using AutoMapper;
using AutoMapper.QueryableExtensions;

using BeeSoft.Data;
using BeeSoft.Data.Models;
using BeeSoft.Services.Expenses.Models;

using Microsoft.EntityFrameworkCore;

public sealed class ExpensesService(BeeSoftDbContext dbContext, IMapper mapper) : IExpensesService
{
    public async Task<ICollection<ExpenseServiceModel>> GetExpensesAsync()
        => await dbContext.Expenses
            .OrderByDescending(x => x.Date)
            .ProjectTo<ExpenseServiceModel>(mapper.ConfigurationProvider)
            .ToListAsync();

    public async Task<ExpenseServiceModel?> GetByIdAsync(int id)
        => await dbContext.Expenses
            .Where(p => p.Id == id)
            .ProjectTo<ExpenseServiceModel>(mapper.ConfigurationProvider)
            .FirstOrDefaultAsync();

    public async Task<int> CreateAsync(ExpenseServiceModel model)
    {
        var expense = mapper.Map<Expense>(model);

        await dbContext.Expenses.AddAsync(expense);
        await dbContext.SaveChangesAsync();

        return expense.Id;
    }

    public async Task UpdateAsync(ExpenseServiceModel model)
    {
        var expense = mapper.Map<Expense>(model);

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

    public async Task<decimal> GetTotalAmountOfExpensesAsync()
        => await dbContext.Expenses
            .SumAsync(x => x.Price);
}
