namespace BeeSoft.Web.Controllers;

using BeeSoft.Services.Hives;
using BeeSoft.Services.Inspections;
using BeeSoft.Services.Inspections.Models;
using BeeSoft.Web.Models;
using BeeSoft.Web.Models.Inspections;

using Microsoft.AspNetCore.Mvc;

using static Common.DataAttributeConstants.Paging;

public class InspectionsController(IInspectionsService inspectionsService, IHivesService hivesService) : Controller
{
    public async Task<IActionResult> Index(int page = 1)
    {
        var inspections = await inspectionsService.GetInspectionsAsync();

        var inspectionsViewModel = new ListAllViewModel<InspectionListingServiceModel>
        {
            Items = inspections
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage),
            PageNumber = page,
            Count = inspections.Count,
            ItemsPerPage = ItemsPerPage,
        };

        return this.View(inspectionsViewModel);
    }

    public async Task<IActionResult> CreateInspection()
        => this.View(new CreateInspectionFormModel
        {
            Hives = await hivesService.GetHivesAsync()
        });

    [HttpPost]
    public async Task<ActionResult<int>> CreateInspection(CreateInspectionFormModel inspectionFormModel)
    {
        if (ModelState.IsValid)
        {
            var inspectionServiceModel = new BaseInspectionServiceModel
            {
                InspectionDate = inspectionFormModel.InspectionDate,
                WeatherConditions = inspectionFormModel.WeatherConditions,
                Observations = inspectionFormModel.Observations!,
                ActionsTaken = inspectionFormModel.ActionsTaken,
                HiveId = inspectionFormModel.HiveId,
            };

            var inspectionId = await inspectionsService.CreateAsync(inspectionServiceModel);

            if (inspectionId > 0)
            {
                return this.RedirectToAction(nameof(this.Index));
            }
        }
        return this.View(inspectionFormModel);
    }

    public async Task<IActionResult> UpdateInspection(int inspectionId)
    {
        var inspection = await inspectionsService.GetByIdAsync(inspectionId);

        if (inspection is not null)
        {
            var hives = await hivesService.GetHivesAsync();
            return this.View(new UpdateInspectionFormModel
            {
                Id = inspection.Id,
                InspectionDate = inspection.InspectionDate,
                WeatherConditions = inspection.WeatherConditions,
                Observations = inspection.Observations,
                ActionsTaken = inspection.ActionsTaken,
                HiveId = inspection.HiveId,
                Hives = hives,
            });
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateInspection(UpdateInspectionFormModel inspectionFormModel)
    {
        if (this.ModelState.IsValid)
        {
            var inspectionServiceModel = new BaseInspectionServiceModel
            {
                Id = inspectionFormModel.Id,
                InspectionDate = inspectionFormModel.InspectionDate,
                WeatherConditions = inspectionFormModel.WeatherConditions,
                Observations = inspectionFormModel.Observations!,
                ActionsTaken = inspectionFormModel.ActionsTaken,
                HiveId = inspectionFormModel.HiveId,
            };

            await inspectionsService.UpdateAsync(inspectionServiceModel);

            return this.RedirectToAction(nameof(this.Index));
        }
        return this.View(inspectionFormModel);
    }

    public async Task<IActionResult> DeleteInspection(int inspectionId)
    {
        var inspection = await inspectionsService.GetByIdAsync(inspectionId);

        if (inspection is not null)
        {
            return this.View(inspection);
        }
        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteInspection(BaseInspectionServiceModel model)
    {
        var isDeleted = await inspectionsService.DeleteAsync(model.Id);
        if (isDeleted)
        {
            return this.RedirectToAction(nameof(this.Index));
        }

        return BadRequest();
    }
}
