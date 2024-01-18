namespace BeeSoft.Web.Controllers.Api;

using BeeSoft.Services.Apiary;
using BeeSoft.Services.Apiary.Models;
using BeeSoft.Web.Models.Apiaries;

using Microsoft.AspNetCore.Mvc;

public class ApiariesController(IApiaryService apiaryService) : Controller
{
    public async Task<IActionResult> ApiaryIndex()
    {
        var apiaries = await apiaryService.GetApiaries();

        return this.View(apiaries);
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<IActionResult> CreateApiary()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        => this.View();

    [HttpPost]
    public async Task<ActionResult<int>> CreateApiary(CreateApiaryFormModel apiaryFormModel)
    {
        if (ModelState.IsValid)
        {
            var apiary = await apiaryService.CreateAsync(apiaryFormModel.Name, apiaryFormModel.Location);

            if (apiary > 0)
            {
                return this.RedirectToAction(nameof(this.ApiaryIndex));
            }
        }

        return this.View(apiaryFormModel);
    }

    public async Task<IActionResult> DeleteApiary(int apiaryId)
    {
        var apiary = await apiaryService.GetByIdAsync(apiaryId);

        if (apiary is not null)
        {
            return this.View(apiary);
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteApiary(ApiaryServiceModel model)
    {
        var isDeleted = await apiaryService.DeleteAsync(model.Id);
        if (isDeleted)
        {
            return this.RedirectToAction(nameof(this.ApiaryIndex));
        }

        return BadRequest();
    }
}
