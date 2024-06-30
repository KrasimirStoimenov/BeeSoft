namespace BeeSoft.Web.Controllers.Api;

using BeeSoft.Services.Hives;
using BeeSoft.Services.Hives.Models;
using BeeSoft.Web.Models.Hives;

using Microsoft.AspNetCore.Mvc;

[Route("api/hives")]
public class HivesController(IHivesService hivesService) : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IEnumerable<HiveListingServiceModel>>> GetAll()
    {
        var result = await hivesService.GetHivesAsync();

        return this.Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("{id}")]
    public async Task<ActionResult<BaseHiveServiceModel>> GetById(int id)
    {
        var result = await hivesService.GetByIdAsync(id);

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
    public async Task<ActionResult<BaseHiveServiceModel>> CreateHive(CreateHiveFormModel hiveFormModel)
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

        var result = await hivesService.CreateAsync(hiveServiceModel);

        if (result is 0)
        {
            return this.BadRequest();
        }

        return this.Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> UpdateHive(UpdateHiveFormModel hiveFormModel)
    {
        var hiveId = hiveFormModel.Id;
        var hiveServiceModel = new BaseHiveServiceModel
        {
            Id = hiveId,
            Number = hiveFormModel.Number,
            Type = hiveFormModel.Type!,
            Status = hiveFormModel.Status!,
            Color = hiveFormModel.Color,
            DateBought = hiveFormModel.DateBought,
            TimesUsedCount = hiveFormModel.TimesUsedCount,
            ApiaryId = hiveFormModel.ApiaryId,
        };

        await hivesService.UpdateAsync(hiveServiceModel);

        return this.Ok(hiveId);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Route("{id}")]
    public async Task<IActionResult> DeleteHive(int id)
    {
        var isDeleted = await hivesService.DeleteAsync(id);
        if (isDeleted)
        {
            return this.Ok();
        }

        return this.NotFound();
    }
}
