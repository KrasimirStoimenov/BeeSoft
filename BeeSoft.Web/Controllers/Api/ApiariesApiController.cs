namespace BeeSoft.Web.Controllers.Api;

using BeeSoft.Services.Apiary;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/apiaries")]
public class ApiariesApiController(IApiaryService apiaryService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<int>> Create()
    {
        var apiary = await apiaryService.CreateAsync();

        return apiary;
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<ActionResult<bool>> Delete([FromRoute] int id)
    {
        bool isDeleted = await apiaryService.DeleteAsync(id);

        return isDeleted;
    }
}
