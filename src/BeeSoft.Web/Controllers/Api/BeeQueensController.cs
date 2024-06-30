namespace BeeSoft.Web.Controllers.Api;

using BeeSoft.Services.BeeQueens;
using BeeSoft.Services.BeeQueens.Models;
using BeeSoft.Services.Inspections.Models;
using BeeSoft.Web.Models.BeeQueens;

using Microsoft.AspNetCore.Mvc;

[Route("api/beeQueens")]
public class BeeQueensController(IBeeQueensService beeQueensService) : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IEnumerable<BeeQueenListingServiceModel>>> GetAll()
    {
        var result = await beeQueensService.GetBeeQueensAsync();

        return this.Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("{id}")]
    public async Task<ActionResult<BaseBeeQueenServiceModel>> GetById(int id)
    {
        var result = await beeQueensService.GetByIdAsync(id);

        if (result is null)
        {
            return this.NotFound();
        }

        return this.Ok(result);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<BaseInspectionServiceModel>> CreateBeeQueen(CreateBeeQueenFormModel beeQueenFormModel)
    {

        var beeQueenServiceModel = new BaseBeeQueenServiceModel
        {
            Year = beeQueenFormModel.Year,
            ColorMark = beeQueenFormModel.ColorMark,
            HiveId = beeQueenFormModel.HiveId,
            IsAlive = true,
        };

        var beeQueenId = await beeQueensService.CreateAsync(beeQueenServiceModel);

        if (beeQueenId is 0)
        {
            return this.BadRequest();
        }

        return this.Ok(beeQueenId);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> UpdateBeeQueen(UpdateBeeQueenFormModel beeQueenFormModel)
    {
        var beeQueenId = beeQueenFormModel.Id;
        var beeQueenServiceModel = new BaseBeeQueenServiceModel
        {
            Id = beeQueenId,
            Year = beeQueenFormModel.Year,
            ColorMark = beeQueenFormModel.ColorMark,
            HiveId = beeQueenFormModel.HiveId,
            IsAlive = beeQueenFormModel.IsAlive,
        };

        await beeQueensService.UpdateAsync(beeQueenServiceModel);

        return this.Ok(beeQueenId);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Route("{id}")]
    public async Task<IActionResult> DeleteBeeQueen(int id)
    {
        var isDeleted = await beeQueensService.DeleteAsync(id);
        if (isDeleted)
        {
            return this.Ok();
        }

        return this.NotFound();
    }
}
