namespace BeeSoft.Web.Controllers;
using System.Diagnostics;

using BeeSoft.Web.Models;

using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;

public class HomeController() : Controller
{
    public IActionResult Index()
    {
        if (this.User.Identity.IsAuthenticated)
        {
            return Redirect("Apiaries/Index");
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
