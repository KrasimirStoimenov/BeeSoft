﻿namespace BeeSoft.Web.Controllers.Api;

using BeeSoft.Services.Apiaries;
using BeeSoft.Services.Apiaries.Models;
using BeeSoft.Services.Hives;
using BeeSoft.Web.Models.Apiaries;

using Microsoft.AspNetCore.Mvc;

public class ApiariesController(IApiariesService apiariesService, IHivesService hivesService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var apiaries = await apiariesService.GetApiariesAsync();

        return this.View(apiaries);
    }

    public async Task<IActionResult> ApiaryHives(int apiaryId)
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

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<IActionResult> CreateApiary()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        => this.View();

    [HttpPost]
    public async Task<ActionResult<int>> CreateApiary(CreateApiaryFormModel apiaryFormModel)
    {
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

    public async Task<IActionResult> UpdateApiary(int apiaryId)
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
    public async Task<IActionResult> UpdateApiary(UpdateApiaryFormModel apiaryFormModel)
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

    public async Task<IActionResult> DeleteApiary(int apiaryId)
    {
        var apiary = await apiariesService.GetByIdAsync(apiaryId);

        if (apiary is not null)
        {
            return this.View(apiary);
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteApiary(ApiaryServiceModel model)
    {
        var isDeleted = await apiariesService.DeleteAsync(model.Id);
        if (isDeleted)
        {
            return this.RedirectToAction(nameof(this.Index));
        }

        return BadRequest();
    }
}
