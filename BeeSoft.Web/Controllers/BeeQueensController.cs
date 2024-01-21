namespace BeeSoft.Web.Controllers;

using BeeSoft.Services.BeeQueens;
using BeeSoft.Services.BeeQueens.Models;
using BeeSoft.Services.Hives;
using BeeSoft.Web.Models.BeeQueens;

using Microsoft.AspNetCore.Mvc;

public class BeeQueensController(IBeeQueensService beeQueensService, IHivesService hivesService) : Controller
{
    public async Task<IActionResult> Index()
    {
        var beeQueens = await beeQueensService.GetBeeQueensAsync();

        return this.View(beeQueens);
    }

    public async Task<IActionResult> CreateBeeQueen()
        => this.View(new CreateBeeQueenFormModel
        {
            Hives = await hivesService.GetHivesAsync()
        });

    [HttpPost]
    public async Task<ActionResult<int>> CreateBeeQueen(CreateBeeQueenFormModel beeQueenFormModel)
    {
        if (ModelState.IsValid)
        {
            var beeQueenServiceModel = new BeeQueenServiceModel
            {
                Age = beeQueenFormModel.Age,
                HiveId = beeQueenFormModel.HiveId != 0 ? beeQueenFormModel.HiveId : null,
                IsAlive = true,
            };

            var beeQueenId = await beeQueensService.CreateAsync(beeQueenServiceModel);

            if (beeQueenId > 0)
            {
                return this.RedirectToAction(nameof(this.Index));
            }
        }

        return this.View(beeQueenFormModel);
    }

    public async Task<IActionResult> UpdateBeeQueen(int beeQueenId)
    {
        var beeQueen = await beeQueensService.GetByIdAsync(beeQueenId);

        if (beeQueen is not null)
        {
            var hives = await hivesService.GetHivesAsync();
            return this.View(new UpdateBeeQueenFormModel
            {
                Id = beeQueen.Id,
                Age = beeQueen.Age,
                HiveId = beeQueen.HiveId,
                Hives = hives,
            });
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> UpdateBeeQueen(UpdateBeeQueenFormModel beeQueenFormModel)
    {
        if (this.ModelState.IsValid)
        {
            var beeQueenServiceModel = new BeeQueenServiceModel
            {
                Id = beeQueenFormModel.Id,
                Age = beeQueenFormModel.Age,
                HiveId = beeQueenFormModel.HiveId != 0 ? beeQueenFormModel.HiveId : null,
                IsAlive = beeQueenFormModel.IsAlive,
            };

            await beeQueensService.UpdateAsync(beeQueenServiceModel);

            return this.RedirectToAction(nameof(this.Index));
        }

        return this.View(beeQueenFormModel);
    }

    public async Task<IActionResult> DeleteBeeQueen(int beeQueenId)
    {
        var beeQueen = await beeQueensService.GetByIdAsync(beeQueenId);

        if (beeQueen is not null)
        {
            return this.View(beeQueen);
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> DeleteBeeQueen(BeeQueenServiceModel model)
    {
        var isDeleted = await beeQueensService.DeleteAsync(model.Id);
        if (isDeleted)
        {
            return this.RedirectToAction(nameof(this.Index));
        }

        return BadRequest();
    }
}
