namespace BeeSoft.Web.Controllers;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static BeeSoft.Common.GlobalConstants;

[Authorize(Roles = AdministratorRoleName)]
public class AdministratorController : Controller
{
}
