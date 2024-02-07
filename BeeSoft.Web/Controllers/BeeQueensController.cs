namespace BeeSoft.Web.Controllers;

using BeeSoft.Services.BeeQueens;
using BeeSoft.Services.BeeQueens.Models;
using BeeSoft.Services.Hives;
using BeeSoft.Web.Models.BeeQueens;

using Microsoft.AspNetCore.Mvc;

using static Common.DataAttributeConstants.Paging;

public class BeeQueensController(IBeeQueensService beeQueensService, IHivesService hivesService) : Controller
{
    public async Task<IActionResult> Index(int page = 1)
    {
        var beeQueens = await beeQueensService.GetBeeQueensAsync();

        var beeQueensViewModel = new ListAllBeeQueensViewModel
        {
            BeeQueens = beeQueens
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage),
            PageNumber = page,
            Count = beeQueens.Count,
            ItemsPerPage = ItemsPerPage,
        };

        return this.View(beeQueensViewModel);
    }

    public async Task<IActionResult> CreateBeeQueen()
        => this.View(new CreateBeeQueenFormModel
        {
            Hives = await hivesService.GetHivesWithoutQueenAsync()
        });

    [HttpPost]
    public async Task<ActionResult<int>> CreateBeeQueen(CreateBeeQueenFormModel beeQueenFormModel)
    {
        if (ModelState.IsValid)
        {
            var beeQueenServiceModel = new BaseBeeQueenServiceModel
            {
                Age = beeQueenFormModel.Age,
                HiveId = beeQueenFormModel.HiveId,
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
            var beeQueenServiceModel = new BaseBeeQueenServiceModel
            {
                Id = beeQueenFormModel.Id,
                Age = beeQueenFormModel.Age,
                HiveId = beeQueenFormModel.HiveId,
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
    public async Task<IActionResult> DeleteBeeQueen(BaseBeeQueenServiceModel model)
    {
        var isDeleted = await beeQueensService.DeleteAsync(model.Id);
        if (isDeleted)
        {
            return this.RedirectToAction(nameof(this.Index));
        }

        return BadRequest();
    }
}
