namespace BeeSoft.Web.Controllers;
using System.Diagnostics;

using BeeSoft.Services.Apiaries;
using BeeSoft.Services.Hives;
using BeeSoft.Web.Models;
using BeeSoft.Web.Models.Apiaries;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

using static BeeSoft.Common.GlobalConstants;

public class HomeController(IApiariesService apiariesService, IHivesService hivesService) : Controller
{
    public async Task<IActionResult> Index()
    {
        if (this.User.Identity!.IsAuthenticated)
        {
            ICollection<ApiaryHivesViewModel> apiariesWithHivesViewModel = new List<ApiaryHivesViewModel>();

            var apiaries = await apiariesService.GetApiariesAsync();
            foreach (var apiary in apiaries.Where(x => x.Hives.Count > 0))
            {
                var hives = await hivesService.GetHivesInApiaryAsync(apiary.Id);

                apiariesWithHivesViewModel.Add(new ApiaryHivesViewModel
                {
                    ApiaryName = apiary.Name,
                    Hives = hives,
                });
            }

            return View(apiariesWithHivesViewModel);
        }

        return Redirect("Identity/Account/Login");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [Authorize(Roles = AdministratorRoleName)]
    [HttpGet]
    public IActionResult SetLanguage(string culture)
    {
        Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddDays(1) }
        );

        return Ok();
    }
}
