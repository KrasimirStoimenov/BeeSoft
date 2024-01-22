namespace BeeSoft.Web.Controllers;

using BeeSoft.Services.Expenses;
using BeeSoft.Services.Expenses.Models;
using BeeSoft.Web.Models.Expenses;

using Microsoft.AspNetCore.Mvc;

public class ExpensesController(IExpensesService expensesService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var expenses = await expensesService.GetExpensesAsync();

        return this.View(expenses);
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<IActionResult> CreateExpense()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        => this.View();

    [HttpPost]
    public async Task<ActionResult<int>> CreateExpense(CreateExpenseFormModel expenseFormModel)
    {
        if (ModelState.IsValid)
        {
            var expenseServiceModel = new ExpenseServiceModel
            {
                Name = expenseFormModel.Name,
                Price = expenseFormModel.Price,
            };

            var expenseId = await expensesService.CreateAsync(expenseServiceModel);

            if (expenseId > 0)
            {
                return this.RedirectToAction(nameof(this.Index));
            }
        }

        return this.View(expenseFormModel);
    }

    public async Task<IActionResult> UpdateExpense(int expenseId)
    {
        var expense = await expensesService.GetByIdAsync(expenseId);

        if (expense is not null)
        {
            return this.View(new UpdateExpenseFormModel
            {
                Id = expense.Id,
                Name = expense.Name,
                Price = expense.Price,
            });
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateExpense(UpdateExpenseFormModel expenseFormModel)
    {
        if (this.ModelState.IsValid)
        {
            var expenseServiceModel = new ExpenseServiceModel
            {
                Id = expenseFormModel.Id,
                Name = expenseFormModel.Name,
                Price = expenseFormModel.Price,
            };

            await expensesService.UpdateAsync(expenseServiceModel);

            return this.RedirectToAction(nameof(this.Index));
        }

        return this.View(expenseFormModel);
    }

    public async Task<IActionResult> DeleteExpense(int expenseId)
    {
        var expense = await expensesService.GetByIdAsync(expenseId);

        if (expense is not null)
        {
            return this.View(expense);
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteExpense(ExpenseServiceModel model)
    {
        var isDeleted = await expensesService.DeleteAsync(model.Id);
        if (isDeleted)
        {
            return this.RedirectToAction(nameof(this.Index));
        }

        return BadRequest();
    }
}
