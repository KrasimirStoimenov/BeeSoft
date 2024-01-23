namespace BeeSoft.Web.Controllers;

using BeeSoft.Services.Apiaries;
using BeeSoft.Services.Hives;
using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Models.Hives;

using Microsoft.AspNetCore.Mvc;

public class HivesController(IHivesService hivesService, IApiariesService apiariesService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var hives = await hivesService.GetHivesAsync();

        return this.View(hives);
    }

    public async Task<IActionResult> CreateHive()
        => this.View(new CreateHiveFormModel
        {
            Apiaries = await apiariesService.GetApiariesAsync()
        });

    [HttpPost]
    public async Task<ActionResult<int>> CreateHive(CreateHiveFormModel hiveFormModel)
    {
        if (ModelState.IsValid)
        {
            var hiveServiceModel = new HiveServiceModel
            {
                Number = hiveFormModel.Number,
                Type = hiveFormModel.Type!,
                Status = hiveFormModel.Status!,
                Color = hiveFormModel.Color,
                DateBought = hiveFormModel.DateBought,
                TimesUsedCount = hiveFormModel.TimesUsedCount,
                ApiaryId = hiveFormModel.ApiaryId,
            };

            var hiveId = await hivesService.CreateAsync(hiveServiceModel);

            if (hiveId > 0)
            {
                return this.RedirectToAction(nameof(this.Index));
            }
        }

        hiveFormModel.Apiaries = await apiariesService.GetApiariesAsync();

        return this.View(hiveFormModel);
    }

    public async Task<IActionResult> UpdateHive(int hiveId)
    {
        var hive = await hivesService.GetByIdAsync(hiveId);

        if (hive is not null)
        {
            var apiaries = await apiariesService.GetApiariesAsync();
            return this.View(new UpdateHiveFormModel
            {
                Id = hive.Id,
                Number = hive.Number,
                Type = hive.Type,
                Status = hive.Status,
                Color = hive.Color,
                DateBought = hive.DateBought,
                TimesUsedCount = hive.TimesUsedCount,
                ApiaryId = hive.ApiaryId,
                Apiaries = apiaries,
            });
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateHive(UpdateHiveFormModel hiveFormModel)
    {
        if (this.ModelState.IsValid)
        {
            var hiveServiceModel = new HiveServiceModel
            {
                Id = hiveFormModel.Id,
                Number = hiveFormModel.Number,
                Type = hiveFormModel.Type!,
                Status = hiveFormModel.Status!,
                Color = hiveFormModel.Color,
                DateBought = hiveFormModel.DateBought,
                TimesUsedCount = hiveFormModel.TimesUsedCount,
                ApiaryId = hiveFormModel.ApiaryId,
            };

            await hivesService.UpdateAsync(hiveServiceModel);

            return this.RedirectToAction(nameof(this.Index));
        }

        hiveFormModel.Apiaries = await apiariesService.GetApiariesAsync();
        return this.View(hiveFormModel);
    }

    public async Task<IActionResult> DeleteHive(int hiveId)
    {
        var hive = await hivesService.GetByIdAsync(hiveId);

        if (hive is not null)
        {
            return this.View(hive);
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteHive(HiveServiceModel model)
    {
        var isDeleted = await hivesService.DeleteAsync(model.Id);
        if (isDeleted)
        {
            return this.RedirectToAction(nameof(this.Index));
        }

        return BadRequest();
    }

}
