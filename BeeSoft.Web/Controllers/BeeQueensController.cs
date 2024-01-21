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

}
