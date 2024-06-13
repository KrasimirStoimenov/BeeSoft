namespace BeeSoft.Web.Controllers.Api;

using BeeSoft.Services.Apiaries;
using BeeSoft.Services.Apiaries.Models;
using BeeSoft.Services.Hives;

using Microsoft.AspNetCore.Mvc;

public class ApiariesController(IApiariesService apiariesService, IHivesService hivesService) : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IEnumerable<ApiaryServiceModel>>> GetApiaries()
    {
        IEnumerable<ApiaryServiceModel> result = await apiariesService.GetApiariesAsync();

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
