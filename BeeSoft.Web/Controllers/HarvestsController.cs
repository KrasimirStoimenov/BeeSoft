namespace BeeSoft.Web.Controllers;

using BeeSoft.Services.Harvests;
using BeeSoft.Services.Harvests.Models;
using BeeSoft.Services.Hives;
using BeeSoft.Web.Models;
using BeeSoft.Web.Models.Harvests;

using Microsoft.AspNetCore.Mvc;

using static Common.GlobalConstants;

public class HarvestsController(IHarvestsService harvestsService, IHivesService hivesService) : AdministratorController
{
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

    public async Task<IActionResult> CreateHarvest()
        => this.View(new CreateHarvestFormModel
        {
            Hives = await hivesService.GetHivesAsync()
        });

    [HttpPost]
    public async Task<ActionResult<int>> CreateHarvest(CreateHarvestFormModel harvestFormModel)
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
                return this.RedirectToAction(nameof(this.Index));
            }
        }
        return this.View(harvestFormModel);
    }

    public async Task<IActionResult> UpdateHarvest(int harvestId)
    {
        var harvest = await harvestsService.GetByIdAsync(harvestId);

        if (harvest is not null)
        {
            var hives = await hivesService.GetHivesAsync();
            return this.View(new UpdateHarvestFormModel
            {
                Id = harvest.Id,
                HarvestDate = harvest.HarvestDate,
                HarvestedAmount = harvest.HarvestedAmount,
                HarvestedProduct = harvest.HarvestedProduct,
                HiveId = harvest.HiveId,
                Hives = hives,
            });
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateHarvest(UpdateHarvestFormModel harvestFormModel)
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

            return this.RedirectToAction(nameof(this.Index));
        }
        return this.View(harvestFormModel);
    }

    public async Task<IActionResult> DeleteHarvest(int harvestId)
    {
        var harvest = await harvestsService.GetByIdAsync(harvestId);

        if (harvest is not null)
        {
            return this.View(harvest);
        }
        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteHarvest(BaseHarvestServiceModel model)
    {
        var isDeleted = await harvestsService.DeleteAsync(model.Id);
        if (isDeleted)
        {
            return this.RedirectToAction(nameof(this.Index));
        }

        return BadRequest();
    }
}
