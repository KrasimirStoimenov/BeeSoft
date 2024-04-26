namespace BeeSoft.Web.Controllers.Api;

using BeeSoft.Services.Apiaries;
using BeeSoft.Services.Apiaries.Models;
using BeeSoft.Services.Hives;
using BeeSoft.Web.Models;
using BeeSoft.Web.Models.Apiaries;

using Microsoft.AspNetCore.Mvc;

using static Common.GlobalConstants;

public class ApiariesController(IApiariesService apiariesService, IHivesService hivesService) : AdministratorController
{
    public async Task<IActionResult> Index(int page = 1)
    {
        var apiaries = await apiariesService.GetApiariesAsync();

        var apiariesViewModel = new ListAllViewModel<ApiaryServiceModel>
        {
            Items = apiaries
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage),
            PageNumber = page,
            Count = apiaries.Count,
            ItemsPerPage = ItemsPerPage,
        };

        return this.View(apiariesViewModel);
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<IActionResult> Create()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        => this.View();

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateApiaryFormModel apiaryFormModel)
    {
        var apiaryWithSameNameAndLocationAlreadyExists = await apiariesService.IsApiaryExistsAsync(apiaryFormModel.Name, apiaryFormModel.Location);
        if (apiaryWithSameNameAndLocationAlreadyExists)
        {
            this.ModelState.AddModelError("NameAndLocationAlreadyExists", $"Apiary with name: '{apiaryFormModel.Name}' in location: '{apiaryFormModel.Location}' already exists.");
        }
        if (ModelState.IsValid)
        {
            var apiaryServiceModel = new ApiaryServiceModel
            {
                Name = apiaryFormModel.Name,
                Location = apiaryFormModel.Location,
            };

            var apiaryId = await apiariesService.CreateAsync(apiaryServiceModel);

            if (apiaryId > 0)
            {
                return this.RedirectToAction(nameof(this.Index));
            }
        }

        return this.View(apiaryFormModel);
    }

    public async Task<IActionResult> Update(int apiaryId)
    {
        var apiary = await apiariesService.GetByIdAsync(apiaryId);

        if (apiary is not null)
        {
            return this.View(new UpdateApiaryFormModel
            {
                Id = apiary.Id,
                Location = apiary.Location,
                Name = apiary.Name
            });
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateApiaryFormModel apiaryFormModel)
    {
        if (this.ModelState.IsValid)
        {
            var apiaryServiceModel = new ApiaryServiceModel
            {
                Id = apiaryFormModel.Id,
                Name = apiaryFormModel.Name,
                Location = apiaryFormModel.Location,
            };

            await apiariesService.UpdateAsync(apiaryServiceModel);

            return this.RedirectToAction(nameof(this.Index));
        }

        return this.View(apiaryFormModel);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await apiariesService.DeleteAsync(id);
        if (isDeleted)
        {
            return this.Ok();
        }

        return BadRequest();
    }

    public async Task<IActionResult> Hives(int apiaryId)
    {
        var apiary = await apiariesService.GetByIdAsync(apiaryId);
        var hives = await hivesService.GetHivesInApiaryAsync(apiaryId);
        if (apiary is not null)
        {
            return this.View(new ApiaryHivesViewModel
            {
                ApiaryName = apiary.Name,
                Hives = hives,
            });
        }

        return this.NotFound();
    }
}
