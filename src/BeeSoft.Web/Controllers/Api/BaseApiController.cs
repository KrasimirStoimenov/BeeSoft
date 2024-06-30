namespace BeeSoft.Web.Controllers.Api;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static Common.GlobalConstants;

[ApiController]
[Authorize("api", Roles = AdministratorRoleName)]
[IgnoreAntiforgeryToken]
public class BaseApiController : ControllerBase
{
}
