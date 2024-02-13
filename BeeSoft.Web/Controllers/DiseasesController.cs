namespace BeeSoft.Web.Controllers;

using BeeSoft.Services.Diseases;
using BeeSoft.Services.Diseases.Models;
using BeeSoft.Services.Hives;
using BeeSoft.Web.Models;
using BeeSoft.Web.Models.Diseases;

using Microsoft.AspNetCore.Mvc;

using static Common.DataAttributeConstants.Paging;

public class DiseasesController(IDiseasesService diseasesService, IHivesService hivesService) : Controller
{
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

    public async Task<IActionResult> CreateDisease()
        => this.View(new CreateDiseaseFormModel
        {
            Hives = await hivesService.GetHivesAsync()
        });

    [HttpPost]
    public async Task<ActionResult<int>> CreateDisease(CreateDiseaseFormModel diseaseFormModel)
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
                return this.RedirectToAction(nameof(this.Index));
            }
        }

        return this.View(diseaseFormModel);
    }

    public async Task<IActionResult> UpdateDisease(int diseaseId)
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
                Hives = hives,
            });
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateDisease(UpdateDiseaseFormModel diseaseFormModel)
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

            return this.RedirectToAction(nameof(this.Index));
        }

        return this.View(diseaseFormModel);
    }

    public async Task<IActionResult> DeleteDisease(int diseaseId)
    {
        var disease = await diseasesService.GetByIdAsync(diseaseId);

        if (disease is not null)
        {
            return this.View(disease);
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteDisease(BaseDiseaseServiceModel model)
    {
        var isDeleted = await diseasesService.DeleteAsync(model.Id);
        if (isDeleted)
        {
            return this.RedirectToAction(nameof(this.Index));
        }

        return BadRequest();
    }
}
