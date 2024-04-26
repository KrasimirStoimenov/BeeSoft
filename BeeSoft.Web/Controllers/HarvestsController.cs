namespace BeeSoft.Web.Controllers;

using BeeSoft.Services.Harvests;
using BeeSoft.Services.Harvests.Models;
using BeeSoft.Web.Models;
using BeeSoft.Web.Models.Harvests;

using Microsoft.AspNetCore.Mvc;

using static Common.GlobalConstants;

public class HarvestsController(IHarvestsService harvestsService) : AdministratorController
{
    private const string HivesControllerName = "Hives";
    private const string HarvestsActionName = "Harvests";

    public async Task<IActionResult> Index(int page = 1)
    {
        var harvests = await harvestsService.GetHarvestsAsync();

        var harvestsViewModel = new ListAllViewModel<HarvestListingServiceModel>
        {
            Items = harvests
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage),
            PageNumber = page,
            Count = harvests.Count,
            ItemsPerPage = ItemsPerPage,
        };

        return this.View(harvestsViewModel);
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<IActionResult> Create(int hiveId)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        => this.View(new CreateHarvestFormModel
        {
            HiveId = hiveId
        });

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateHarvestFormModel harvestFormModel)
    {
        if (ModelState.IsValid)
        {
            var harvestServiceModel = new BaseHarvestServiceModel
            {
                HarvestDate = harvestFormModel.HarvestDate,
                HarvestedAmount = harvestFormModel.HarvestedAmount,
                HarvestedProduct = harvestFormModel.HarvestedProduct!,
                HiveId = harvestFormModel.HiveId,
            };

            var harvestId = await harvestsService.CreateAsync(harvestServiceModel);

            if (harvestId > 0)
            {
                return this.RedirectToAction(
                    actionName: HarvestsActionName,
                    controllerName: HivesControllerName,
                    routeValues: new { hiveId = harvestFormModel.HiveId });
            }
        }
        return this.View(harvestFormModel);
    }

    public async Task<IActionResult> Update(int harvestId)
    {
        var harvest = await harvestsService.GetByIdAsync(harvestId);

        if (harvest is not null)
        {
            return this.View(new UpdateHarvestFormModel
            {
                Id = harvest.Id,
                HarvestDate = harvest.HarvestDate,
                HarvestedAmount = harvest.HarvestedAmount,
                HarvestedProduct = harvest.HarvestedProduct,
                HiveId = harvest.HiveId,
            });
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateHarvestFormModel harvestFormModel)
    {
        if (this.ModelState.IsValid)
        {
            var harvestServiceModel = new BaseHarvestServiceModel
            {
                Id = harvestFormModel.Id,
                HarvestDate = harvestFormModel.HarvestDate,
                HarvestedAmount = harvestFormModel.HarvestedAmount,
                HarvestedProduct = harvestFormModel.HarvestedProduct!,
                HiveId = harvestFormModel.HiveId,
            };

            await harvestsService.UpdateAsync(harvestServiceModel);

            return this.RedirectToAction(
                actionName: HarvestsActionName,
                controllerName: HivesControllerName,
                routeValues: new { hiveId = harvestFormModel.HiveId });
        }
        return this.View(harvestFormModel);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await harvestsService.DeleteAsync(id);
        if (isDeleted)
        {
            return this.Ok();
        }

        return BadRequest();
    }
}
