﻿namespace BeeSoft.Web.Controllers;

using BeeSoft.Services.Inspections;
using BeeSoft.Services.Inspections.Models;
using BeeSoft.Web.Models;
using BeeSoft.Web.Models.Inspections;

using Microsoft.AspNetCore.Mvc;

using static Common.GlobalConstants;

public class InspectionsController(IInspectionsService inspectionsService) : AdministratorController
{
    private const string HivesControllerName = "Hives";
    private const string InspectionsActionName = "Inspections";

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

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<IActionResult> Create(int hiveId)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        => this.View(new CreateInspectionFormModel
        {
            HiveId = hiveId
        });

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateInspectionFormModel inspectionFormModel)
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
                return this.RedirectToAction(
                    actionName: InspectionsActionName,
                    controllerName: HivesControllerName,
                    routeValues: new { hiveId = inspectionFormModel.HiveId });
            }
        }
        return this.View(inspectionFormModel);
    }

    public async Task<IActionResult> Update(int inspectionId)
    {
        var inspection = await inspectionsService.GetByIdAsync(inspectionId);

        if (inspection is not null)
        {
            return this.View(new UpdateInspectionFormModel
            {
                Id = inspection.Id,
                InspectionDate = inspection.InspectionDate,
                WeatherConditions = inspection.WeatherConditions,
                Observations = inspection.Observations,
                ActionsTaken = inspection.ActionsTaken,
                HiveId = inspection.HiveId,
            });
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateInspectionFormModel inspectionFormModel)
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

            return this.RedirectToAction(
                actionName: InspectionsActionName,
                controllerName: HivesControllerName,
                routeValues: new { hiveId = inspectionFormModel.HiveId });
        }
        return this.View(inspectionFormModel);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await inspectionsService.DeleteAsync(id);
        if (isDeleted)
        {
            return this.Ok();
        }

        return BadRequest();
    }
}
