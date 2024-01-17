namespace BeeSoft.Web.Controllers.Api;

using BeeSoft.Services.Apiary;
using BeeSoft.Web.Models.Apiaries;

using Microsoft.AspNetCore.Mvc;

public class ApiariesController(IApiaryService apiaryService) : Controller
{
    public async Task<ActionResult> All()
    {
        var apiaries = await apiaryService.GetApiaries();

        return this.View(apiaries);
    }

    public async Task<ActionResult> Create()
        => this.View();

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateApiaryFormModel apiaryFormModel)
    {
        var apiary = await apiaryService.CreateAsync(apiaryFormModel.Name, apiaryFormModel.Location);

        return this.RedirectToAction(nameof(this.All));
    }

    public async Task<ActionResult<bool>> Delete(int id)
    {
        var apiary = await apiaryService.GetByIdAsync(id);

        return this.View(apiary);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await apiaryService.DeleteAsync(id);

        return this.RedirectToAction(nameof(this.All));
    }
}
