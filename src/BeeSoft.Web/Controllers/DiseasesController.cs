﻿namespace BeeSoft.Web.Controllers;

using BeeSoft.Services.Diseases;
using BeeSoft.Services.Diseases.Models;
using BeeSoft.Services.Hives;
using BeeSoft.Web.Models;
using BeeSoft.Web.Models.Diseases;

using Microsoft.AspNetCore.Mvc;

using static Common.GlobalConstants;

public class DiseasesController(IDiseasesService diseasesService, IHivesService hivesService) : AdministratorController
{
    private const string HivesControllerName = "Hives";
    private const string DiseasesActionName = "Diseases";

    public async Task<IActionResult> Index(int page = 1)
    {
        var diseases = await diseasesService.GetDiseasesAsync();

        var diseasesViewModel = new ListAllViewModel<DiseaseListingServiceModel>
        {
            Items = diseases
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage),
            PageNumber = page,
            Count = diseases.Count,
            ItemsPerPage = ItemsPerPage,
        };

        return this.View(diseasesViewModel);
    }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<IActionResult> Create(int hiveId)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        => this.View(new CreateDiseaseFormModel
        {
            HiveId = hiveId
        });

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateDiseaseFormModel diseaseFormModel)
    {
        if (ModelState.IsValid)
        {
            var diseaseServiceModel = new BaseDiseaseServiceModel
            {
                Name = diseaseFormModel.Name!,
                Description = diseaseFormModel.Description!,
                Treatment = diseaseFormModel.Treatment!,
                HiveId = diseaseFormModel.HiveId,
            };

            var diseaseId = await diseasesService.CreateAsync(diseaseServiceModel);

            if (diseaseId > 0)
            {
                return this.RedirectToAction(
                    actionName: DiseasesActionName,
                    controllerName: HivesControllerName,
                    routeValues: new { hiveId = diseaseFormModel.HiveId });
            }
        }

        return this.View(diseaseFormModel);
    }

    public async Task<IActionResult> Update(int diseaseId)
    {
        var disease = await diseasesService.GetByIdAsync(diseaseId);

        if (disease is not null)
        {
            var hives = await hivesService.GetHivesAsync();
            return this.View(new UpdateDiseaseFormModel
            {
                Id = disease.Id,
                Name = disease.Name,
                Description = disease.Description,
                Treatment = disease.Treatment,
                HiveId = disease.HiveId,
            });
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateDiseaseFormModel diseaseFormModel)
    {
        if (this.ModelState.IsValid)
        {
            var diseaseServiceModel = new BaseDiseaseServiceModel
            {
                Id = diseaseFormModel.Id,
                Name = diseaseFormModel.Name!,
                Description = diseaseFormModel.Description!,
                Treatment = diseaseFormModel.Treatment!,
                HiveId = diseaseFormModel.HiveId,
            };

            await diseasesService.UpdateAsync(diseaseServiceModel);

            return this.RedirectToAction(
                actionName: DiseasesActionName,
                controllerName: HivesControllerName,
                routeValues: new { hiveId = diseaseFormModel.HiveId });
        }

        return this.View(diseaseFormModel);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await diseasesService.DeleteAsync(id);
        if (isDeleted)
        {
            return this.Ok();
        }

        return BadRequest();
    }
}
