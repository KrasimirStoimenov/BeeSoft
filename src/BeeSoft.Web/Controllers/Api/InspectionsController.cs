namespace BeeSoft.Web.Controllers.Api;

using BeeSoft.Services.Inspections;
using BeeSoft.Services.Inspections.Models;
using BeeSoft.Web.Models.Inspections;

using Microsoft.AspNetCore.Mvc;

[Route("api/inspections")]
public class InspectionsController(IInspectionsService inspectionsService) : BaseApiController
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<IEnumerable<InspectionListingServiceModel>>> GetAll()
    {
        var result = await inspectionsService.GetInspectionsAsync();

        return this.Ok(result);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [Route("{id}")]
    public async Task<ActionResult<BaseInspectionServiceModel>> GetById(int id)
    {
        var result = await inspectionsService.GetByIdAsync(id);

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
    public async Task<ActionResult<BaseInspectionServiceModel>> CreateHive(CreateInspectionFormModel inspectionFormModel)
    {
        var inspectionServiceModel = new BaseInspectionServiceModel
        {
            InspectionDate = inspectionFormModel.InspectionDate,
            WeatherConditions = inspectionFormModel.WeatherConditions,
            Observations = inspectionFormModel.Observations!,
            ActionsTaken = inspectionFormModel.ActionsTaken,
            HiveId = inspectionFormModel.HiveId,
        };

        var result = await inspectionsService.CreateAsync(inspectionServiceModel);

        if (result is 0)
        {
            return this.BadRequest();
        }

        return this.Ok(result);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> UpdateHive(UpdateInspectionFormModel inspectionFormModel)
    {
        var inspectionId = inspectionFormModel.Id;
        var inspectionServiceModel = new BaseInspectionServiceModel
        {
            Id = inspectionId,
            InspectionDate = inspectionFormModel.InspectionDate,
            WeatherConditions = inspectionFormModel.WeatherConditions,
            Observations = inspectionFormModel.Observations!,
            ActionsTaken = inspectionFormModel.ActionsTaken,
            HiveId = inspectionFormModel.HiveId,
        };

        await inspectionsService.UpdateAsync(inspectionServiceModel);

        return this.Ok(inspectionId);
    }

    [HttpDelete]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [Route("{id}")]
    public async Task<IActionResult> DeleteInspection(int id)
    {
        var isDeleted = await inspectionsService.DeleteAsync(id);
        if (isDeleted)
        {
            return this.Ok();
        }

        return this.NotFound();
    }
}
