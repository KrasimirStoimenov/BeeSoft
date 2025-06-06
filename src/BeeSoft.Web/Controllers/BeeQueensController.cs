﻿namespace BeeSoft.Web.Controllers;

using BeeSoft.Services.BeeQueens;
using BeeSoft.Services.BeeQueens.Models;
using BeeSoft.Services.Hives;
using BeeSoft.Web.Models;
using BeeSoft.Web.Models.BeeQueens;

using Microsoft.AspNetCore.Mvc;

using static Common.GlobalConstants;

public class BeeQueensController(IBeeQueensService beeQueensService, IHivesService hivesService) : AdministratorController
{
    public async Task<IActionResult> Index(int page = 1)
    {
        var beeQueens = await beeQueensService.GetBeeQueensAsync();

        var beeQueensViewModel = new ListAllViewModel<BeeQueenListingServiceModel>
        {
            Items = beeQueens
                .Skip((page - 1) * ItemsPerPage)
                .Take(ItemsPerPage),
            PageNumber = page,
            Count = beeQueens.Count,
            ItemsPerPage = ItemsPerPage,
        };

        return this.View(beeQueensViewModel);
    }

    public async Task<IActionResult> Create()
        => this.View(new CreateBeeQueenFormModel
        {
            Hives = await hivesService.GetHivesWithoutQueenAsync()
        });

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateBeeQueenFormModel beeQueenFormModel)
    {
        if (ModelState.IsValid)
        {
            var beeQueenServiceModel = new BaseBeeQueenServiceModel
            {
                Year = beeQueenFormModel.Year,
                ColorMark = beeQueenFormModel.ColorMark,
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

    public async Task<IActionResult> Update(int beeQueenId)
    {
        var beeQueen = await beeQueensService.GetByIdAsync(beeQueenId);

        if (beeQueen is not null)
        {
            var hives = await hivesService.GetHivesAsync();
            return this.View(new UpdateBeeQueenFormModel
            {
                Id = beeQueen.Id,
                Year = beeQueen.Year,
                ColorMark = beeQueen.ColorMark,
                IsAlive = beeQueen.IsAlive,
                HiveId = beeQueen.HiveId,
                Hives = hives,
            });
        }

        return this.NotFound();
    }

    [HttpPost]
    public async Task<IActionResult> Update(UpdateBeeQueenFormModel beeQueenFormModel)
    {
        if (this.ModelState.IsValid)
        {
            var beeQueenServiceModel = new BaseBeeQueenServiceModel
            {
                Id = beeQueenFormModel.Id,
                Year = beeQueenFormModel.Year,
                ColorMark = beeQueenFormModel.ColorMark,
                HiveId = beeQueenFormModel.HiveId,
                IsAlive = beeQueenFormModel.IsAlive,
            };

            await beeQueensService.UpdateAsync(beeQueenServiceModel);

            return this.RedirectToAction(nameof(this.Index));
        }

        return this.View(beeQueenFormModel);
    }

    public async Task<IActionResult> Delete(int id)
    {
        var isDeleted = await beeQueensService.DeleteAsync(id);
        if (isDeleted)
        {
            return this.Ok();
        }

        return BadRequest();
    }
}
