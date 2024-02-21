namespace BeeSoft.Web.Controllers;

using BeeSoft.Services.Apiaries;
using BeeSoft.Services.BeeQueens;
using BeeSoft.Services.BeeQueens.Models;
using BeeSoft.Services.Diseases;
using BeeSoft.Services.Diseases.Models;
using BeeSoft.Services.Harvests;
using BeeSoft.Services.Harvests.Models;
using BeeSoft.Services.Hives;
using BeeSoft.Services.Hives.Models;
using BeeSoft.Services.Inspections;
using BeeSoft.Services.Inspections.Models;
using BeeSoft.Web.Models;
using BeeSoft.Web.Models.Hives;

using Microsoft.AspNetCore.Mvc;

using static Common.GlobalConstants;

public class HivesController(
    IHivesService hivesService,
    IApiariesService apiariesService,
    IBeeQueensService beeQueensService,
    IInspectionsService inspectionsService,
    IDiseasesService diseasesService,
    IHarvestsService harvestsService) : AdministratorController
{
    public async Task<IActionResult> Index(int page = 1)
    {
        var hives = await hivesService.GetHivesAsync();

        var hivesViewModel = new ListAllViewModel<HiveListingServiceModel>
        {
            Items = hives
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage),
            PageNumber = page,
            Count = hives.Count,
            ItemsPerPage = ItemsPerPage,
        };
        return this.View(hivesViewModel);
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
            var hiveServiceModel = new BaseHiveServiceModel
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
            var hiveServiceModel = new BaseHiveServiceModel
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
    public async Task<IActionResult> DeleteHive(BaseHiveServiceModel model)
    {
        var isDeleted = await hivesService.DeleteAsync(model.Id);
        if (isDeleted)
        {
            return this.RedirectToAction(nameof(this.Index));
        }

        return BadRequest();
    }

    public async Task<IActionResult> HiveBeeQueens(int hiveId)
    {
        var hive = await hivesService.GetByIdAsync(hiveId);
        var beeQueens = await beeQueensService.GetBeeQueensInHiveAsync(hiveId);
        if (hive is not null)
        {
            return this.View(new HiveResourcesViewModel<BeeQueenListingServiceModel>
            {
                HiveNumber = hive.Number,
                Resources = beeQueens,
            });
        }

        return this.NotFound();
    }

    public async Task<IActionResult> HiveInspections(int hiveId)
    {
        var hive = await hivesService.GetByIdAsync(hiveId);
        var inspections = await inspectionsService.GetInspectionsForHiveAsync(hiveId);
        if (hive is not null)
        {
            return this.View(new HiveResourcesViewModel<InspectionListingServiceModel>
            {
                HiveNumber = hive.Number,
                Resources = inspections,
            });
        }

        return this.NotFound();
    }

    public async Task<IActionResult> HiveDiseases(int hiveId)
    {
        var hive = await hivesService.GetByIdAsync(hiveId);
        var diseases = await diseasesService.GetDiseasesForHiveAsync(hiveId);
        if (hive is not null)
        {
            return this.View(new HiveResourcesViewModel<DiseaseListingServiceModel>
            {
                HiveNumber = hive.Number,
                Resources = diseases,
            });
        }

        return this.NotFound();
    }

    public async Task<IActionResult> HiveHarvests(int hiveId)
    {
        var hive = await hivesService.GetByIdAsync(hiveId);
        var harvests = await harvestsService.GetHarvestsForHiveAsync(hiveId);
        if (hive is not null)
        {
            return this.View(new HiveResourcesViewModel<HarvestListingServiceModel>
            {
                HiveNumber = hive.Number,
                Resources = harvests,
            });
        }

        return this.NotFound();
    }

}
