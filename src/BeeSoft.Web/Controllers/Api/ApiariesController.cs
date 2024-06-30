namespace BeeSoft.Web.Controllers.Api;

using BeeSoft.Services.Apiaries;
using BeeSoft.Services.Apiaries.Models;
using BeeSoft.Services.Hives;
using BeeSoft.Web.Models.Apiaries;

using Microsoft.AspNetCore.Mvc;

[Route("api/apiaries")]
public class ApiariesController(IApiariesService apiariesService, IHivesService hivesService) : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IEnumerable<ApiaryServiceModel>>> GetApiaries()
    {
        var result = await apiariesService.GetApiariesAsync();

        return this.Ok(result);
    }


    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("{id}")]
    public async Task<ActionResult<ApiaryServiceModel>> GetApiaryById(int id)
    {
        var result = await apiariesService.GetByIdAsync(id);

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
    public async Task<ActionResult<int>> Create(CreateApiaryFormModel apiaryFormModel)
    {
        try
        {
        var apiaryServiceModel = new ApiaryServiceModel
        {
            Name = apiaryFormModel.Name,
            Location = apiaryFormModel.Location,
        };

        var apiaryId = await apiariesService.CreateAsync(apiaryServiceModel);

        if (apiaryId is 0)
        {
            return this.BadRequest();
        }

        return this.Ok(apiaryId);
    }
        catch (InvalidOperationException ex)
        {
            return this.BadRequest(ex.Message);
        }

    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Update(UpdateApiaryFormModel apiaryFormModel)
    {
        var apiaryId = apiaryFormModel.Id;
        var apiaryServiceModel = new ApiaryServiceModel
        {
            Id = apiaryId,
            Name = apiaryFormModel.Name,
            Location = apiaryFormModel.Location,
        };

        await apiariesService.UpdateAsync(apiaryServiceModel);

        return this.Ok(apiaryId);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Route("{apiaryId}/Hives")]
    public async Task<ActionResult<ApiaryServiceModel>> GetApiaryHives(int apiaryId)
    {
        var result = await hivesService.GetHivesInApiaryAsync(apiaryId);

        return this.Ok(result);
    }
}
